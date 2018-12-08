using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public PlayerController2D controller;
	[SerializeField] private bool Player2 = false;
	float horizontalMove = 0f;
	public float runSpeed = 40f;
	bool jump = false;
	bool crouch = false;

	private void Start()
	{
		Physics2D.IgnoreLayerCollision(8, 8);
	}

	void Update ()
	{
		if (Player2 == false)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}
			if (Input.GetButtonDown("Crouch"))
			{
				crouch = true;
			} else if (Input.GetButtonUp("Crouch"))
			{
				crouch = false;
			}

		}
		else
		{
			horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
			if (Input.GetButtonDown("Jump2"))
			{
				jump = true;
			}
			if (Input.GetButtonDown("Crouch2"))
			{
				crouch = true;
			} else if (Input.GetButtonUp("Crouch2"))
			{
				crouch = false;
			}
		}
	}

	void FixedUpdate()
	{
		//jesli bedziemy chcieli crouch to zmieniami false na crouch
		//jesli wlaczymy kucanie to trzeba naprawic buga ze skakaniem (wylaczenie collidera)
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}

	
}
