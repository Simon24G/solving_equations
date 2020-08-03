using System;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Exceptios
{
    internal class InvalidDataFotParametersException : Exception
    {
        public InvalidDataFotParametersException(string message) : base(message) 
        {
        }
    }
}
