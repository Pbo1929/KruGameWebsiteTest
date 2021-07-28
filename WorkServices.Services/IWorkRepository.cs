using System;
using System.Collections.Generic;
using WorkModels.Models;

namespace WorkServices.Services
{
    public interface IWorkRepository
    {
        IEnumerable<Work> GetAllWorks();
        Work GetWork(int id);
        Work Update(Work updatedWork);
        Work Add(Work newWork);
        Work Delete(int id);
    }
}
