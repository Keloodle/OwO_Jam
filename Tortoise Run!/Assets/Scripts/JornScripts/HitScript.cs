using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
	public bool OnTarget = false;
	private CapsuleCollider2D col;
    void Start()
    {

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Target"))
		{
			OnTarget = true;

		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Target"))
		{
			OnTarget = false;
		}
	}
}
