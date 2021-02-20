using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scripture_Project.Data;
using Scripture_Project.Models;

namespace Scripture_Project.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly Scripture_Project.Data.Scripture_ProjectContext _context;

        public IndexModel(Scripture_Project.Data.Scripture_ProjectContext context)
        {
            _context = context;
        }



        public IList<Scripture> Scripture { get;set; }
        


        // Filters the verses
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Filters the book content
        [BindProperty(SupportsGet = true)]
        public string ContentString { get; set; }

        // Filters the verses added
        public SelectList Books { get; set; } 
        [BindProperty(SupportsGet = true)]
        public string BookType { get; set; }

        //Filters dates that were added
        public SelectList Dates { get; set; } 
        [BindProperty(SupportsGet = true)]
        public string DateType { get; set; } 





        public async Task OnGetAsync(string sortOrder)
        {
            
            // THIS SECTION ORGANIZES THE SEARCH QUERY IN THE VERSE AND CONTENT INPUTS


            var scriptures = from m in _context.Scripture
                             select m;


            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Verse.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ContentString))
            {
                scriptures = scriptures.Where(s => s.Content.Contains(ContentString));
            }


            //THIS SECTION SORTS THE DATE COLUMN IN DESC ORDER //
            DateType = sortOrder == "Date" ? "date_desc" : "Date";
            BookType = sortOrder == "Books" ? "books_desc" : "Books";

           

            switch (sortOrder)
            {

                case "Date":
                    scriptures = scriptures.OrderBy(s => s.EntryDate);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.EntryDate);
                    break;
                case "Books":
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
                case "books_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;

            }

            
            Scripture = await scriptures.ToListAsync();


        }
    }
}
