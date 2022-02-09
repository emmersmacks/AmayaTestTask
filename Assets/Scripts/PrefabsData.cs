using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelControllersScripts;

namespace GameResurses
{
    public class PrefabsData : MonoBehaviour
    {
        [SerializeField] public LevelController lvlControllerScript;
        [SerializeField] public GameObject ParticlePrefab;
        [SerializeField] public Sprite[] texturesItem;

        public Dictionary<string, List<Sprite>> topicDict;

        private void Start()
        {
            SortingSpriteOfTopic(out topicDict);
            lvlControllerScript.StartLevel();
        }

        public void SortingSpriteOfTopic(out Dictionary<string, List<Sprite>> cotigories)
        {
            cotigories = new Dictionary<string, List<Sprite>>(texturesItem.Length);
            foreach (Sprite sprite in texturesItem)
            {
                string[] nameArr = sprite.name.Split('_');
                var cotigoryName = nameArr[0];

                if (!cotigories.ContainsKey(cotigoryName))
                {
                    cotigories.Add(cotigoryName, new List<Sprite>());
                }

                cotigories[cotigoryName].Add(sprite);
            }
        }

    }
}

