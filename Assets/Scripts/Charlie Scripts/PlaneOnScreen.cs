using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOnScreen : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] PlaneManager planeManager;
    [SerializeField] Aeroplane plane;
    Color givenColour;
    int fuelLevel;
    bool bingoFuel = false;
    public bool button;

    [SerializeField] int id = 1;

    void Start()
    {
        givenColour = Color.green;
        fuelLevel = 10;
        //colour get 	
        //getcomponent plane
        //getcomponent button with colour givencolour
        //InvokeRepeating("DrainFuel", 0, 1); 
    }
    public void setPlane(Aeroplane pln)
    {
        plane = pln;
    }
    public void setID(int _id)
    {
        id = _id;
    }

    public int getID()
    {
        return id;
    }
    public void setManager(PlaneManager pln)
    {
        planeManager = pln;
    }

    void DrainFuel()
	{
		fuelLevel--; 
	}
	// Update is called once per frame
	void Update () 
	{
        if (givenColour == Color.green)
        {
            changeColour();
        }

        if (plane == null)
        {
            plane = planeManager.planes[id];
        }
        if (transform.parent == null)
        {
            transform.parent = GameObject.Find("Screen").transform;
            transform.position = Vector3.zero; 
        }
        //0.8 0.5
        //transform.localPosition = new Vector3 (plane.transform.position.z / scale, transform.localPosition.y, plane.transform.position.x / scale);
        
        float ansy = -0.5f - ((plane.transform.localPosition.x - 2450) / 4900);
        float ansx = 0.5f - ((plane.transform.localPosition.z + 2450) / 4900); 
		transform.localPosition = new Vector3 (ansy, 0.6f, ansx);
        //if (((plane.transform.localPosition.x - 2450) / 4900) > 1 || ((plane.transform.localPosition.x - 2450) / 4900) < 0 || ((plane.transform.localPosition.z + 2450) / 4900) < 0 || ((plane.transform.localPosition.z + 2450) / 4900) > 1)
        //{
        //    Destroy(plane); 
        //}
        //else this.GetComponent<Renderer>().enabled = true; 
        transform.rotation = Quaternion.Euler(90, plane.transform.rotation.y, 0); 
		if (fuelLevel < 0) 
		{
            planeManager.CrashPlane(plane.indexNum);
            Destroy(plane); 
		}
		if (fuelLevel < 25 && bingoFuel == false) 
		{
			//InvokeRepeating("Flash", 0, 0.5f);
			bingoFuel = true; 
		}
        //if (transform.localPosition.x )
        //{
        //    Destroy(this); 
        //}
	}
	void Flash()
	{
		if (GetComponent<SpriteRenderer>().color == Color.red)
			GetComponent<SpriteRenderer>().color = givenColour;
		else
			GetComponent<SpriteRenderer> ().color = Color.red;
	}

    void changeColour()
    {
        switch (id)
        {
            case 0:
                givenColour = Color.grey;
                break;
            case 1:
                givenColour = Color.blue;
                break;
            case 2:
                givenColour = Color.cyan;
                break;
            case 3:
                givenColour = Color.white;
                break;
            case 4:
                givenColour = Color.red;
                break;
            case 5:
                givenColour = Color.magenta;
                break;
            case 6:
                givenColour = Color.black;
                break;
            case 7:
                givenColour = Color.yellow;
                break;
        }

        GetComponent<SpriteRenderer>().color = givenColour;
    }

}
