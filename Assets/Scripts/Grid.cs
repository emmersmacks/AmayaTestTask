using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameResurses;

namespace GridController
{
    public class Grid : MonoBehaviour
    {
    

        protected int levelCount;
        GridData gridData = new GridData();

        int NumberOfLvl;
        public int NumberOfSlots;

        public float[,] gridPrefCoord;

        int CurrentLvl;
        [SerializeField]
        int CurrentlvlRows;
        int CurrentlvlColumn;

        void Update()
        {
            MakeGrid();
        }

        void MakeGrid()
        {
            int countSlots = 0;
            for (int lvlRows = 0; lvlRows < CurrentlvlColumn; lvlRows++)
            {
                for (int lvlColumn = 0; lvlColumn < CurrentlvlRows; lvlColumn++)
                {
                    Debug.Log(1);
                    gridPrefCoord[countSlots, 0] = lvlColumn;
                    gridPrefCoord[countSlots, 1] = lvlRows;
                    countSlots++;
                }
            }
        }

        public void SwitchLvl(int newLvl)
        {
            CurrentLvl = newLvl;
            CurrentlvlRows = gridData.LvlsGridSize[CurrentLvl, 0];
            CurrentlvlColumn = gridData.LvlsGridSize[CurrentLvl, 1];
            NumberOfSlots = CurrentlvlRows * CurrentlvlColumn;
            gridPrefCoord = new float[NumberOfSlots, 2];
        }
    }
    
}
