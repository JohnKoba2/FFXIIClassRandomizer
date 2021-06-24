using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIIJobRandomizer.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Main { get; set; }
        public string Sub { get; set; }
        public string Equipment { get; set; }
        
        public string Weapon { get; set; }

        public Character(string name, String main, String sub, String equipment)
        {
            Name = name;
            Main = main;
            Sub = sub;
            Equipment = equipment;
            
        }
    }
}
