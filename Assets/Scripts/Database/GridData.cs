using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameResurses
{
    public class GridData: MonoBehaviour
    {
        public List<GridSlot> instantiatedSlots = new List<GridSlot>();

        public SizeGrid[] LvlsGridSize;

        public GridData()
        {
            LvlsGridSize = new SizeGrid[]
            {
                new SizeGrid(1,3),
                new SizeGrid(2,3),
                new SizeGrid(3,3),
            };
        }
    }

    public class SizeGrid
    {
        public int numberColumn;
        public int numberRow;

        public SizeGrid(int numberRow, int numberColumn)
        {
            this.numberColumn = numberColumn;
            this.numberRow = numberRow;
        }
    }
}
