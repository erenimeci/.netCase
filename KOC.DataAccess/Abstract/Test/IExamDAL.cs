using KOC.Core.DataAccess;
using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Abstract.Test
{
    public interface IExamDAL : IEntityRepository<Exam>
    {
    }
}
