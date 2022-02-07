using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace UIElements
{
    public class UITaskText : MonoBehaviour
    {
        [SerializeField] Text taskText;

        private void Start()
        {
            StartShowTextBar();  
        }

        public void ChangeTextBar(string newText)
        {
            taskText.text = FindAnswerName(newText);
        }

        public void StartShowTextBar()
        {
            taskText.color = new Color(taskText.color.r, taskText.color.g, taskText.color.b, 0);
            taskText.DOFade(1f, 0.5f);
        }

        public string FindAnswerName(string answerPrefabName)
        {
            if(answerPrefabName.Contains("_"))
            {
                string[] nameArr = answerPrefabName.Split('_');
                string correctName = nameArr[2];
                return "Find " + correctName;
            }
            else
            {
                throw new Exception("The texture name is missing the '_' separator. Please add it. An example name: texture_nameingame");
            }    
        }
    }
}

