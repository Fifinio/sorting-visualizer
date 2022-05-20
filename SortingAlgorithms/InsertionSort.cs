using System.Collections.Generic;
using System.Linq;

namespace sorting_visualizer
{
    class InsertionSort : SortEngine
    {
        List<byte> list;
        int pointer;
        public InsertionSort(List<byte> list)
        {
            this.list = list;
            this.pointer = 0;
        }
        public bool IsSorted()
        {
            return pointer == list.Count();
        }

        public void NextStep()
        {
            int j = pointer - 1;
            byte key = list[pointer];

            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j = j - 1;
            }
            list[j + 1] = key;
            pointer++;
        }
    }
}