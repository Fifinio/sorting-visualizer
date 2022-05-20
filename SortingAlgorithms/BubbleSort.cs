using System.Collections.Generic;

namespace sorting_visualizer
{
    public class BubbleSort : SortEngine
    {
        int pointer = 0;
        List<byte> list;
        public BubbleSort(List<byte> list)
        {
            this.list = list;
        }

        public void NextStep()
        {
            if (pointer < list.Count - 1)
            {
                if (list[pointer] > list[pointer + 1])
                {
                    byte temp = list[pointer];
                    list[pointer] = list[pointer + 1];
                    list[pointer + 1] = temp;
                }
                pointer++;
            }
            else
            {
                pointer = 0;
            }
        }

        public bool IsSorted()
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}