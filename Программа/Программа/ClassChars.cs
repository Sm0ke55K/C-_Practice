using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Программа
{
    public class ClassChars
    {
        public char Letter;
        public int Count;
        public float Probability;
        public string CodeSF;
        public ClassChars() { }
        public ClassChars(char Lett, int Cou, float Prob, string Code)
        {
            this.Letter = Lett;
            this.Count = Cou;
            this.Probability = Prob;
            this.CodeSF = Code;
        }
    }
}
