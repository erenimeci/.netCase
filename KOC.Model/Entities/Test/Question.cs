using KOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Model.Entities.Test
{
    public class Question : IEntity
    {
        public Guid QuestionID { get; set; }
        public Guid ExamID { get; set; }
        public string QuestionText { get; set; }
       
        public string choiceFirst { get; set; }
        public string choiceSecond { get; set; }
        public string choiceThird { get; set; }
        public string choiceFourth { get; set; }
        public string correctChoice { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
