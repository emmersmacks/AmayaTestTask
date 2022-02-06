using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace LevelControllersScripts
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] private GameObject _restartPanel;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private LevelController _lvlControllerScript;
        [SerializeField] private TouchEvent _eventScript;

        public void ShowRestartWindow()
        {
            _restartPanel.SetActive(true);
            _restartPanel.GetComponent<Image>().DOFade(0.5f, 0.1f);

            _restartButton.SetActive(true);
            _eventScript.StopInteractScript(false);
        }

        public void RestartGame()
        {
            StartCoroutine(WaitDOTweenAnimation());
        }

        public void CloseRestartPanel()
        {
            _restartPanel.SetActive(false);
            _eventScript.StopInteractScript(true);
        }

        private IEnumerator WaitDOTweenAnimation()
        {
            _restartButton.SetActive(false);
            _restartPanel.GetComponent<Image>().DOFade(1f, 0.1f);
            yield return new WaitForSeconds(2f);
            _lvlControllerScript.NewLevelSwitch();
        }
    }
}

