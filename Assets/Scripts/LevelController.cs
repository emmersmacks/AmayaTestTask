using UnityEngine;
using GridController;
using GameResurses;
using RandomObjects;

namespace LevelControllersScripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GridController.Grid _grid;
        [SerializeField] private RestartScript _restartScript;
        [SerializeField] private AddItemsForSlots _spawnItemsScript;


        private RandomizeItem _randomScript = new RandomizeItem();
        private bool _startAnimationSlots;
        private int _levelCount;
        private GridData _gridData = new GridData();

        public void StartLevel()
        {
            _startAnimationSlots = true;
            _levelCount = 0;
            _grid.StartLevel(_gridData.LevelsGridSize[_levelCount], _startAnimationSlots);
            _gridData.instantiatedSlots.AddRange(_grid.InstantiateSlots());
            _spawnItemsScript.FillSlots(_gridData.instantiatedSlots);
            _levelCount++;
        }

        public void NewLevelSwitch()
        {
            _startAnimationSlots = false;
            if (_levelCount < _gridData.LevelsGridSize.Length)
            {
                _restartScript.CloseRestartPanel();
                DeleteAllPrefabs();
                _grid.StartLevel(_gridData.LevelsGridSize[_levelCount], _startAnimationSlots);
                _gridData.instantiatedSlots.AddRange(_grid.InstantiateSlots());
                _spawnItemsScript.FillSlots(_gridData.instantiatedSlots);
                _levelCount++;
            }
            else
            {
                _restartScript.ShowRestartWindow();
                _levelCount = 0;
            }
        }

        private void DeleteAllPrefabs()
        {
            foreach (var item in _gridData.instantiatedSlots)
            {
                Destroy(item.gameObject);
            }
            _gridData.instantiatedSlots.Clear();
        }
    }
}
