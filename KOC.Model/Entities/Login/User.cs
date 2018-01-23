using KOC.Core.Entities;
using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Model.Entities.Login
{
    public class User : IEntity
    { 
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserPass { get; set;}
        public virtual ICollection<Exam> Exam { get; set; }

    }
}
