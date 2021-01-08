using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class Container
    {     
        public ContainerType Type { get; }
        public int ContainerWeight { get; }

        public Container(ContainerType type, int containerWeight)
        {
            Type = type;
            ContainerWeight = containerWeight;
        }

        public override string ToString()
        {
            return "Containertype: " + Type + " -" + " Container Weight: " + ContainerWeight;
        }
    }
}
