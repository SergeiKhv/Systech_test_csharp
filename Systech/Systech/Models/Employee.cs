using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systech.Models
{
    public class Employee : Person
    {
        public const double limit = 0.3;
        public const double growth = 0.03;

        public double calculateSal(DateTime date)
        {
            int years = getYears(date, this.HireDate);
            double nGrowth = growth * years;
            if (nGrowth > limit)
            {
                nGrowth = limit;
            }
            double res = 0;
            res = this.Salary + this.Salary * nGrowth;
            return res;
        }

        public Employee()
        {

        }

        public Employee(Person p)
        {
            pid = p.pid;
            Fullname = p.Fullname;
            Position = p.Position;
            HireDate = p.HireDate;
            Boss = p.Boss;
            Salary = p.Salary;            
        }
    }

}
