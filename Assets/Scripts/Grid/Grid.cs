
using UnityEngine;
using GameResurses;
using System.Collections.Generic;
using DG.Tweening;

namespace GridController
{
    public class Grid : MonoBehaviour
    {

        [SerializeField] private AddItemsForSlots spawnItemsScript;
        [SerializeField] private GameObject instantiateObject;

        private bool startAnimationPref;

        private SizeGrid _gridSize;
        private GridData _gridData;

        private void GridTransform()
        {
            float offsetByY = _gridSize.numberRow * -0.5f + 0.5f;
            float offsetByX = _gridSize.numberColumn * - 0.5f + 0.5f;
            transform.position = new Vector2(offsetByX, offsetByY);
        }

        public void SwitchLvl(int newLvl, bool startMakePrefAnimation, GridData gridData)
        {
            startAnimationPref = startMakePrefAnimation;

            _gridSize = gridData.LvlsGridSize[newLvl];
            _gridData = gridData;

            InstantiateEntities();
            GridTransform();

            spawnItemsScript.FillSlots(_gridData.instantiatedSlots);
        }

        private void InstantiateEntity(int x, int y)
        {
            var instantiateSlot = Instantiate(instantiateObject, Vector3.zero, Quaternion.identity, transform).GetComponent<GridSlot>(); ;
            instantiateSlot.transform.localPosition = new Vector2(x,y);

            if (startAnimationPref)
                StartSpawnAnimation(instantiateSlot.transform);
            _gridData.instantiatedSlots.Add(instantiateSlot);
        }

        private void InstantiateEntities()
        {
            for (int x = 0; x < _gridSize.numberColumn; x++)
                for (int y = 0; y < _gridSize.numberRow; y++)
                    InstantiateEntity(x, y);
        }

        public void StartSpawnAnimation(Transform slot)
        {
            slot.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
        }

        public void DeleteAllPrefabs()
        {
            foreach (var item in _gridData.instantiatedSlots)
            {
                Destroy(item.transform.gameObject);
            }
            _gridData.instantiatedSlots.Clear();
        }
    }
    
}
