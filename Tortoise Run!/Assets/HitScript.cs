using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
	public bool OnTarget = false;
	private CapsuleCollider2D col;
	const float defaultSize = 6.2f;
    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Target"))
		{
			OnTarget = true;
			col.size = new Vector2(0.15f, col.size.y);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Target"))
		{
			OnTarget = false;
			col.size = new Vector2(defaultSize, col.size.y);
		}
	}
}
