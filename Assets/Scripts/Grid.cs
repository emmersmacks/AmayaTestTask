
using UnityEngine;
using GameResurses;
using System.Collections.Generic;
using DG.Tweening;

namespace GridController
{
    public class Grid : MonoBehaviour
    {

        [SerializeField]
        AddItemsForSlots spawnItemsScript;

        [SerializeField]
        private GameObject instantiateObject;

        private int NumberOfSlots;

        private int[,] gridPrefCoord;
        private bool startAnimationPref;

        private int CurrentLvl;
        private int CurrentlvlRows;
        private int CurrentlvlColumn;

        [SerializeField]
        GridData gridData;

        private void Start()
        {
            
        }

        void MakeGrid()
        {
            int countSlots = 0;
            for (int lvlRows = 0; lvlRows < CurrentlvlRows; lvlRows++)
            {
                for (int lvlColumn = 0; lvlColumn < CurrentlvlColumn; lvlColumn++)
                {
                    gridPrefCoord[countSlots, 0] = lvlColumn;
                    gridPrefCoord[countSlots, 1] = lvlRows;
                    countSlots++;
                }
            }
        }

        private void GridTransform()
        {
            float offsetByY = CurrentlvlRows * (float) -0.5;
            transform.position = new Vector2(transform.position.x, offsetByY);
        }

        public void SwitchLvl(int newLvl, bool startMakePrefAnimation)
        {
            startAnimationPref = startMakePrefAnimation;
            CurrentLvl = newLvl;
            CurrentlvlRows = gridData.LvlsGridSize[CurrentLvl].numberRow;
            CurrentlvlColumn = gridData.LvlsGridSize[CurrentLvl].numberColumn;
            NumberOfSlots = CurrentlvlRows * CurrentlvlColumn;
            gridPrefCoord = new int[NumberOfSlots, 2];
            MakeGrid();
            InstantiateEntities();
            GridTransform();
            spawnItemsScript.FillSlots(gridData.instantiatedEntities);
        }

        private void InstantiateEntity(int x, int y)
        {
            GameObject instantiateObj = Instantiate(instantiateObject, new Vector2(x, y), Quaternion.identity);
            instantiateObj.transform.parent = transform;
            if(startAnimationPref)
                StartSpawnAnimation(instantiateObj.transform);
            gridData.instantiatedEntities.Add(instantiateObj);
        }

        private void InstantiateEntities()
        {
            for (int i = 0; i < NumberOfSlots; i++)
            {
                int coordX = gridPrefCoord[i, 0];
                int coordY = gridPrefCoord[i, 1];
                InstantiateEntity(coordX, coordY);
            }
        }

        public void StartSpawnAnimation(Transform slot)
        {
            slot.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
        }
    }
    
}
