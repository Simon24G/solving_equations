using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services
{
    internal interface IExecutorQuadraticEquation
    {
        SolutionEquation Execute(double a, double b, double c);
    }
}
