using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterFrequency
{
    class CharacterCounter : IComparable
    {
        public string Character { get; set; }
        public int count { get; set; }

        public int CompareTo(object obj)
        {
            CharacterCounter f = obj as CharacterCounter;
            return Character.CompareTo(f.Character);
        }

        public override string ToString()
        {
            return $"{Character}: {count}";
        }
    }
}
