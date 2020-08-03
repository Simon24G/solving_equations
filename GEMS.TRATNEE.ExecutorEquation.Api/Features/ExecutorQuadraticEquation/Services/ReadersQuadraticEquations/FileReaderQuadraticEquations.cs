using System;
using System.IO;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations
{
    internal class FileReaderQuadraticEquations : BaseReaderQuadraticEquations
    {
        private StreamReader _fileReader;
        public FileReaderQuadraticEquations(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) 
            {
                throw new ArgumentNullException();
            }

            _fileReader = File.OpenText(filePath.Trim());
        }

        public override void Dispose()
        {
            _fileReader.Dispose();
        }

        protected override string ReadLine()
        {
            return _fileReader.ReadLine();
        }

        protected override void LogStartingProcessReadig()
        {
            Console.WriteLine("Начало считывание данных из файла:");
        }
    }
}
