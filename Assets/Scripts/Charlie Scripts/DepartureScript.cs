using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartureScript : MonoBehaviour {

	// Use this for initialization
	List<string> departures = new List<string>(); 
	List<string> possibleFlights = new List<string>(); 
	public ClockScript clock; 
	TextMesh display; 
	void Start () 
	{
		possibleFlights.Add ("UWE -> LHR    "); 
		possibleFlights.Add ("UWE -> LAX    "); 
		possibleFlights.Add ("UWE -> EEB    "); 
		possibleFlights.Add ("UWE -> JDD    "); 
		possibleFlights.Add ("UWE -> DMJ    "); 
		possibleFlights.Add ("UWE -> OUA    "); 
		possibleFlights.Add ("UWE -> HEL    "); 
		possibleFlights.Add ("UWE -> GRV    "); 
		possibleFlights.Add ("UWE -> SYD    "); 
		possibleFlights.Add ("UWE -> BEG    "); 
		//InvokeRepeating("LandPlane", 0, 1.0f);
		//InvokeRepeating("PlaneTakeOff", 0, 3.0f);
		display = GetComponent<TextMesh>();; 
	}
	
	// Update is called once per frame
	void Update () {
		display.text = ""; 
		for (int i = 0; i < departures.Count; i++)
			display.text += departures [i] + "\n"; 
	}

	public void PlaneTakeOff()
	{
		departures.RemoveAt(0); 
	}
	public void LandPlane()
	{
		if (departures.Count < 7)
		departures.Add (possibleFlights [Random.Range (0, 9)] + editTimeByHours (clock.getTime (), 2, 2));
	}

	string editTimeByHours(string time, int min, int max) 
	{
		string output = ""; 
		int hrs = int.Parse(time.Substring(0,2));
		hrs += Random.Range (min, max);  
		if (hrs < 10)
			output = "0"; 
		output += hrs + time.Substring (2); 
		return output; 
	}
}
