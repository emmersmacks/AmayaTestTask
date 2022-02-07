using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridSlot : MonoBehaviour
{
    private bool _isCorrectAnswer;
    public bool IsCorrectAnswer => _isCorrectAnswer;
    [SerializeField] private SpriteRenderer _spriteRender;

    public void SetCorrectAnswer()
    {
        _isCorrectAnswer = true;
    }

    public void ChangeSprite(Sprite sprite)
    {
        _spriteRender.sprite = sprite;
    }
}
