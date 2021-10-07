using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IVisitor
    {

        void Visit(Engineer engineer);
        void Visit(Manager manager);
    }

    public class CEOVisitor : IVisitor
    {
        public void Visit(Engineer engineer)
        {
            Console.WriteLine($"Engineer: {engineer.Name},KPI: {engineer.KPI}");
        }

        public void Visit(Manager manager)
        {
            Console.WriteLine($"Manager: {manager.Name},KPI: {manager.KPI}");
        }
    }

    public class CTOVisitor : IVisitor
    {
        public void Visit(Engineer engineer)
        {
            Console.WriteLine($"Engineer: {engineer.Name},CodeLines: {engineer.GetCodeLines()}");
        }

        public void Visit(Manager manager)
        {
            Console.WriteLine($"Manager: {manager.Name},Products: {manager.GetProducts()}");
        }
    }
}
