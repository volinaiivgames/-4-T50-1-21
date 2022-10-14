using System;
using System.Collections.Generic;
using System.Text;

namespace practic4
{
    class DateList
    {
        public DateTime Date { get; set; }
        public List<Page> Pages { get; set; }

        public DateList(DateTime date, List<Page> pages)
        {
            Date = date;
            Pages = pages;
        }
    }
}
