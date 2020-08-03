
namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto
{
    internal class ParamsEquation
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public ParamsEquation(double a, double b, double c) 
        {
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"{A}x^2 + {B}x + {C} = 0";
        }
    }
}
