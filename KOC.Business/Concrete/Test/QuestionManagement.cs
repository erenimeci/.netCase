using KOC.Business.Abstract.Test;
using KOC.DataAccess.Abstract.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Concrete.Test
{
    public class QuestionManagement : IQuestionService
    {

        IQuestionDAL _questionDal;
        public QuestionManagement(IQuestionDAL questionDal)
        {
            _questionDal = questionDal;

        }

        public void Add(Model.Entities.Test.Question item)
        {
            _questionDal.Add(item);
        }

        public void Delete(Model.Entities.Test.Question item)
        {
            _questionDal.Delete(item);
        }

        public void Update(Model.Entities.Test.Question item)
        {
            _questionDal.Update(item);
        }

        public Model.Entities.Test.Question GetByID(Guid QuestionID)
        {
            return _questionDal.Get(e => e.QuestionID == QuestionID);
        }

        public ICollection<Model.Entities.Test.Question> GetAll()
        {
            return _questionDal.GetAll();
        }
    }
}
