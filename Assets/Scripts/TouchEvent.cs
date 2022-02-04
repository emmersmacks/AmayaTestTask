using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LevelControllersScripts;

public class TouchEvent : MonoBehaviour
{
    [SerializeField]
    private LevelController lvlControllerScript;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit2D = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit2D.transform != null)
            {
                if (hit2D.transform.gameObject.tag == "CorrectAnswer")
                {
                    CorrectAnswerAnimation(hit2D.transform);
                    lvlControllerScript.NewLvlSwitch();
                }
                    
                else if(hit2D.transform.gameObject.tag == "WrongAnswer")
                    WrongAnswerAnimation(hit2D.transform);
            }
        }
    }

    private void WrongAnswerAnimation(Transform hitTransform)
    {
        hitTransform.DOShakePosition(0.5f, new Vector3(0.2f, 0, 0));
    }
    private void CorrectAnswerAnimation(Transform hitTransform)
    {
        hitTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
    }
}
