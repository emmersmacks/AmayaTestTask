using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RandomObjects
{
    public class RandomizeItem : MonoBehaviour
    {
        public List<int> existingNumberArr = new List<int>();

        public GameObject RandomTopicObj(GameObject[] PicturesObjArr)
        {
            int randomInt = Random.Range(0, PicturesObjArr.Length);
            return PicturesObjArr[randomInt];
        }

        public GameObject RandomItemObj(GameObject topicObj)
        {
            int randomItemInt = 0;
            while (existingNumberArr.Contains(randomItemInt))
            {
                randomItemInt = Random.Range(0, topicObj.transform.childCount);
            }
            existingNumberArr.Add(randomItemInt);
            return topicObj.transform.GetChild(randomItemInt).gameObject;
        }
    }
}

