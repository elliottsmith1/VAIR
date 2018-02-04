using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOnScreen : MonoBehaviour 
{

    [SerializeField] ConsoleManager console;

	// Use this for initialization
	[Range(-0.4f,0.4f)] 
	public float xPos; 
	[Range(-0.42f,0.50f)] 
	public float yPos; 
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        yPos = (console.map_y_axis * 0.8f - 0.4f) * -1;
        xPos = (console.map_x_axis * 0.82f - 0.42f) * -1;

		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, xPos); 
		transform.localPosition = new Vector3(yPos, transform.localPosition.y, transform.localPosition.z);  
	}
}
