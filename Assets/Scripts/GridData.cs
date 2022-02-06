using UnityEngine;
using System.Collections.Generic;

namespace GameResurses
{
    public class GridData
    {
        public List<GridSlot> instantiatedSlots = new List<GridSlot>();

        public SizeGrid[] LevelsGridSize;

        public GridData()
        {
            LevelsGridSize = new SizeGrid[] 
            {
                new SizeGrid(1,3),
                new SizeGrid(2,3),
                new SizeGrid(3,3),
            };
        }
    }

    public class SizeGrid
    {
        public int ColumnsCount;
        public int RowsCount;

        public SizeGrid(int numberRow, int numberColumn)
        {
            this.ColumnsCount = numberColumn;
            this.RowsCount = numberRow;
        }
    }
}

