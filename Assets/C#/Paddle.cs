using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public bool autoPlayMode;

	private Ball ball;
	private Vector3 paddlePos;
	private float mousePosX;
	private float ballPosX;
	
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update ()
	{
		if (!autoPlayMode)
		{
			MoveWithMouse();
		}
		else
		{
			AutoPlay();
		}
	}

	void AutoPlay ()
	{
		paddlePos = new Vector3(0f, transform.position.y, 0f);
		ballPosX = ball.transform.position.x;
		
		paddlePos.x = Mathf.Clamp(ballPosX, 0.5f, 15.5f);
		transform.position = paddlePos;
	}

	void MoveWithMouse ()
	{
		paddlePos = new Vector3(0f, transform.position.y, 0f);
		mousePosX = (Input.mousePosition.x / Screen.width) * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosX, 0.5f, 15.5f);
		transform.position = paddlePos;
	}
}
