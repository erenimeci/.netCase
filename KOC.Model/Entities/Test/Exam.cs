using KOC.Core.Entities;
using KOC.Model.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Model.Entities.Test
{
    public class Exam : IEntity
    {
        public Guid ExamID { get; set; }
        public string ExamName { get; set; }
        public string ExamContent { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual User User { get; set; }

    }
}
