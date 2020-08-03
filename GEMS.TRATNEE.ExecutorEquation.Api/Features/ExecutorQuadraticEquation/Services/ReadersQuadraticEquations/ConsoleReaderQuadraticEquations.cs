using System;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations
{
    internal class ConsoleReaderQuadraticEquations : BaseReaderQuadraticEquations
    {
        public ConsoleReaderQuadraticEquations()
        {
        }

        public override void Dispose()
        {
        }

        protected override void LogStartingProcessReadig()
        {
            Console.WriteLine("Вводите по 3 числа разделенных пробелом, которые будут представлять уравнение ax^2 + bx + с = 0:");
        }

        protected override string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
