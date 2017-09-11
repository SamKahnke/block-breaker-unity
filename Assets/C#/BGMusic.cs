using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour {

	static BGMusic music;

	void Awake ()
	{
		if(music != null)
		{
			Destroy(gameObject);
		}
		else
		{
			music = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Update ()
	{
		
	}
} 
