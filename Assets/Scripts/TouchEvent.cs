using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LevelControllersScripts;
using GameResurses;

public class TouchEvent : MonoBehaviour
{
    [SerializeField]
    private LevelController lvlControllerScript;
    [SerializeField]
    private PrefabsData prefabsDataScript;
    Tween DotweenAnimation;
    private bool canInteract = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            var rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit2D = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit2D.transform != null)
            {
                if (hit2D.transform.gameObject.tag == "CorrectAnswer")
                {
                    CorrectAnswerAnimation(hit2D.transform);
                    StartCoroutine(WaitParticleAnimation(hit2D.transform));
                }
                else if (hit2D.transform.gameObject.tag == "WrongAnswer")
                    WrongAnswerAnimation(hit2D.transform);
            }
        }
    }

    private void WrongAnswerAnimation(Transform hitTransform)
    {
        DotweenAnimation = hitTransform.DOShakePosition(0.5f, new Vector3(0.2f, 0, 0));
    }
    private void CorrectAnswerAnimation(Transform hitTransform)
    {
        DotweenAnimation = hitTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1, 2, 3f);
    }

    IEnumerator WaitParticleAnimation(Transform hitPosition)
    {
        GameObject instantiateObjParticle = Instantiate(prefabsDataScript.ParticlePrefab, new Vector2(hitPosition.position.x, hitPosition.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(instantiateObjParticle);
        lvlControllerScript.NewLvlSwitch();

    }

    public void StopInteractScript(bool isInteract)
    {
        canInteract = isInteract;
    }
}
