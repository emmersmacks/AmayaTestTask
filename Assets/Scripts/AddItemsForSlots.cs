using System.Collections.Generic;
using UnityEngine;
using RandomObjects;
using GameResurses;
using System.Linq;

namespace GridController
{
    public class AddItemsForSlots : MonoBehaviour
    {
        [SerializeField] private PrefabsData _prefDataScript;

        private RandomizeItem _randomize = new RandomizeItem();
        public void ChoiceCorrectAnswer(List<GridSlot> gridSlotsNumber)
        {
            gridSlotsNumber[Random.Range(0, gridSlotsNumber.Count - 1)].SetCoccretAnswer();
        }

        public void FillSlots(List<GridSlot> gridSlotsNumber)
        {
            var topics = _prefDataScript.topicDict;
            var spriteTopicList = topics.ElementAt(Random.Range(0, topics.Count)).Value;

            var randomSprites = _randomize.ChooseRandomSprites(spriteTopicList, gridSlotsNumber.Count);

            var index = -1;
            foreach (var randomSprite in randomSprites)
            {
                index++;
                gridSlotsNumber[index].ChangeSprite(randomSprite);
            }

            ChoiceCorrectAnswer(gridSlotsNumber);
        }
    }
}

