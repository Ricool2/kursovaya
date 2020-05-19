using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours
{
    public class Family
    {
        public string LastName { get; set; }
        public int MonthBud { get; set; }
        public List<Person> Persons { get; set; }
        public int Count
        {
            get
            {
                if (Persons == null)
                    return 0;
                else return Persons.Count;
            }
        }
        public Family(string lastname, int monthbud, List<Person> persons)
        {
            LastName = lastname;
            MonthBud = monthbud;
            Persons = persons;
        }
        public Family()
        {
            
        }
    }
}
