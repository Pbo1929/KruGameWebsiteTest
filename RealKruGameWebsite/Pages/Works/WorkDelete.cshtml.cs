using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkModels.Models;
using WorkServices.Services;

namespace RealGameWebsiteTest.Pages.Works
{
    public class WorkDeleteModel : PageModel
    {

        private readonly IWorkRepository workRepository;
        public WorkDeleteModel(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        [BindProperty]
        public Work Work { get; set; }

        public IActionResult OnGet(int id)
        {
            Work = workRepository.GetWork(id);

            if (Work == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Work DeletedWork = workRepository.Delete(Work.Id);

            if (Work == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Work");
        }
    }
}
