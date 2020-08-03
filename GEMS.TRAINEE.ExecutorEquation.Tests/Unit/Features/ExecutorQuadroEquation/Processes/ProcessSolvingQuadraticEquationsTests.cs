using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Processes;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GEMS.TRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Processes
{
    [TestFixture, Category("Unit"), TestOf(typeof(ProcessSolvingQuadraticEquations))]
    internal class ProcessSolvingQuadraticEquationsTests
    {
        [Test]
        public void Run_CorrectData_InvokesMethods()
        {
            // arrange
            var a1 = 1.0;
            var b1 = 2.0;
            var c1 = 3.0;
            var a2 = -0.8;
            var b2 = 2.0;
            var c2 = 3.5;
            var executorMock = new Mock<IExecutorQuadraticEquation>();
            executorMock.Setup(e => e.Execute(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
                        .Returns(SolutionEquation.CreateWithoutSolutions());

            var readerMock = new Mock<IReaderQuadraticEquations>();
            readerMock.Setup(r => r.Read())
                      .Returns(new List<ParamsEquation> { new ParamsEquation(a1 , b1, c1), new ParamsEquation(a2, b2, c2) });
            var factoryMock = new Mock<IFactoryReaderQuadraticEquations>();
            factoryMock.Setup(f => f.CreateReaderQuadraticEquations())
                       .Returns(readerMock.Object);
            var process = new ProcessSolvingQuadraticEquations(executorMock.Object, factoryMock.Object);

            // act 
            process.Run();

            // assert
            factoryMock.Verify(f => f.CreateReaderQuadraticEquations(), Times.Once);
            readerMock.Verify(f => f.Read(), Times.Once);
            executorMock.Verify(f => f.Execute(It.Is<double>(a => a1 == a), It.Is<double>(b => b1 == b), It.Is<double>(c => c1 == c)), Times.Once);
            executorMock.Verify(f => f.Execute(It.Is<double>(a => a2 == a), It.Is<double>(b => b2 == b), It.Is<double>(c => c2 == c)), Times.Once);
        }
    }
}
