using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	private Paddle paddle;
	private bool isLaunched;
	private Vector3 paddleToBallVector;

	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		isLaunched = false;
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	void Update ()
	{
		if (!isLaunched)
		{
			transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown(0))
			{
				isLaunched = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{

		if (isLaunched)
		{
			GetComponent<AudioSource>().Play();
		}
	}
}
