﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = Scorekeeper.score.ToString();
		Scorekeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
