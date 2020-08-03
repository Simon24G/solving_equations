using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations;
using NUnit.Framework;
using System;

namespace GEMSTRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Services.ReadersQuadraticEquations
{
    [TestFixture, Category("Unit"), TestOf(typeof(FileReaderQuadraticEquations))]
    internal class FileReaderQuadraticEquationsTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Ctor_EmptyPathToFile_ThrowException(string pathToFile)
        {
            // arrange, act and assert
            Assert.Catch<ArgumentNullException>(() =>
            {
                _ = new FileReaderQuadraticEquations(pathToFile);
            });
        }
    }
}
