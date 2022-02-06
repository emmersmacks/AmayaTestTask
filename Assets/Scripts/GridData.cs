using UnityEngine;
using System.Collections.Generic;

namespace GameResurses
{
    public class GridData
    {
        public List<GameObject> instantiatedEntities;

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

