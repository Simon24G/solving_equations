using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Dto;
using System;
using System.Collections.Generic;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services
{
    internal interface IReaderQuadraticEquations : IDisposable
    {
        IEnumerable<ParamsEquation> Read();
    }
}
