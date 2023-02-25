using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Academy.Application.Convertors;
using Academy.Application.Security;
using Microsoft.AspNetCore.Http;

namespace Academy.Application.Extensions
{
    public static class FileExtensions
    {
        public static void AddImageToServer(this IFormFile image, string fileName, string orginalPath, int? width, int? height, string thumbPath = null, string deletefileName = null, bool checkImageContent = true)
        {
            if (image != null && image.IsImage(checkImageContent))
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (File.Exists(thumbPath + deletefileName))
                            File.Delete(thumbPath + deletefileName);
                    }
                }

                string finalPath = orginalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    if (!Directory.Exists(finalPath)) image.CopyTo(stream);
                }

                if (!string.IsNullOrEmpty(thumbPath))
                {
                    if (!Directory.Exists(thumbPath))
                        Directory.CreateDirectory(thumbPath);

                    ImageOptimizer resizer = new ImageOptimizer();

                    if (width != null && height != null)
                        resizer.ImageResizer(orginalPath + fileName, thumbPath + fileName, width, height);
                }
            }
        }

        public static void DeleteImage(this string imageName, string OriginPath, string? ThumbPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(OriginPath + imageName))
                    File.Delete(OriginPath + imageName);

                if (!string.IsNullOrEmpty(ThumbPath))
                {
                    if (File.Exists(ThumbPath + imageName))
                        File.Delete(ThumbPath + imageName);
                }
            }
        }

        public static List<string> FetchLinksFromSource(this string htmlSource)
        {
            List<string> links = new List<string>();

            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;

                links.Add(href);
            }

            return links;
        }

        public static async Task AddFilesToServer(this IFormFile file, string fileName, string orginalPath, string deletefileName = null, bool checkFileExtension = true)
        {
            if ((file != null && file.IsFile(checkFileExtension)))
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                    {
                        File.Delete(orginalPath + deletefileName);
                    }
                }

                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                string finalPath = orginalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }

        public static void DeleteFile(this string fileName, string OriginPath)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                if (File.Exists(OriginPath + fileName))
                {
                    File.Delete(OriginPath + fileName);
                }
            }
        }

        public static async Task AddFilesToServerWithNoFormatChecker(this IFormFile file, string fileName, string orginalPath)
        {
            if (!Directory.Exists(orginalPath))
                Directory.CreateDirectory(orginalPath);

            string finalPath = orginalPath + fileName;

            using (var stream = new FileStream(finalPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public static async Task AddVideoToServer(this IFormFile video, string fileName, string orginalPath, string deletefileName = null, bool checkFileExtension = true)
        {
            if (video != null && video.IsVideo())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                    {
                        File.Delete(orginalPath + deletefileName);
                    }
                }

                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                string finalPath = orginalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    await video.CopyToAsync(stream);
                }
            }
        }


    }
}
