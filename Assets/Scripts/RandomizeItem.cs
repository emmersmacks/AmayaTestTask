using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RandomObjects
{
    public class RandomizeItem : MonoBehaviour
    {
        private static System.Random _random = new System.Random();

        public GameObject RandomTopicObj(GameObject[] picturesObjArr)
            => picturesObjArr[_random.Next(0, picturesObjArr.Length)];

        public List<Sprite> ChooseRandomSprites(List<Sprite> topicObj, int count)
        {
            if (topicObj.Count < count)
            {
                Debug.LogError("Can't get random sprites from topic!");
                return new List<Sprite>();
            }

            var newList = topicObj.ToList();
            var result = new List<Sprite>(count);

            for (int i = 0; i < count; i++)
            {
                var index = Random.Range(0, newList.Count);
                result.Add(newList[index]);
                newList.RemoveAt(index);
            }
            return result;
        }
    }
}

