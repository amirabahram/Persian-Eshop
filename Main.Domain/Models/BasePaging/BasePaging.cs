using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main.Domain.Models.Base_Paging
{
    public class BasePaging<T>
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int HowManyBeforeAndAfter { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int AllEntityCount { get; set; }
        public List<T> Entities { get; set; }

        public BasePaging()
        {
            int CurrentPage = 1;
            int HowManyBeforeAndAfter = 5;
            int TakeEntity = 10;
            var Entities = new List<T>();
        }

        public async Task Paging(IQueryable<T> queryable)
        {
            int AllEntityCount = await queryable.CountAsync();
            int SkipEntity = (CurrentPage - 1) * TakeEntity;
            PageCount = Convert.ToInt32(Math.Ceiling(AllEntityCount / (double)TakeEntity));//ceiling be samt bala gerd mikonad....agar hardo int bashand bagimande nemidahad. yeki ra bayad double konim...inja chon vakeshi nemikonim await estefade nemikonim
            StartPage = ((CurrentPage - HowManyBeforeAndAfter) < 0 || (CurrentPage - HowManyBeforeAndAfter) == 0) ? 1 : (CurrentPage - HowManyBeforeAndAfter);
            EndPage = ((CurrentPage + HowManyBeforeAndAfter) > PageCount || (CurrentPage + HowManyBeforeAndAfter) == PageCount) ? PageCount : (CurrentPage + HowManyBeforeAndAfter);
            
            Entities = await queryable.Skip(SkipEntity).Take(TakeEntity).ToListAsync();

        }
   
    }
    public class PagingViewModel
    {
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
