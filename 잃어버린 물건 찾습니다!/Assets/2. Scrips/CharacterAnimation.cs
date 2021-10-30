using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
	Animator animator;
	CharacterState status;
	bool attacked = false;

	public void Move(float h, float v)
    {
		if(h == 0 && v == 0)
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

	public bool IsAttacked()
	{
		return attacked;
	}

	void StartAttackHit()
	{
		Debug.Log("StartAttackHit");
	}

	void EndAttackHit()
	{
		Debug.Log("EndAttackHit");
	}

	void EndAttack()
	{
		attacked = true;
	}

	void Start()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterState>();
	}

	void Update()
	{
		
	}
}
