using System;
using System.Collections.Generic;
using System.Text;

namespace LookUpTypes
{
    class LookUp
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public LookUpType Lookuptype { get; set; }

        public LookUp(int id , string code , string name , LookUpType lookuptype)
        {
            Id = id;
            Code = code;
            Name = name;

            Lookuptype = new LookUpType(lookuptype.Id, lookuptype.Name);
           
        }

    }
}
