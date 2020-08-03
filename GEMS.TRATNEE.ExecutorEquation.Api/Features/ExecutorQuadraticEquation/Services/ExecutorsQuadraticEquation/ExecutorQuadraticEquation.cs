using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using System;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ExecutorQuadraticEquation
{
    internal sealed class ExecutorQuadraticEquation : IExecutorQuadraticEquation
    {
        public SolutionEquation Execute(double a, double b, double c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return SolutionEquation.CreateInfinityCountSolutions();
                }
                return SolutionEquation.CreateSolutions(-c / b);
            }

            var descrimenant = b*b - 4*a*c;

            if (descrimenant < 0)
            {
                return SolutionEquation.CreateWithoutSolutions();
            }

            if (descrimenant == 0)
            {
                return SolutionEquation.CreateSolutions(-b / (2 * a));
            }

            var sqrtDescrimenant = Math.Sqrt(descrimenant);
            
            var x1 = (-b - sqrtDescrimenant) / (2 * a);
            var x2 = (-b + sqrtDescrimenant) / (2 * a);
            
            return SolutionEquation.CreateSolutions(x1, x2);
        }
    }
}
