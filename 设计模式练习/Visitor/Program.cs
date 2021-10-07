using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessReport report = new BusinessReport();
            Console.WriteLine("=========== CEO看报表 ===========");
            report.ShowReport(new CEOVisitor());
            Console.WriteLine("=========== CTO看报表 ===========");
            report.ShowReport(new CTOVisitor());
        }
    }

    public class BusinessReport
    {

        private List<Staff> Staffs = new List<Staff>();

        public BusinessReport()
        {
            Staffs = new List<Staff>
            {
                new Manager(){ Name = "ManagerA", KPI = new Random().Next(0,10) },
                new Manager(){ Name = "ManagerB", KPI = new Random().Next(0,10) },
                new Engineer(){ Name = "Engineer1", KPI = new Random().Next(0,10) },
                new Engineer(){ Name = "Engineer2", KPI = new Random().Next(0,10) },
                new Engineer(){ Name = "Engineer3", KPI = new Random().Next(0,10) },
                new Engineer(){ Name = "Engineer4", KPI = new Random().Next(0,10) },
            };
        }

        public void ShowReport(IVisitor visitor)
        {
            foreach (var Staff in Staffs)
            {
                Staff.Accept(visitor);
            }
        }
    }
}
