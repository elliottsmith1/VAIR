using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour {

	// Use this for initialization
	int mins; 
	int hours; 
	TextMesh clock; 
	string lastKnownTime; 
	void Start () {
		hours = 15; 
		mins = 0; 
		lastKnownTime = hours.ToString () + ":0" + mins;  
		InvokeRepeating("tick", 0, 0.5f);
		clock = GetComponent<TextMesh> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (mins == 60) {
			mins = 0; 
			hours++; 
		}
		if (hours == 24) 
			hours = 0; 
		
		clock.text = "";  
		if (hours < 10)
			clock.text += "0"; 
		clock.text += hours.ToString () + ":"; 
		if (mins < 10)
			clock.text += "0"; 
		clock.text += mins.ToString (); 
		lastKnownTime = clock.text; 
	}
	void tick()
	{
		mins++; 
	}
	public string getTime()
	{
		return lastKnownTime; 
	}
	public float getPercentageThroughDay()
	{
		return hours / 24; 
	}
}
