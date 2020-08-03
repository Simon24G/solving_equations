using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Exceptios;
using System.Collections.Generic;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations
{
    internal abstract class BaseReaderQuadraticEquations : IReaderQuadraticEquations
    {
        public IEnumerable<ParamsEquation> Read()
        {
            LogStartingProcessReadig();
            var paramsEquations = new List<ParamsEquation>();

            string line;
            int numStr = 0;
            int numElement = 0;
            
            while (!string.IsNullOrWhiteSpace(line = ReadLine()))
            {
                numStr++;

                var paramsEq = new List<double>();
                var bits = line.Split(' ');
                foreach (var bit in bits)
                {
                    numElement++;
                    if (!double.TryParse(bit, out var value))
                    {
                        throw new InvalidDataFotParametersException($"'{bit}'(str:{numStr}; elem:{numElement}) нельзя преобразовать к вещественному типу.");
                    }
                    paramsEq.Add(value);
                }

                if (paramsEq.Count != 3)
                {
                    throw new InvalidDataFotParametersException($"Количестов параметров для квадратного уравнения должно быть равно 3, однако оно равно {paramsEq.Count}.");
                }

                paramsEquations.Add(new ParamsEquation(paramsEq[0], paramsEq[1], paramsEq[2]));
            }

            return paramsEquations;
        }

        protected abstract string ReadLine();
        protected abstract void LogStartingProcessReadig();

        public abstract void Dispose();

    }
}
