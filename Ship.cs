using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class Ship
    {
        private List<Container> containerList = new List<Container>();
        private List<Row> rowList = new List<Row>();

        public int CurrentWeight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int MinimumWeight { get; set; }
        public int MaximalWeight { get; set; }

        public Ship(int lenght, int width)
        {
            Length = lenght;
            Width = width;
            MaximalWeight = (lenght * width) * 150;
            MinimumWeight = MaximalWeight / 2;
        }

        public override string ToString()
        {
            return "Length:" + Length + " Containers" + "   Width:" + Width + " Containers";
        }

        public void AddContainerToShip(Container container)
        {
            containerList.Add(container);
        }

        public void AddNewRow()
        {
            rowList.Add(new Row(Length));
        }

        public void AssignRow()
        {
            if(rowList == null)
            {
                AddNewRow();
            }

            foreach(var container in containerList)
            {
                for (int index = 0; index < rowList.Count; index++)
                {
                    if (rowList[index].TryAddContainer(container))
                    {
                        continue;
                    }
                    else
                    {
                        if (index == rowList.Count - 1)
                        {
                            if (rowList.Count < Width)
                            {
                                AddNewRow();
                                rowList[rowList.Count - 1].TryAddContainer(container);
                                break;
                            }
                            else
                            {
                                throw new Exception("ApplicationErrorFlag: CreatedTooMuchContainers");
                            }

                        }

                    }
                }
            }
            
        }
    }
}
