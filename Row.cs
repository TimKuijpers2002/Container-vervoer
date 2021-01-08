using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class Row
    {
        private const int MaxStackWeight = 150;

        private int CurrentWeight;
        public List<Container> containerList { get; }
        public int[] stacks { get; }
        public int Length { get; }
        public Row(int length)
        {
            Length = length;
        }

        public bool TryAddContainer(Container container)
        {
            foreach(ContainerType suit in (ContainerType[])Enum.GetValues(typeof(ContainerType)))
            {
                if (container.Type == suit && ((CurrentWeight + container.ContainerWeight) <= MaxStackWeight))
                {
                    containerList.Add(container);
                    CurrentWeight += container.ContainerWeight;
                    //CurrentStackWeight += containerToAdd.ContainerWeight;
                    return true;
                }
                else if (CurrentWeight >= MaxStackWeight)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
