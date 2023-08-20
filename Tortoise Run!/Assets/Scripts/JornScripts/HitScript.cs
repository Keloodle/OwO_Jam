using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitScript : MonoBehaviour
{
	public bool OnTarget = false;
	private CapsuleCollider2D col;
	public Image image;
    void Start()
    {
		image = GetComponent<Image>();
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
