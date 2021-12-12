using System;
using System.Collections.Generic;

namespace No_1
{
    class Beverage 
    {
        private List<string> _parts = new List<string>();
 
        public void Add(string part)
        {
            _parts.Add(part);
        }
    
        public void Show()
        {
            Console.Write($"Builded beverage: '{_parts[0]}' with additives: ");


            Console.Write(String.Join(',', _parts.ToArray(), 1, _parts.Count - 1));
        }
    }
}
