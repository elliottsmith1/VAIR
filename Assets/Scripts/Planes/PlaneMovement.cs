using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    private Aeroplane plane = null;
    private BezierCurve trajectory = null;
    private float progress = 0.0f;
    private Rigidbody m_rb;
    private bool grounded = false;
    [SerializeField] float max_speed = 5.0f;

    // Use this for initialization
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void InitialisePlane(BezierCurve _trajectory)
	{
		plane = gameObject.GetComponent<Aeroplane>();
		//indexNum = plane.indexNum;

		trajectory = _trajectory;
	}



	// Update is called once per frame
	void FixedUpdate ()
    {
        if (m_rb.velocity.magnitude > max_speed)
        {
            m_rb.velocity = m_rb.velocity.normalized * max_speed;
        }

        if (trajectory.IsInitialised) 
		{
			progress += 0.0005f;
            if (progress < 1.0f)
            {
                Vector3 NewPos = trajectory.GetPoint(progress);
                transform.position = NewPos;// new Vector3(NewPos.x, NewPos.z, NewPos.y);
                transform.LookAt(NewPos + trajectory.GetDirection(progress));
            }

            else
            {
                progress = 0; //Destroy(plane);  
            }
		}
    }
}
