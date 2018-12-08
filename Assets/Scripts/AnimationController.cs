﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    [SerializeField] private bool _isBlack = false;
    private Animator _playerAnimator;

    private Vector2 _lastPosition;
    
    public AudioSource hitSound;

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
        {
            hitSound.Play();
            UiController.Instance.AddPointForSecondPlayer();
        }
        else if (_isBlack && other.gameObject.tag.Equals("WhitePlayer"))
        {
            hitSound.Play();
            UiController.Instance.AddPointForFirstPlayer();
        }
    }

    public void PlayAttackAnimation()
    {
        _playerAnimator.SetTrigger("AttackTrigger");
    }
}
