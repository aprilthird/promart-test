using PromartTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromartTest.Entities.Models
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DocumentNumber { get; set; }

        public double Salary { get; set; }

        public int Age { get; set; }

        public string Profile { get; set; }

        public DateTime AdmissionDate { get; set; }
    }
}
