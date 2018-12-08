using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    [SerializeField] private bool _isBlack = false;
    private Animator _playerAnimator;

    private Vector2 _lastPosition;
    
    public AudioSource hitSound;
    public GameObject blood;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 currectPosition = transform.parent.position;
        //if (currectPosition != _lastPosition)
        var velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
        if (Math.Abs(velocity.x) > 0.01)
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
        {
            hitSound.Play();
            BloodDisplay();
            UiController.Instance.AddPointForSecondPlayer();
            
        }
        else if (_isBlack && other.gameObject.tag.Equals("WhitePlayer"))
        {
            hitSound.Play();
            BloodDisplay();
            UiController.Instance.AddPointForFirstPlayer();
            
        }
    }

    public void PlayAttackAnimation()
    {
        _playerAnimator.SetTrigger("AttackTrigger");
    }

    private void BloodDisplay()
    {
        blood.SetActive(true);
    }
}
