﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoSelect : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		GetComponent<Button>().Select();
	}
}
