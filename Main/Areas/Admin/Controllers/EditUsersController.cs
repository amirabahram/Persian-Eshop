using Eshope.Web.HttpManager;
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditUsersController : Controller
    {
        private IAdminEditService _serv;

        public EditUsersController(IAdminEditService serv)
        {
            this._serv = serv;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serv.GetAllUsers());
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAdminViewModel model)
        {
            bool Crt = await _serv.Insert(model);
            if(Crt)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateUser");
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            return View(await _serv.ShowUserForEdit(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateAdminViewModel model)
        
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                UpdateUserResult result = await _serv.Update(model);
                switch (result)
                {
                    case UpdateUserResult.Success:
                        TempData["SuccessMessage"] = "ویرایش کاربر با موفقیت انجام شد";
                        return RedirectToAction("Index");
                        break;
                    case UpdateUserResult.Failed:
                        TempData["Failed"] = "خطایی رخ داده است";
                        return RedirectToAction("UpdateUser");
                        break;

                    case UpdateUserResult.UserNotFound:
                        TempData["UserNotFound"] = "کاربر پیدا نشد با این ای دی";
                        return RedirectToAction("Index");
                        break;
                    default:
                        break;
                }
            }
           
            return View(model);
        }
        //[HttpGet]
        //public IActionResult DeleteUser()
        //{
        //    TempData["Delete"] = "hhg";
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        { 
            await _serv.Delete(id);
            return JsonResponseStatus.Success();
            ////refresh Command????
            //return RedirectToAction("Index");
        }
    }
    
}
