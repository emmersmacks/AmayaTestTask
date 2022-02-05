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

        bool startAnimationSlots;
        int lvlCount;

        private void Start()
        {
            startAnimationSlots = true;
            lvlCount = 0;
            grid.SwitchLvl(lvlCount, startAnimationSlots);
        }

        private void RestartLevels()
        {
            randomScript.existingNumberArr.Clear();
        }

        public void NewLvlSwitch()
        {
            startAnimationSlots = false;
            DeleteAllPrefabs();
            lvlCount++;
            grid.SwitchLvl(lvlCount, startAnimationSlots);
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
