using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations;
using System.Collections.Generic;
using System.Linq;

namespace GEMSTRAINEE.ExecutorEquation.Tests.Utils
{
    internal class FakeReader : BaseReaderQuadraticEquations
    {
        private IList<string> _strings;
        public FakeReader(IList<string> strings) 
        {
            _strings = strings;
        }
        private int currentId;
        protected override string ReadLine()
        {
            if (currentId >= _strings.Count()) 
            {
                return null;
            }
            
            return _strings[currentId++];
        }

        public override void Dispose()
        {
        }

        protected override void LogStartingProcessReadig()
        {
        }
    }
}
