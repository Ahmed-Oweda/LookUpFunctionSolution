using System;
using System.Collections.Generic;
using System.Text;

namespace LookUpTypes
{
    class PodFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<LookUpType> LookUpTypes { get; set; }

        public PodFeature(int id , string name)
        {
            Id = id;
            Name = name;
        }
   
    }
}
