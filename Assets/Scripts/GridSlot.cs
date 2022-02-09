using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridSlot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRender;

    private bool _isCorrectAnswer;

    public bool IsCorrectAnswer => _isCorrectAnswer;

    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void SetCurretAnswer()
    {
        if (_isCorrectAnswer)
        {
            Debug.LogError("This answer is already correct!");
            return;
        }

        _isCorrectAnswer = true;
    }

    public void ChangeSprite(Sprite sprite)
    {
        _spriteRender.sprite = sprite;
    }
}
