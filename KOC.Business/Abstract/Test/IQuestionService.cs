using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Business.Abstract.Test
{
    public interface IQuestionService
    {
        void Add(Question item);
        void Delete(Question item);
        void Update(Question item);
        Question GetByID(Guid QuestionID);
        ICollection<Question> GetAll();
    }
}
