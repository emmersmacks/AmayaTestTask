using UnityEngine;
using GameResurses;
using DG.Tweening;

namespace GridController
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private AddItemsForSlots _spawnItemsScript;
        [SerializeField] private GameObject _instantiateObject;

        private bool _startAnimationPref;

        private SizeGrid _gridSize;
        private GridData _gridData;

        private void GridTransform()
        {
            var offsetByY = _gridSize.RowsCount * -0.5f + 0.5f;
            var offsetByX = _gridSize.ColumnsCount * - 0.5f + 0.5f;

            transform.position = new Vector2(offsetByX, offsetByY);
        }

        public void SwitchLevel(int newLevel, bool startMakePrefAnimation, GridData gridData)
        {
            _gridData = gridData;
            _gridSize = gridData.LevelsGridSize[newLevel];
            _startAnimationPref = startMakePrefAnimation;
            
            InstantiateSlots();
            GridTransform();

            _spawnItemsScript.FillSlots(gridData.instantiatedSlots);
        }

        private void InstantiateSlot(int x, int y)
        {
            var gridSlot = Instantiate(_instantiateObject, Vector3.zero, Quaternion.identity, transform)
                .GetComponent<GridSlot>();

            gridSlot.transform.localPosition = new Vector2(x, y);
            
            if (_startAnimationPref)
                StartSpawnAnimation(gridSlot.transform);

            _gridData.instantiatedSlots.Add(gridSlot);
        }

        private void InstantiateSlots()
        {
            for (int x = 0; x < _gridSize.ColumnsCount; x++)
                for (int y = 0; y < _gridSize.RowsCount; y++)
                    InstantiateSlot(x, y);
        }

        public void StartSpawnAnimation(Transform slot)
        {
            slot.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
        }
    }
}