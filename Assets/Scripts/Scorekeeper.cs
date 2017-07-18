using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scorekeeper : MonoBehaviour {

	public static int score = 0;
	private Text myText;
	
	void Start(){
		myText = GetComponent<Text>();
		Reset();
	}
	
	public void Score(int points){
		Debug.Log ("Scored Points");
		score += points;
		myText.text = score.ToString ();
	}

	public static void Reset(){
		score = 0;
		}

}
