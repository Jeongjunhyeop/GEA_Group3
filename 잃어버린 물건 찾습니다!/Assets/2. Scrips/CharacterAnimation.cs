using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
	[SerializeField]
	private GameObject attackCollision;

	Animator animator;
	CharacterState status;
	bool attacked = false;

	public void Move(float h, float v)
	{
		if (h == 0 && v == 0)
		{
			animator.SetBool("movingTward", false);
			animator.SetBool("movingBackward", false);
		}
		else if (v < 0)
		{
			animator.SetBool("movingBackward", true);
		}
		else if (h > 0 || v > 0)
		{
			animator.SetBool("movingTward", true);
		}
	}

	public void Jump()
	{
		animator.SetTrigger("Jumping");
	}

	public void Attack()
	{
		animator.SetTrigger("Attack");
	}

	void Start()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterState>();
	}

	void Update()
	{
		animator.SetBool("OnGround", status.onGround);
	}
	public void OnAttackCollision()
	{
		attackCollision.SetActive(true);
	}
}
