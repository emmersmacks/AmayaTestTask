using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridController
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField]
        protected GameObject instantiateObject;

        Grid grid = new Grid();

        float coordX;
        float coordY;

        private void Update()
        {
            for (int i = 0; i < grid.NumberOfSlots; i++)
            {
                coordX = grid.gridPrefCoord[i, 0];
                coordY = grid.gridPrefCoord[i, 1];
                Instantiate(instantiateObject, new Vector3(coordX, coordY, 1f), Quaternion.identity);
            }
        }
    }
}

