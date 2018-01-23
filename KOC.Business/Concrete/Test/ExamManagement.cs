using KOC.Business.Abstract.Test;
using KOC.DataAccess.Abstract.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Concrete.Test
{
    public class ExamManagement : IExamService
    {
        IExamDAL _examDal;
        IQuestionDAL _qDal;

        public ExamManagement(IExamDAL examDal, IQuestionDAL qDAL)
        {
            _examDal = examDal;
            _qDal = qDAL;

        }

        public void Add(Model.Entities.Test.Exam item)
        {
            _examDal.Add(item);
        }

        public void Delete(Model.Entities.Test.Exam item)
        {
            List<KOC.Model.Entities.Test.Question> questions = new List<Model.Entities.Test.Question>();
            questions.AddRange(item.Question);
            foreach (var q in questions)
            {
                _qDal.Delete(q);
            }
            _examDal.Delete(item);
        }

        public void Update(Model.Entities.Test.Exam item)
        {
            _examDal.Update(item);
        }

        public Model.Entities.Test.Exam GetByID(Guid ExamID)
        {
            return _examDal.Get(e => e.ExamID == ExamID);
        }

        public ICollection<Model.Entities.Test.Exam> GetAll()
        {
            return _examDal.GetAll();
        }
    }
}
