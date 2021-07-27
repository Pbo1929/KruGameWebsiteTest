using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkModels.Models;
using WorkServices.Services;

namespace RealKruGameWebsite.Pages.Works
{
    public class WorkDetailsModel : PageModel
    {
        private readonly IWorkRepository workRepository;

        public WorkDetailsModel(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }

        public Work Work { get; private set; }

        public void OnGet(int id)
        {
            Work = workRepository.GetWork(id);
        }
    }
}
