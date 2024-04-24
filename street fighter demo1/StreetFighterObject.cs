using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace street_fighter_demo1
{
    public class StreetFighterGameObject 
    {
        private string _description;
        private string _name;

        public StreetFighterGameObject(string name, string desc) 
        {
            _description = desc;
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
    }
}

