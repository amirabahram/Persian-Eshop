using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main.Domain.Models.BasePaging
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
        public int Counter { get; set; }

        public BasePaging()
        {
             CurrentPage = 1;
             HowManyBeforeAndAfter = 5;
             TakeEntity = 4;
             Entities = new List<T>();
        }

        public async Task<BasePaging<T>> Paging(IQueryable<T> queryable)
        {
            TakeEntity = TakeEntity;

            var allEntitiesCount = await queryable.CountAsync();

            var pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)TakeEntity));

            CurrentPage = CurrentPage > pageCount ? pageCount : CurrentPage;
            if (CurrentPage <= 0) CurrentPage = 1;
            AllEntityCount = allEntitiesCount;
            HowManyBeforeAndAfter = HowManyBeforeAndAfter;
            SkipEntity = (CurrentPage - 1) * TakeEntity;
            StartPage = CurrentPage - HowManyBeforeAndAfter <= 0 ? 1 : CurrentPage - HowManyBeforeAndAfter;
            EndPage = CurrentPage + HowManyBeforeAndAfter > pageCount ? pageCount : CurrentPage + HowManyBeforeAndAfter;
            PageCount = pageCount;
            Entities = await queryable.Skip(SkipEntity).Take(TakeEntity).ToListAsync();
            Counter = ((CurrentPage - 1) * TakeEntity) + 1;
            return this;
        }

        public PagingViewModel CurrentPaging()
        {
            return new PagingViewModel()
            {
                StartPage = this.StartPage,
                EndPage = this.EndPage,
                CurrentPage = this.CurrentPage
            };
        }
   
    }
    public class PagingViewModel
    {
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
