using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayLight : MonoBehaviour {

    private bool growing = true;
    public float duration = 1.0F;
    private float counter = 0;

    public Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update () {
        counter += 1;

        if (growing)
        {
            float phi = Time.time / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 2.5F + 0.5F;
            lt.intensity = amplitude;
        }
	}
}
