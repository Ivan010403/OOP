using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    public class AbstractFactory
    {
        public virtual CFigure createFigure(string code)
        {
            return null;
        }
    };
    public class current_factory : AbstractFactory
    {
        public override CFigure createFigure(string code)
        {
            switch (code)
            {
                case "C":
                    return new CCircle();
                case "T":
                    return new CTriangle();
                case "R":
                    return new CRectangle();
                case "G":
                    return new CGroup();
                default:
                    break;
            }
            return null;
        }
    }
}
