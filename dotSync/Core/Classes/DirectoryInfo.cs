using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpSync.Core.Classes
{
    class DirectoryInfo
    {
        string _type;
        string _name;
        public string _address;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DirectoryInfo() { }

        public DirectoryInfo(string type, string name, string address)
        {
            Type = type;
            Name = name;
            _address = address;
        }

    }
}
