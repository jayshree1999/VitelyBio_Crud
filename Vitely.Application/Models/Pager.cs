using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitely.Application.Models
{
    public class Pager
    {
        public int TotalItems { get; set; }//total num of revcords
        public int CurrentPage { get; set; }//to show the active page
        public int PageSize { get; set; }//no of records to be displayed on the page
        public int TotalPages { get; set; }//total num of pages
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public Pager() { }
        public Pager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startpage = currentPage - 5;
            int endpage = currentPage + 4;
            if (startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }
            if (endpage > totalPages)
            {
                endpage = totalPages;
                if (endpage > 10)
                {
                    startpage = endpage - 9;
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            StartPage = startpage;
            EndPage = endpage;

        }
    }
}