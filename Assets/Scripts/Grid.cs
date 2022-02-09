using UnityEngine;
using GameResurses;
using DG.Tweening;
using System.Collections.Generic;

namespace GridController
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private GameObject _instantiateObject;
        private bool _startAnimationPref;
        private GridSize _gridSize;

        public void StartLevel(GridSize gridSize, bool startMakePrefAnimation)
        {
            _gridSize = gridSize;
            _startAnimationPref = startMakePrefAnimation;

            GridTransform();
        }

        private void GridTransform()
        {
            var offsetByY = _gridSize.RowsCount * -0.5f + 0.5f;
            var offsetByX = _gridSize.ColumnsCount * -0.5f + 0.5f;

            transform.position = new Vector2(offsetByX, offsetByY);
        }

        private GridSlot InstantiateSlot(int x, int y)
        {
            var gridSlot = Instantiate(_instantiateObject, Vector3.zero, Quaternion.identity, transform)
                .GetComponent<GridSlot>();

            gridSlot.transform.localPosition = new Vector2(x, y);

            if (_startAnimationPref)
                StartSpawnAnimation(gridSlot.transform);

            return gridSlot;
        }

        public IEnumerable<GridSlot> InstantiateSlots()
        {
            for (int x = 0; x < _gridSize.ColumnsCount; x++)
                for (int y = 0; y < _gridSize.RowsCount; y++)
                    yield return InstantiateSlot(x, y);
        }

        public void StartSpawnAnimation(Transform slot) => slot.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
    }
}