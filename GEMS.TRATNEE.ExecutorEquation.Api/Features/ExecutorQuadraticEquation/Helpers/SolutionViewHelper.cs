using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Helpers
{
    internal static class SolutionViewHelper
    {
        public static string GetViewSolution(this ParamsEquation paramsEquation, SolutionEquation solutionEquation) 
        {
            switch (solutionEquation.CountSolutions)
            {
                case CountSolutionsEquation.ONE:
                    return $"У уравнения {paramsEquation} один корень: x = {solutionEquation.X1}.";
                case CountSolutionsEquation.TWO:
                    return $"У уравнения {paramsEquation} два корня: x1 = {solutionEquation.X1}, x2 = {solutionEquation.X2}.";
                case CountSolutionsEquation.INFINITY_COUNT:
                    return $"У уравнения {paramsEquation} бесконечное число корней.";
                default:
                    return $"У уравнения {paramsEquation} нет корней.";
            }
        }
    }
}
