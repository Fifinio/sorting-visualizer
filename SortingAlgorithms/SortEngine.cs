using System.Collections.Generic;

namespace sorting_visualizer
{
    public interface SortEngine
    {
        void NextStep();
        bool IsSorted();

    }
}