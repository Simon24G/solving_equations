using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Exceptios;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations;
using GEMSTRAINEE.ExecutorEquation.Tests.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GEMSTRAINEE.ExecutorEquation.Tests.Unit.Features.ExecutorQuadroEquation.Services.ReadersQuadraticEquations
{
    [TestFixture, Category("Unit"), TestOf(typeof(BaseReaderQuadraticEquations))]
    internal class BaseReaderQuadraticEquationsTests
    {
        [TestCase("0 9 8",0,9,8)]
        [TestCase("0 -9 -8",0,-9,-8)]
        [TestCase("-0 9 8",0,9,8)]
        [TestCase("-0,5 9,0 -8,2",-0.5,9,-8.2)]
        public void Read_CorrectData_DoesNotThrowCorrectParameters(string dataLine, double a, double b, double c) 
        {
            // arrange
            var data = new List<string> { dataLine };
            var fakeReader = new FakeReader(data);

            // act
            var paramsEquation = fakeReader.Read().First();

            // assert
            Assert.AreEqual(a, paramsEquation.A);
            Assert.AreEqual(b, paramsEquation.B);
            Assert.AreEqual(c, paramsEquation.C);
        }

        [TestCase("0 9.0 8")]
        [TestCase("0 9-0 8")]
        [TestCase("0 9,0.0 8")]
        [TestCase("0 9.0 8")]
        [TestCase("0 9.0 -")]
        [TestCase("0 1a 8")]
        [TestCase("0 aa 8")]
        [TestCase("0 q-1 8")]
        [TestCase("0 0,-1 8")]
        [TestCase("0 0,a 8")]
        public void Read_InvalidData_ThrowInvalidDataFotParametersException(string dataLine)
        {
            // arrange
            var data = new List<string> { dataLine };
            var fakeReader = new FakeReader(data);

            // act and assert
            Assert.Catch<InvalidDataFotParametersException>(() =>
            {
                fakeReader.Read();
            });
        }

        [TestCase("0 9,0 8", "0 9,0 8 2", "3 2 1")]
        [TestCase("0 9,0 8 7 3", "0 9,0 8", "3 2 1")]
        [TestCase("0 9,0 8", "0 9,0 8 2", "3 2 1 4")]
        [TestCase("0 9,0", "0 8 2", "3 2 1")]
        [TestCase("0 9,0 3", "0", "3 2 1")]
        public void Read_CorrectValuesDataAndCountValuesNoEquals3_ThrowInvalidDataFotParametersException(string dataLine1, string dataLine2, string dataLine3)
        {
            // arrange
            var data = new List<string> { dataLine1, dataLine2, dataLine3 };
            var fakeReader = new FakeReader(data);

            // act and assert
            Assert.Catch<InvalidDataFotParametersException>(() =>
            {
                fakeReader.Read();
            });
        }
    }
}
