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

	public void Move(bool isMove)
	{
		if (isMove)
			animator.SetBool("movingTward", true);
		else
			animator.SetBool("movingTward", false);
	}

	public void Jump()
	{
		animator.SetTrigger("Jumping");
	}

	public void Dash()
	{
		animator.SetBool("Dash", true);
	}

	public void DashEnd()
	{
		animator.SetBool("Dash", false);
	}

	public void Attack()
	{
		animator.SetTrigger("Attack");
	}

	public void Groggy()
	{
		animator.SetTrigger("Dizzy");
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
	public void EndAttackCollision()
	{
		attackCollision.SetActive(false);
	}
	public void EndAttack()
	{
	}
}
