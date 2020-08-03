using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Views;
using System;
using System.Collections.Generic;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Factories
{
    internal class SelectionReaderEquations : ISelectionReaderEquations
    {
        private static readonly IDictionary<char, TypesReadersEquations> _selections = new Dictionary<char, TypesReadersEquations>()
        {
            { '1' , TypesReadersEquations.FILE},
            { '2' , TypesReadersEquations.CONSOLE}
        };
        public TypesReadersEquations SelectMethodReadingEquations()
        {
            Console.WriteLine("Введите вариант способа считывания уравнений 1) из файла, 2) из консоли:");
            
            do {
                var selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (_selections.ContainsKey(selection)) 
                {
                    return _selections[selection];
                }
                Console.WriteLine("Ввести можно только 1 или 2");
            } while (true);
        }
    }
}
