using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RandomObjects
{
    public class RandomizeItem
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

            var temp = topicObj.ToList();
            var result = new List<Sprite>(count);

            for (int i = 0; i < count; i++)
            {
                var index = _random.Next(0, temp.Count - 1);
                result.Add(temp[index]);
                temp.RemoveAt(index);
            }

            return result;
        }
    }
}

