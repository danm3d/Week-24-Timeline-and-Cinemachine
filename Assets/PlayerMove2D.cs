using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{

	protected Rigidbody2D body;
	public float movementForce = 5f;
	public float jumpForce = 5f;
	private void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float x = Input.GetAxis("Horizontal");

		body.AddForce(Vector2.right * x * movementForce * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
}
