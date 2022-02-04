using UnityEngine;
using GridController;
using GameResurses;

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

        bool startAnimationSlots;
        int lvlCount;

        private void Start()
        {
            startAnimationSlots = true;
            lvlCount = 0;
            grid.SwitchLvl(lvlCount, startAnimationSlots);
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
