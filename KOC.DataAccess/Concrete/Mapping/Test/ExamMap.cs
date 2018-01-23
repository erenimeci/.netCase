using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Mapping.Test
{
    class ExamMap : EntityTypeConfiguration<Exam>
    {

        public ExamMap()
        {
            HasKey(x => x.ExamID);
            Property(x => x.ExamName).IsRequired();
            Property(x => x.ExamContent).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            HasMany(x => x.Question).WithRequired(x => x.Exam).HasForeignKey(x => x.ExamID).WillCascadeOnDelete(true);

        }
    }
}
