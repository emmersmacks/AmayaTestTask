using System.Collections.Generic;
using UnityEngine;
using UIElements;
using RandomObjects;

namespace GridController
{
    public class AddItemsForSlots : MonoBehaviour
    {
        [SerializeField]
        GameObject[] ItemsCaseObj;
        [SerializeField]
        GridController.Grid grid;
        [SerializeField]
        UITaskText TaskTextManager;
        [SerializeField]
        RandomizeItem randomize;

        public void ChoiceCorrectAnswer(List<GameObject> gridSlotsNumber)
        {
            GameObject correctObj = gridSlotsNumber[Random.Range(1, gridSlotsNumber.Count)];
            GameObject itemObj = correctObj.transform.GetChild(0).gameObject;
            correctObj.tag = "CorrectAnswer";
            TaskTextManager.ChangeTextBar(itemObj.name);
        }

        public void FillSlots(List<GameObject> gridSlotsNumber)
        {
            GameObject randomTopic = randomize.RandomTopicObj(ItemsCaseObj);

            for (int i = 0; i < gridSlotsNumber.Count; i++)
            {
                GameObject obtainedItem = randomize.RandomItemObj(randomTopic);
                var spawnPosition = new Vector3(gridSlotsNumber[i].transform.position.x, gridSlotsNumber[i].transform.position.y, -1);
                GameObject obtainedItemPref = Instantiate(obtainedItem, spawnPosition, Quaternion.identity);
                obtainedItemPref.transform.parent = gridSlotsNumber[i].transform;
            }
            ChoiceCorrectAnswer(gridSlotsNumber);
        }
    }
}

