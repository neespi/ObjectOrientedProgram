using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.DomainObjects
{
  public class BridgesPoint : DomainObject
    {
  
        public string Name { get; set; }

        public string Location { get; set; }

        public string CrossRiver { get; set; }

        public string Year { get; set; }
    
    }
}
