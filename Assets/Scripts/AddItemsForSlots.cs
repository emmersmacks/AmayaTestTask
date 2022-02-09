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
        [SerializeField] private Transform _currentAnswerPosition;


        private RandomizeItem _randomize = new RandomizeItem();
        public void ChoiceCorrectAnswer(List<GridSlot> gridSlotsNumber)
        {
            var slot = gridSlotsNumber[Random.Range(0, gridSlotsNumber.Count - 1)];
            slot.SetCurretAnswer();

            gridSlotsNumber.Add(Instantiate(slot, _currentAnswerPosition).GetComponent<GridSlot>());
        }

        public void FillSlots(List<GridSlot> gridSlotsNumber)
        {
            var topics = _prefDataScript.topicDict;
            var spriteTopicList = topics.ElementAt(Random.Range(0, topics.Count)).Value;

            var randomSprites = _randomize.ChooseRandomSprites(spriteTopicList, gridSlotsNumber.Count);

            ChoiceCorrectAnswer(gridSlotsNumber);

            var index = -1;
            foreach (var randomSprite in randomSprites)
            {
                index++;
                gridSlotsNumber[index].ChangeSprite(randomSprite);
            }
        }
    }
}

