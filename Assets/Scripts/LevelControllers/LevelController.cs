using UnityEngine;
using GridController;
using GameResurses;
using RandomObjects;

namespace LevelControllersScripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GridController.Grid grid;
        [SerializeField] AddItemsForSlots spawnItemsScript;
        [SerializeField] GridData gridData;
        [SerializeField] RandomizeItem randomScript;
        [SerializeField] RestartScript restartScript;

        bool startAnimationSlots;
        int lvlCount;

        public void StartLevel()
        {
            startAnimationSlots = true;
            lvlCount = 0;
            grid.SwitchLvl(lvlCount, startAnimationSlots, gridData);
            lvlCount++;
        }

        public void NewLvlSwitch()
        {
            startAnimationSlots = false;
            if (lvlCount < gridData.LvlsGridSize.Length)
            {
                restartScript.CloseRestartPanel();
                grid.DeleteAllPrefabs();
                grid.SwitchLvl(lvlCount, startAnimationSlots, gridData);
                lvlCount++;
            }
            else
            {
                restartScript.ShowRestartWindow();
                lvlCount = 0;
            }
        }
    }
}
