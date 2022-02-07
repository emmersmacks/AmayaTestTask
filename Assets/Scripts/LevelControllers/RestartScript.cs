using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace LevelControllersScripts
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] GameObject restartPlat;
        [SerializeField] LevelController lvlControllerScript;
        [SerializeField] TouchEvent eventScript;

        public void ShowRestartWindow()
        {
            restartPlat.SetActive(true);
            restartPlat.GetComponent<Image>().DOFade(0.5f, 0.1f);
            restartPlat.transform.GetChild(0).gameObject.SetActive(true);
            eventScript.StopInteractScript(false);
        }

        public void RestartGame()
        {
            StartCoroutine(WaitDOTweenAnimation());
        }

        public void CloseRestartPanel()
        {
            restartPlat.SetActive(false);
            eventScript.StopInteractScript(true);
        }

        IEnumerator WaitDOTweenAnimation()
        {
            restartPlat.transform.GetChild(0).gameObject.SetActive(false);
            restartPlat.GetComponent<Image>().DOFade(1f, 0.1f);
            yield return new WaitForSeconds(2f);
            lvlControllerScript.NewLvlSwitch();

        }
    }
}

