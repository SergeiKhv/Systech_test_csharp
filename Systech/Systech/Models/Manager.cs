using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systech.Models
{
    public class Manager : Person
    {
        public const double limit = 0.4;
        public const double growth = 0.05;
        public const double subGrowth = 0.005;

        public double calculateSal(DateTime date)
        {
            int years = getYears(date, HireDate);
            double nGrowth = growth * years;
            if (nGrowth > limit)
            {
                nGrowth = limit;
            }
            double sal = 0;
            if (Subordinates!=null) {
                int count = 0;
                count = Subordinates.Count();
                for (int i = 0; i < count; i++)
                {
                    //В случае если надбавка за подчиненных считается с базовой ставки заменить метод calculateSal(date) на .Salary
                    sal += Subordinates[i].calculateSal(date);
                }
            }
            double res = 0;
            res = Salary + Salary * nGrowth + sal * subGrowth;
            return res;
        }

        public double countSub(DateTime date)
        {
            double sal = 0;
            if (Subordinates!=null) {
                int count = 0;
                count = Subordinates.Count();
                for (int i = 0; i < count; i++)
                {
                    sal += Subordinates[i].calculateSal(date);
                    if (!Subordinates[i].Position.Equals("employee"))
                    {
                        double ssal = Subordinates[i].countSub(date);
                        sal += ssal;
                    }
                }
            }
            return sal;
        }

        public Manager()
        {

        }

        public Manager(Person p)
        {
            pid = p.pid;
            Fullname = p.Fullname;
            Position = p.Position;
            HireDate = p.HireDate;
            Boss = p.Boss;
            Salary = p.Salary;
            Subordinates = p.Subordinates;

        }
      
    }
}
