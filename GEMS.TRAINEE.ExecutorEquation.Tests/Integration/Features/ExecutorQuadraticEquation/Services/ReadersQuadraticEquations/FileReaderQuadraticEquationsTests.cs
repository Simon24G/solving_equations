using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations;
using NUnit.Framework;
using System.Linq;

namespace GEMSTRAINEE.ExecutorEquation.Tests.Integration.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations
{
    [TestFixture, Category("Integration"), TestOf(typeof(FileReaderQuadraticEquations))]
    internal class FileReaderQuadraticEquationsTests
    {
        private const string PathToFileWithOneLine = "ResourcesForTests/TestFileOneLine.txt";
        private const string PathToFileWithTwoLine = "ResourcesForTests/TestFileTwoLine.txt";


        [Test]
        public void Read_CorrectDataForOneEquation_DoesNotThrowCorrectParameters()
        {
            // arrange
            var a = 1.0;
            var b = 2.0;
            var c = -3.0;

            var fileReader = new FileReaderQuadraticEquations(PathToFileWithOneLine);

            // act
            var paramsEquation = fileReader.Read().First();

            // assert
            Assert.AreEqual(a, paramsEquation.A);
            Assert.AreEqual(b, paramsEquation.B);
            Assert.AreEqual(c, paramsEquation.C);
        }

        [Test]
        public void Read_CorrectDataForTwoEquations_DoesNotThrowCorrectParameters()
        {
            // arrange
            var a1 = 1.0;
            var b1 = 2.0;
            var c1 = 3.0;
            var a2 = -0.8;
            var b2 = 2.0;
            var c2 = 3.5;

            var fileReader = new FileReaderQuadraticEquations(PathToFileWithTwoLine);

            // act
            var paramsEquations = fileReader.Read().ToList();

            // assert
            Assert.AreEqual(2, paramsEquations.Count);
            var paramsEquationFirst = paramsEquations[0];
            var paramsEquationSecond = paramsEquations[1];
            
            Assert.AreEqual(a1, paramsEquationFirst.A);
            Assert.AreEqual(b1, paramsEquationFirst.B);
            Assert.AreEqual(c1, paramsEquationFirst.C);
            Assert.AreEqual(a2, paramsEquationSecond.A);
            Assert.AreEqual(b2, paramsEquationSecond.B);
            Assert.AreEqual(c2, paramsEquationSecond.C);
        }
    }
}
