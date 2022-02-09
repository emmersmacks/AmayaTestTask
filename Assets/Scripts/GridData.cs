using UnityEngine;
using System.Collections.Generic;

namespace GameResurses
{
    public class GridData
    {
        public List<GridSlot> instantiatedSlots = new List<GridSlot>();

        public GridSize[] LevelsGridSize;

        public GridData()
        {
            LevelsGridSize = new GridSize[] 
            {
                new GridSize(1,3),
                new GridSize(2,3),
                new GridSize(3,3),
            };
        }
    }

    public class GridSize
    {
        public int ColumnsCount;
        public int RowsCount;

        public GridSize(int numberRow, int numberColumn)
        {
            this.ColumnsCount = numberColumn;
            this.RowsCount = numberRow;
        }
    }
}

