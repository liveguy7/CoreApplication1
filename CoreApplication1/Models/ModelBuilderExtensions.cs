
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mark",
                    Department = Dept.HR,
                    Email = "mark@na.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Pan",
                    Department = Dept.HR,
                    Email = "pan@na.com"
                },
                   new Employee
                   {
                       Id = 3,
                       Name = "Ben",
                       Department = Dept.HR,
                       Email = "ben@na.com"
                   }
                );



        }

    }
}
