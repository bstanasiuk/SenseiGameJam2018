using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private bool _isBlack;

    private Vector2 _lastPosition;
    private Animator _playerAnimator;
    public GameObject blood;

    public AudioSource hitSound;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        var playerMovement = transform.parent.GetComponent<PlayerMovement>();
        var playerController2D = playerMovement.controller;
        _playerAnimator.SetBool("Jump", !playerController2D.m_Grounded);
        var velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
        if (Math.Abs(velocity.x) > 0.01 && playerController2D.m_Grounded)
            _playerAnimator.SetTrigger("WalkTrigger");
        else
            _playerAnimator.SetTrigger("IdleTrigger");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isBlack && other.gameObject.tag.Equals("BlackPlayer"))
        {
            hitSound.Play();
            other.GetComponentInChildren<AnimationController>().BloodDisplay();
            UiController.Instance.AddPointForSecondPlayer();
        }
        else if (_isBlack && other.gameObject.tag.Equals("WhitePlayer"))
        {
            hitSound.Play();
            other.GetComponentInChildren<AnimationController>().BloodDisplay();
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