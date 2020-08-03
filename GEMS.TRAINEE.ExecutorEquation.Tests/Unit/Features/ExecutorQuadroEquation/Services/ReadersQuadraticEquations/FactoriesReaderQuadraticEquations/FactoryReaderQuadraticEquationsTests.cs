using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaderQuadraticEquations;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Views;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace GEMS.TRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Services.ReadersQuadraticEquations.FactoriesReaderQuadraticEquations
{
    [TestFixture, Category("Unit"), TestOf(typeof(FactoryReaderQuadraticEquations))]
    internal class FactoryReaderQuadraticEquationsTests
    {
        [Test]
        public void CreateReaderQuadraticEquations_TypeReaderEquationsIsConsole_ReaderIsConsoleReaderQuadraticEquations()
        {
            // arrange

            var selectionReader = new Mock<ISelectionReaderEquations>();
            selectionReader.Setup(s => s.SelectMethodReadingEquations())
                           .Returns(TypesReadersEquations.CONSOLE);
            var factory = new FactoryReaderQuadraticEquations(selectionReader.Object);
            
            // act
            var reader = factory.CreateReaderQuadraticEquations();

            // assert
            Assert.IsTrue(reader is ConsoleReaderQuadraticEquations);
        }

        [Test]
        public void CreateReaderQuadraticEquations_TypeReaderEquationsIsFile_ReaderIsFileReaderQuadraticEquations()
        {
            // arrange

            var selectionReader = new Mock<ISelectionReaderEquations>();
            selectionReader.Setup(s => s.SelectMethodReadingEquations())
                           .Returns(TypesReadersEquations.FILE);
            var factory = new FactoryReaderQuadraticEquations(selectionReader.Object);
            Console.SetIn(new StreamReader(new MemoryStream()));

            // act
            IReaderQuadraticEquations reader;
            try
            {
                reader = factory.CreateReaderQuadraticEquations();
            }
            finally
            {
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }
            
            // assert
            Assert.IsTrue(reader is FileReaderQuadraticEquations);
        }


        [Test]
        public void CreateReaderQuadraticEquations_TypeReaderEquationsIsFileAndPathToFileIsCustom_ReaderIsFileReaderQuadraticEquations()
        {
            // arrange
            var correctPath = @"C:\Users\Zver\source\repos\solving_equations\GEMS.TRAINEE.ExecutorEquation.Tests\bin\Debug\netcoreapp3.1\ResourcesForTests\TestFileTwoLine.txt
                                a1
                                b1";
            var selectionReader = new Mock<ISelectionReaderEquations>();
            selectionReader.Setup(s => s.SelectMethodReadingEquations())
                           .Returns(TypesReadersEquations.FILE);
            var factory = new FactoryReaderQuadraticEquations(selectionReader.Object);
            Console.SetIn(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(correctPath))));

            // act
            IReaderQuadraticEquations reader;
            try
            {
                reader = factory.CreateReaderQuadraticEquations();
            }
            finally 
            {
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }

            // assert
            Assert.IsTrue(reader is FileReaderQuadraticEquations);
        }


        [Test]
        public void CreateReaderQuadraticEquations_TypeReaderEquationsIsFileAndPathToFileIsCustomIncorrect_ReaderIsFileReaderQuadraticEquations()
        {
            // arrange
            var incorrectPath = "wrong";
            var selectionReader = new Mock<ISelectionReaderEquations>();
            selectionReader.Setup(s => s.SelectMethodReadingEquations())
                           .Returns(TypesReadersEquations.FILE);
            var factory = new FactoryReaderQuadraticEquations(selectionReader.Object);
            Console.SetIn(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(incorrectPath))));

            // act and assert
            Assert.Catch<DirectoryNotFoundException>(() => factory.CreateReaderQuadraticEquations());
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
    }
}
