using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Helpers
{
    // helper in order to get a pagged list of the users
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize) {
            // get total number of items from source(Users, messages, etc)
            var count = await source.CountAsync();
            // remove a certain number of items from the front of the list 
            var items = await source.Skip((pageNumber-1) * pageSize)
            // then take the next pagesize items from the list
                                    .Take(pageSize).ToListAsync();
            // return a instance of this class
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}