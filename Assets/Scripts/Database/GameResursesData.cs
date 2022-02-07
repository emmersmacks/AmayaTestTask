using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelControllersScripts;

namespace GameResurses
{
    public class GameResursesData : MonoBehaviour
    {
        [SerializeField] public LevelController lvlControllerScript;
        [SerializeField] public GameObject ParticlePrefab;
        [SerializeField] public Sprite[] texturesItem;

        public Dictionary<string, List<Sprite>> topicDict;
        public List<string> dictKeys;

        private void Start()
        {
            SortingSpriteOfTopic(out topicDict, out dictKeys);
            lvlControllerScript.StartLevel();
        }

        public void SortingSpriteOfTopic(out Dictionary<string, List<Sprite>> cotigories, out List<string> keysOfDict)
        {
            cotigories = new Dictionary<string, List<Sprite>>(texturesItem.Length);
            keysOfDict = new List<string>();
            foreach (Sprite sprite in texturesItem)
            {
                string[] nameArr = sprite.name.Split('_');
                var cotigoryName = nameArr[0];

                if (!cotigories.ContainsKey(cotigoryName))
                {
                    cotigories.Add(cotigoryName, new List<Sprite>());
                    keysOfDict.Add(cotigoryName);
                }
                cotigories[cotigoryName].Add(sprite);
            }
        }

    }
}

