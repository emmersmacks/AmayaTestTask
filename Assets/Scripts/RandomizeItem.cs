using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RandomObjects
{
    public class RandomizeItem : MonoBehaviour
    {
        public List<int> existingNumberArr = new List<int>();

        private void Start()
        {
            
        }

        public GameObject RandomTopicObj(GameObject[] PicturesObjArr)
        {
            int randomInt = Random.Range(0, PicturesObjArr.Length);
            return PicturesObjArr[randomInt];
        }

        public void FillingSheetOfIndexRandom(List<Sprite> topicObj)
        {
            for (int i = 0; i < topicObj.Count; i++)
            {
                existingNumberArr.Add(i);
            }
        }

        public Sprite RandomItemObj(List<Sprite> topicObj)
        {
            int randomItemInt = Random.Range(0, existingNumberArr.Count - 1);
            int index = existingNumberArr[randomItemInt];
            Sprite selectedObj = topicObj[index];
            existingNumberArr.RemoveAt(randomItemInt);
            return selectedObj;
        }
    }
}

