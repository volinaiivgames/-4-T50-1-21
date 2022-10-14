using System;
using System.Collections.Generic;
using System.Text;

namespace practic4
{
    class Page
    {
        public string Name { get; set; }
        public List<string> Description { get; set; }
        public Page(string name, List<string> description)
        {
            Name = name;
            Description = description;
        }
    }
}
