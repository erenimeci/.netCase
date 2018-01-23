using KOC.Model.Entities.Login;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete.Mapping.Login
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.UserName);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Surname).HasMaxLength(11).IsRequired();

            HasMany(x => x.Exam)
                .WithRequired(x => x.User)
                .WillCascadeOnDelete(true);
        }


    }
}
