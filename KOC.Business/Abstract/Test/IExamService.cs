using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Abstract.Test
{
    public interface IExamService
    {
        void Add(Exam item);
        void Delete(Exam item);
        void Update(Exam item);
        Exam GetByID(Guid ExamID);
        ICollection<Exam> GetAll();
    }
}
