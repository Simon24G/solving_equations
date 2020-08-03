using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Helpers;
using NUnit.Framework;

namespace GEMS.TRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Helpers
{
    [TestFixture, Category("Unit"), TestOf(typeof(ParamsEquation))]
    internal class SolutionViewHelperTests
    {
        [Test]
        public void GetViewSolution_TwoSolutions_CorrectPartView()
        {
            // arrange
            var x1 = 1;
            var x2 = 2;
            var paramsEquation = new ParamsEquation(0, 0, 0);
            var s = SolutionEquation.CreateSolutions(x1, x2);

            // act 
            var view = paramsEquation.GetViewSolution(s);

            // assert
            Assert.IsTrue(view.Contains(paramsEquation.ToString()));
            Assert.IsTrue(view.Contains($"два корня: x1 = {x1}, x2 = {x2}"));
        }

        [Test]
        public void GetViewSolution_OneSolutions_CorrectPartView()
        {
            // arrange
            var x = 1;
            var paramsEquation = new ParamsEquation(0, 0, 0);
            var s = SolutionEquation.CreateSolutions(x);

            // act 
            var view = paramsEquation.GetViewSolution(s);

            // assert
            Assert.IsTrue(view.Contains(paramsEquation.ToString()));
            Assert.IsTrue(view.Contains($"один корень: x = {x}"));
        }

        [Test]
        public void GetViewSolution_NotSolutions_CorrectPartView()
        {
            // arrange
            var paramsEquation = new ParamsEquation(0, 0, 0);
            var s = SolutionEquation.CreateWithoutSolutions();

            // act 
            var view = paramsEquation.GetViewSolution(s);

            // assert
            Assert.IsTrue(view.Contains(paramsEquation.ToString()));
            Assert.IsTrue(view.Contains("нет корней"));
        }

        [Test]
        public void GetViewSolution_InfinityCountSolutions_CorrectPartView()
        {
            // arrange
            var paramsEquation = new ParamsEquation(0, 0, 0);
            var s = SolutionEquation.CreateInfinityCountSolutions();

            // act 
            var view = paramsEquation.GetViewSolution(s);

            // assert
            Assert.IsTrue(view.Contains(paramsEquation.ToString()));
            Assert.IsTrue(view.Contains("бесконечное число корней"));
        }
    }
}
