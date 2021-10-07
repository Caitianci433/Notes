using System;

namespace Visitor
{
    public interface IStaff
    {
        public abstract void Accept(IVisitor visitor);
    }

    public abstract class Staff: IStaff
    {
        public string Name { get; set; }

        public int KPI { get; set; }

        public abstract void Accept(IVisitor visitor);
    }

    public class Engineer : Staff
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetCodeLines()
        {
            return new Random().Next(0, 10000);
        }
    }

    public class Manager : Staff
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetProducts()
        {
            return new Random().Next(0, 100);
        }
    }
}
