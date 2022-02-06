using System.Collections.Generic;
using UnityEngine;
using UIElements;
using RandomObjects;
using GameResurses;

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
        [SerializeField]
        PrefabsData prefDataScript;

        public void ChoiceCorrectAnswer(List<GameObject> gridSlotsNumber)
        {
            GameObject correctObj = gridSlotsNumber[Random.Range(1, gridSlotsNumber.Count)];
            GameObject itemObj = correctObj.transform.GetChild(0).gameObject;
            correctObj.tag = "CorrectAnswer";
            TaskTextManager.ChangeTextBar();
        }

        public void FillSlots(List<GameObject> gridSlotsNumber)
        {
            string randomTopic = prefDataScript.dictKeys[Random.Range(0, prefDataScript.dictKeys.Count -1)];
            List<Sprite> spriteTopicList = prefDataScript.topicDict[randomTopic];
            randomize.FillingSheetOfIndexRandom(spriteTopicList);
            for (int countSlot = 0; countSlot < gridSlotsNumber.Count; countSlot++)
            {
                gridSlotsNumber[countSlot].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = randomize.RandomItemObj(spriteTopicList);
            }
            randomize.existingNumberArr.Clear();
            ChoiceCorrectAnswer(gridSlotsNumber);
        }
    }
}

