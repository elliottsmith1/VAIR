using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScreen : MonoBehaviour {

    // Use this for initialization
    //int length = 20; 
    //Vector3 start = transform.localPosition; 
    //Vector3 end = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 10);
    // public PlaneOnScreen littlePlane;
    [SerializeField] GameObject planeprefab;
    void Start () 
	{
		//LineRenderer line = gameObject.AddComponent<LineRenderer> (); 
		//line.startColor = Color.green; 
		//line.endColor = Color.green; 
		//line.widthMultiplier = 0.02f; 
		//line.SetPosition(0, start);
		//line.SetPosition(1, end);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SpawnPlaneOnScreen(Aeroplane plane)
	{
        Instantiate(planeprefab, new Vector3(0.14f, 0.72f, -0.4f), Quaternion.identity);
        planeprefab.transform.SetParent(gameObject.transform); 
        planeprefab.GetComponent<PlaneOnScreen>().setManager(GameObject.Find("CONTROLLER").GetComponent<PlaneManager>());
        planeprefab.GetComponent<PlaneOnScreen>().setPlane(plane);
        planeprefab.GetComponent<PlaneOnScreen>().setID(plane.getIndexNum());
    }
}
