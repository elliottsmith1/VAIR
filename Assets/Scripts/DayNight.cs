using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    // Use this for initialization

    public ClockScript clock;
    private Light sunLight;


	void Start () {
        sunLight =GetComponent<Light>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (clock.getPercentageThroughDay () > 0.5f) {
			sunLight.intensity = 1 - clock.getPercentageThroughDay ();
		} else {
			sunLight.intensity = clock.getPercentageThroughDay ();
		}



	}
}
