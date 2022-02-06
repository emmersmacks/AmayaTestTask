using UnityEngine;
using GridController;
using GameResurses;
using RandomObjects;

namespace LevelControllersScripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        GridController.Grid grid;
        [SerializeField]
        AddItemsForSlots spawnItemsScript;
        [SerializeField]
        GridData gridData;
        [SerializeField]
        RandomizeItem randomScript;
        [SerializeField]
        RestartScript restartScript;

        bool startAnimationSlots;
        int lvlCount;

        public void StartLevel()
        {
            startAnimationSlots = true;
            lvlCount = 0;
            grid.SwitchLvl(lvlCount, startAnimationSlots);
            lvlCount++;
        }

        private void RestartLevels()
        {
            randomScript.existingNumberArr.Clear();
        }

        public void NewLvlSwitch()
        {
            startAnimationSlots = false;
            if (lvlCount < gridData.LvlsGridSize.Length)
            {
                restartScript.CloseRestartPanel();
                DeleteAllPrefabs();
                grid.SwitchLvl(lvlCount, startAnimationSlots);
                lvlCount++;
            }
            else
            {
                restartScript.ShowRestartWindow();
                lvlCount = 0;
            }
        }

        private void DeleteAllPrefabs()
        {
            foreach(GameObject item in gridData.instantiatedEntities)
            {
                Destroy(item);
            }
            gridData.instantiatedEntities.Clear();
        }
    }
}
