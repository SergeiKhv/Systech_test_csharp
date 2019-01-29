using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systech.Models
{
    public class Person
    {
        [Key]
        public int pid { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        virtual public Person Boss { get; set; }
        virtual public List<Person> Subordinates { get; set; }

        public int getYears(DateTime date, DateTime hdate)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime corTime = new DateTime(1, 1, 2);
            TimeSpan corspan = corTime - zeroTime;
            TimeSpan span = date - hdate;
            span = span + corspan;
            int years = (zeroTime + span).Year - 1;
            return years;
        }

        public double calculateSal(DateTime date)
        {
            return 0;
        }

        public double countSub(DateTime date)
        {
            return 0;
        }
    }
}
