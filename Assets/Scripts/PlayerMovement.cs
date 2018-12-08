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
	
	private float timeBtwAttack;
	public float startTimeBtwAttack;
	public float attackRangeX;
	public float attackRangeY;
	public Transform attackPos;
	public LayerMask whoIsEnemy;
	public int damage;
	
	public AudioSource attackSound;
	
	private void Start()
	{
		Physics2D.IgnoreLayerCollision(8, 8);
	}

	void Update ()
	{
		if (Player2 == false)
		{
			InputResponsePlayer1();

		}
		else
		{
			InputResponePlayer2();
		}

	}

	void FixedUpdate()
	{
		//jesli bedziemy chcieli crouch to zmieniami false na crouch
		//jesli wlaczymy kucanie to trzeba naprawic buga ze skakaniem (wylaczenie collidera)
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1, 0, 0, 1);	
		Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
	}

	void InputResponsePlayer1()
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
		
		if (timeBtwAttack <= 0)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				attackSound.Play();
				Collider2D[] enemyToDamage = Physics2D.OverlapBoxAll(attackPos.position,
					new Vector2(attackRangeX, attackRangeY), 0, whoIsEnemy);
				for (int i = 0; i < enemyToDamage.Length; i++)
				{
					enemyToDamage[i].GetComponent<PlayerController2D>().TakeDamage(damage);
				}
				timeBtwAttack = startTimeBtwAttack;	
			}
			
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
	}

	void InputResponePlayer2()
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
		
		if (timeBtwAttack <= 0)
		{
			if (Input.GetButtonDown("Fire1_2"))
			{
				attackSound.Play();
				Collider2D[] enemyToDamage = Physics2D.OverlapBoxAll(attackPos.position,
					new Vector2(attackRangeX, attackRangeY), 0, whoIsEnemy);
				for (int i = 0; i < enemyToDamage.Length; i++)
				{
					enemyToDamage[i].GetComponent<PlayerController2D>().TakeDamage(damage);
				}
				timeBtwAttack = startTimeBtwAttack;
			}
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
	}
}