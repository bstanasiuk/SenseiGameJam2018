using UnityEngine;

public class AttackCollisionController : MonoBehaviour
{
    [SerializeField] private bool _isBlack = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isBlack && other.gameObject.tag.Equals("BlackPlayer"))
            UiController.Instance.AddPointForSecondPlayer();
        else if (_isBlack && other.gameObject.tag.Equals("WhitePlayer"))
            UiController.Instance.AddPointForFirstPlayer();
    }
}