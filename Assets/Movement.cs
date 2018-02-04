using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float jumpForce = 4.0f;
    public float walkForce = 4.0f;
    private float x = 0;
    private float y = 0;
    private bool isGrounded = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            if (isGrounded)
                x -= 0.1f;
            else
                x -= 0.05f;
        }

        if (Input.GetKey("d"))
        {
            if (isGrounded)
                x += 0.1f;
            else
                x += 0.05f;
        }

        if (Input.GetKey("space") && isGrounded)
        {
            jump(); 
        }

        //transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(x, y, 0), 1.0f);
        GetComponent<Rigidbody>().AddForce(new Vector2(x, y) * walkForce, ForceMode.Impulse);

        if (x > 0) x -= 0.1f;
        else if (x < 0) x += 0.1f;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    private void jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}
