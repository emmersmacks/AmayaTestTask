using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LevelControllersScripts;
using GameResurses;

public class TouchEvent : MonoBehaviour
{
    [SerializeField] private LevelController _lvlControllerScript;
    [SerializeField] private PrefabsData _prefabsDataScript;

    private bool _canInteract = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canInteract)
        {
            var rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit2D = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit2D.transform == null)
                return;

            var gridSlot = hit2D.transform.GetComponent<GridSlot>();

            if (gridSlot == null)
                return;

            if (gridSlot.IsCorrectAnswer)
            {
                CorrectAnswerAnimation(hit2D.transform);
                StartCoroutine(WaitAndSwitchLevel(hit2D.transform));
            }
            else
            {
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

    IEnumerator WaitAndSwitchLevel(Transform hitPosition)
    {
        var instantiateObjParticle = Instantiate(_prefabsDataScript.ParticlePrefab,
            hitPosition.position.GetXYVector2(),
            Quaternion.identity);

        yield return new WaitForSeconds(2f);
        Destroy(instantiateObjParticle);
        _lvlControllerScript.NewLevelSwitch();
    }

    public void StopInteractScript(bool isInteract)
    {
        _canInteract = isInteract;
    }
}

public static class Vector3Extinstions
{
    public static Vector2 GetXYVector2(this Vector3 source)
        => new Vector2(source.x, source.y);
}
