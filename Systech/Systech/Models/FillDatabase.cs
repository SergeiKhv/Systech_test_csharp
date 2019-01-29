using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systech.Models
{
    public class FillDatabase
    {
        public void createDatabase()
        {
            using (var dataContext = new InhDBContext())
            {
                
                Employee emp1 = new Employee();
                Employee emp2 = new Employee();
                Employee emp3 = new Employee();
                Salesman sale1 = new Salesman();
                Manager man1 = new Manager();
                Manager man2 = new Manager();

                emp1.Fullname = "Игорь Новик";
                emp1.Position = "employee";
                emp1.Salary = 20000;
                emp1.HireDate = new DateTime(2009, 10, 22);

                emp2.Fullname = "Петр Некитов";
                emp2.Position = "employee";
                emp2.Salary = 22000;
                emp2.HireDate = new DateTime(2010, 11, 04);
                emp2.Boss = sale1;

                emp3.Fullname = "Юрий Ктоний";
                emp3.Position = "employee";
                emp3.Salary = 22000;
                emp3.HireDate = new DateTime(2008, 07, 12);
                emp3.Boss = man2;

                sale1.Fullname = "Володий Петров";
                sale1.Position = "salesman";
                sale1.Salary = 50000;
                sale1.HireDate = new DateTime(2005, 02, 11);
                sale1.Subordinates = new List<Person>();
                sale1.Subordinates.Add(emp2);
                sale1.Subordinates.Add(man1);
                sale1.Subordinates.Add(man2);

                man1.Fullname = "Алексей Димитров";
                man1.Position = "manager";
                man1.Salary = 28000;
                man1.HireDate = new DateTime(2011, 04, 17);
                man1.Boss = sale1;

                man2.Fullname = "Кирилл Рыбаков";
                man2.Position = "manager";
                man2.Salary = 36000;
                man2.HireDate = new DateTime(2007, 08, 06);
                man2.Boss = sale1;
                man2.Subordinates = new List<Person>();
                man2.Subordinates.Add(emp3);

                dataContext.People.Add(emp1);
                dataContext.People.Add(emp2);
                dataContext.People.Add(emp3);
                dataContext.People.Add(sale1);
                dataContext.People.Add(man1);
                dataContext.People.Add(man2);

                dataContext.SaveChanges();
            }
        }
    }
}
