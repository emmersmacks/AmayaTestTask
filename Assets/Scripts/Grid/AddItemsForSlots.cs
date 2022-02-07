using System.Collections.Generic;
using UnityEngine;
using UIElements;
using RandomObjects;
using GameResurses;
using System.Linq;

namespace GridController
{
    public class AddItemsForSlots : MonoBehaviour
    {
        [SerializeField] UITaskText taskTextManager;
        [SerializeField] private GameResursesData _prefDataScript;

        [SerializeField] private RandomizeItem _randomize;
        private List<string> needRotation = new List<string> { "numbers_sprite_7", "numbers_sprite_8" };

        public void ChoiceCorrectAnswer(List<GridSlot> gridSlotsNumber)
        {
            
            var correctObject = gridSlotsNumber[Random.Range(0, gridSlotsNumber.Count - 1)];
            correctObject.SetCorrectAnswer();
            string correctAnswerName = correctObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sprite.name;
            taskTextManager.ChangeTextBar(correctAnswerName);
        }

        public void FillSlots(List<GridSlot> gridSlotsNumber)
        {
            var topic = _prefDataScript.topicDict;
            var spriteTopicList = topic.ElementAt(Random.Range(0, topic.Count)).Value;

            var randomSprites = _randomize.ChooseRandomSprites(spriteTopicList, gridSlotsNumber.Count);

            var index = -1;
            foreach(var randomSprite in randomSprites)
            {
                index++;
                gridSlotsNumber[index].ChangeSprite(randomSprite);
                if (needRotation.Contains(randomSprite.name)) //прошу прощения за это
                {
                    gridSlotsNumber[index].transform.Rotate(0, 0, -90);
                }
                
            }

            ChoiceCorrectAnswer(gridSlotsNumber);
        }

        public void RotationSprite()
        {

        }
    }
}

