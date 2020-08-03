using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto
{
    public class SolutionEquation
    {
        public double X1 { get; private set; }
        public double X2 { get; private set; }

        public CountSolutionsEquation CountSolutions { get; private set; }

        private SolutionEquation()
        {
        }

        public static SolutionEquation CreateSolutions(double x1, double x2)
        {
            return new SolutionEquation
            {
                X1 = x1,
                X2 = x2,
                CountSolutions = CountSolutionsEquation.TWO
            };
        }
        public static SolutionEquation CreateSolutions(double x)
        {
            return new SolutionEquation
            {
                X1 = x,
                CountSolutions = CountSolutionsEquation.ONE
            };
        }


        public static SolutionEquation CreateWithoutSolutions() 
        {
            return new SolutionEquation
            {
                CountSolutions = CountSolutionsEquation.NOT_SOLUTION
            };
        }


        public static SolutionEquation CreateInfinityCountSolutions()
        {
            return new SolutionEquation
            {
                CountSolutions = CountSolutionsEquation.INFINITY_COUNT
            };
        }
    }
}
