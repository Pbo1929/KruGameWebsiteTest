using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkModels.Models;
using WorkServices.Services;

namespace RealKruGameWebsite.Pages.Works
{
    public class WorkModel : PageModel
    {
        private readonly IWorkRepository workRepository;
        public IEnumerable<Work> Works { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public WorkModel(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }
        
        public void OnGet()
        {
            Works = workRepository.Search(SearchTerm);
        }
    }
}
