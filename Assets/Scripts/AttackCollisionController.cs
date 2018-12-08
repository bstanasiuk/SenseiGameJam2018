using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] private bool _isBlack = false;
    private Animator _playerAnimator;

    private Vector2 _lastPosition;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 currectPosition = transform.parent.position;
        if (currectPosition != _lastPosition)
        {
            _playerAnimator.SetTrigger("WalkTrigger");
        }
        else
        {
            _playerAnimator.SetTrigger("IdleTrigger");
        }
        _lastPosition = currectPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isBlack && other.gameObject.tag.Equals("BlackPlayer"))
            UiController.Instance.AddPointForSecondPlayer();
        else if (_isBlack && other.gameObject.tag.Equals("WhitePlayer"))
            UiController.Instance.AddPointForFirstPlayer();
    }

    public void PlayAttackAnimation()
    {
        _playerAnimator.SetTrigger("AttackTrigger");
    }
}