using System;

namespace Home.Shapes
{
    public abstract class BaseShape : IShape
    {
        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
