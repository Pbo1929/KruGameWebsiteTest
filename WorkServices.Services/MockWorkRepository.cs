using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkModels.Models;

namespace WorkServices.Services
{
    public class MockWorkRepository : IWorkRepository
    {
        private List<Work> _workList;

        public MockWorkRepository()
        {
            _workList = new List<Work>()
            {
                new Work() { Id = 1, Title = "Thai Culture", StartDate = System.DateTime.Now, EndDate = System.DateTime.Now, Description = "Thailand is famous for its culture.", PhotoPath="user.png"},
                new Work() { Id = 2, Title = "Thai Story", StartDate = System.DateTime.Now, EndDate = System.DateTime.Now, Description = "The story of a hunter.", PhotoPath="user.png"}
            };
        }

        public Work Add(Work newWork)
        {
            newWork.Id = _workList.Max(e => e.Id) + 1;
            _workList.Add(newWork);
            return newWork;
        }

        public IEnumerable<Work> GetAllWorks()
        {
            return _workList;
        }

        public Work GetWork(int id)
        {
            return _workList.FirstOrDefault(e => e.Id == id);
        }

        public Work Update(Work updatedWork)
        {
            Work work = _workList
                .FirstOrDefault(e => e.Id == updatedWork.Id);
            if (work != null)
            {
                work.Title = updatedWork.Title;
                work.StartDate = updatedWork.StartDate;
                work.EndDate = updatedWork.EndDate;
                work.Description = updatedWork.Description;
                work.PhotoPath = updatedWork.PhotoPath;
            }
            return work;
        }
    }
}
