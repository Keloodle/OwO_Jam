using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleMovement : MonoBehaviour
{
    [Header("References")]
    public PlayerController controller;
    public Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
    {
        rb.velocity = new Vector3 (rb.velocity.x,rb.velocity.y,controller.turtle1MoveSpeed);
    }
}
