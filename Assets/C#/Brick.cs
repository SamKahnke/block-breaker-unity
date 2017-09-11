using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public Sprite[] hitSprites;
	public static int bricksRemaining;

	private LevelManager levelManager;
	private int timesHit;
	private int maxHits;
	private bool isBreakable;

	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (tag == "Breakable");
		timesHit = 0;
		
		if (isBreakable)
		{
			bricksRemaining++;
			if (!GetComponent<SpriteRenderer>().sprite)
			{
				Debug.LogError("Brick sprite for " + gameObject.name + " is missing.");
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		timesHit++;
	}

	void OnCollisionExit2D (Collision2D collision)
	{
		if (isBreakable)
		{
			HandleHit();
		}
	}

	void HandleHit ()
	{
		maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits)
		{
			Destroy(gameObject);
			bricksRemaining--;
			levelManager.BrickDestroyed();
		}
		else
		{
			LoadHitSprite();
		}
	}

	void LoadHitSprite ()
	{
		if (hitSprites[timesHit - 1])
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		}
		else
		{
			Debug.LogError("Brick sprite for " + gameObject.name + " is missing.");
		}
	}
}
