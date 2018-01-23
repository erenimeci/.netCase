using KOC.DataAccess.Concrete.Mapping.Login;
using KOC.DataAccess.Concrete.Mapping.Test;
using KOC.Model.Entities.Login;
using KOC.Model.Entities.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOC.DataAccess.Concrete
{
    public class KOCDBContext : DbContext
    {

        public KOCDBContext()
            : base("Server=.;Database=KOC.DB;Integrated Security=true;")
        {
            Database.SetInitializer<KOCDBContext>(new DropCreateDatabaseIfModelChanges<KOCDBContext>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Question> Question { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new QuestionMap());

            modelBuilder.Properties()
                .Where(a => a.PropertyType == typeof(DateTime))
                .Configure(a => a.HasColumnType("datetime2").HasPrecision(0));
        }

    }
}
