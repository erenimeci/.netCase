using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Mapping.Test
{
    class QuestionMap : EntityTypeConfiguration<Question>
    {

        public QuestionMap()
        {
            HasKey(x => x.QuestionID);
            Property(x => x.QuestionText).HasMaxLength(250).IsRequired();
            Property(x => x.choiceFirst).HasMaxLength(50).IsRequired();
            Property(x => x.choiceSecond).HasMaxLength(50).IsRequired();
            Property(x => x.choiceThird).HasMaxLength(50).IsRequired();
            Property(x => x.choiceFourth).HasMaxLength(50).IsRequired();
            Property(x => x.correctChoice).HasMaxLength(50).IsRequired();
        }
    }
}
