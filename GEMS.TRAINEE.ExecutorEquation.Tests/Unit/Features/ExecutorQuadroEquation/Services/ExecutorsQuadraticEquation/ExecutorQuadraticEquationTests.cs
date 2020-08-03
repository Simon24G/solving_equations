using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ExecutorQuadraticEquation;
using NUnit.Framework;

namespace GEMSTRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Services
{
    [TestFixture, Category("Unit"), TestOf(typeof(ExecutorQuadraticEquation))]
    internal class ExecutorQuadraticEquationTests
    {
        [Test]
        public void Ctor_DoesNotException()
        {
            // arrange, act and assert
            Assert.DoesNotThrow(() => 
            {
                _ = new ExecutorQuadraticEquation();
            });
        }

        [TestCase(2, 2, 2)]
        [TestCase(2, 0, 2)]
        public void Execute_OtherCorrectParameters_NotSolutions(double a, double b, double c)
        {
            // arrange
            var executor = new ExecutorQuadraticEquation();

            // act 
            var solutions = executor.Execute(a, b, c);
            
            // assert
            Assert.AreEqual(CountSolutionsEquation.NOT_SOLUTION, solutions.CountSolutions);
        }

        [TestCase(1, 1, -1, ExpectedResult = CountSolutionsEquation.TWO)]
        [TestCase(1, 0, -1, ExpectedResult = CountSolutionsEquation.TWO)]
        [TestCase(0, 1, -1, ExpectedResult = CountSolutionsEquation.ONE)]
        [TestCase(0, 1, 1, ExpectedResult = CountSolutionsEquation.ONE)]
        [TestCase(0, 1, 0, ExpectedResult = CountSolutionsEquation.ONE)]
        public CountSolutionsEquation Execute_OtherCorrectParameters_CorrectCountSolutions(double a, double b, double c)
        {
            // arrange
            var executor = new ExecutorQuadraticEquation();

            // act and assert 
            return executor.Execute(a,b,c).CountSolutions;
        }

        [TestCase(1, 5, 4, -1, -4)]
        [TestCase(-2, 6, 3.5, -0.5, 3.5)]
        public void Execute_OtherCorrectParameters_CorrectBothSolutions(double a, double b, double c, double expectedSolutionFirst, double expectedSolutionSecond)
        {
            // arrange
            var executor = new ExecutorQuadraticEquation();
            
            // act 
            var solutions = executor.Execute(a,b,c);

            // assert 
            Assert.AreEqual(CountSolutionsEquation.TWO, solutions.CountSolutions);
            Assert.IsTrue(expectedSolutionFirst == solutions.X1 || expectedSolutionFirst == solutions.X2);
            Assert.IsTrue(expectedSolutionSecond == solutions.X1 || expectedSolutionSecond == solutions.X2);
        }

        [TestCase(0, 5, 4, ExpectedResult = -0.8)]
        [TestCase(3, 6, 3, ExpectedResult = -1)]
        public double Execute_OtherCorrectParameters_CorrectOneSolution(double a, double b, double c)
        {
            // arrange
            var executor = new ExecutorQuadraticEquation();

            // act 
            var solutions = executor.Execute(a, b, c);

            // assert 
            Assert.AreEqual(CountSolutionsEquation.ONE, solutions.CountSolutions);
            return solutions.X1;
        }
    }
}