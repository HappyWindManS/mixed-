namespace SchoolDataCF_Test2.Migrations
{
    using MVCCodeFirst.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDataCF_Test2.MyModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolDataCF_Test2.MyModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Schools.AddOrUpdate(new School() { Key = 1, Name = "Õ˚≈£∂’÷–—ß" });
            context.SaveChanges();
        }
    }
}
