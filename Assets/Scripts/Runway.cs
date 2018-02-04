using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour {
	public bool inTrigger = false;

	[SerializeField] List<Aeroplane> planes = new List<Aeroplane>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsPlaneInTrigger(Aeroplane plane)
	{
        for (int i = 0; i < planes.Count; i++)
        {
            if (planes[i] == plane)
            {
                return true;
            }
        }
		return false; 
	}

	public bool IsPlaneAligned (float planeYRot)
	{
		return (planeYRot > transform.rotation.y - 90 && planeYRot < transform.rotation.y + 90); 
	}

	void OnTriggerStay(Collider col)
	{
		inTrigger = true;
	}

	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "Plane")
        {
            planes.Add(col.gameObject.GetComponent<Aeroplane>());
        }
	}
		
	void OnTriggerExit(Collider col)
	{
        if (col.gameObject.tag == "Plane")
        {
            planes.Remove(col.gameObject.GetComponent<Aeroplane>());
        }
	}

}
