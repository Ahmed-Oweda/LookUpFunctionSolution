using System;
using System.Collections.Generic;
using System.Text;

namespace LookUpTypes
{
    class LookUpType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LookUpType(int id , string name)
        {
            Id = id;
            Name = name;
        }

        public LookUpType()
        {
        }
    }
}
