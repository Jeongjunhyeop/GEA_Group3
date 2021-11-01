using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
	Animator animator;
	CharacterState status;
	public GroundSensor sensor;
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

	public void Jump()
    {
		animator.SetTrigger("Jumping");
    }

	void Start()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterState>();
		//sensor = GetComponent<GroundSensor>();
	}

	void Update()
	{
		animator.SetBool("OnGround", sensor.onGround());
	}
}
