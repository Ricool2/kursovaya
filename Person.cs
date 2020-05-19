using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours
{
    public class Person
    {
        public string Name { get; set; }
        public string InFamily { get; set; }
        public int Budget { get; set; }
        public int Exp { get; set; }
        public bool Debts { get; set; }
        public Person(string name, string infamily, int budget, int exp, bool debts)
        {
            Name = name;
            InFamily = infamily;
            Budget = budget;
            Exp = exp;
            Debts = debts;
        }
        public Person()
        {

        }
    }
}
