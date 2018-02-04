using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class LEDControl : MonoBehaviour
{

    [SerializeField] Material lit_mat;
    [SerializeField] Material unlit_mat;

    [SerializeField] GameObject bulb1;
    [SerializeField] GameObject bulb2;

    [SerializeField] int counter_speed = 200;

    private Renderer ren1;
    private Renderer ren2;

    private bool lit = false;

    private int counter = 0;
    private bool flicker = true;

    // Use this for initialization
    void Start()
    {
        ren1 = bulb1.GetComponent<Renderer>();
        ren2 = bulb2.GetComponent<Renderer>();

        ren1.material = unlit_mat;
        ren2.material = unlit_mat;

        counter_speed = Random.Range(15, 75);

    }

    // Update is called once per frame
    void Update()
    {

        if (flicker)
        {
            counter += 1;

            if (counter > counter_speed)
            {
                counter = 0;

                if (lit)
                {
                    ren1.material = unlit_mat;
                    ren2.material = unlit_mat;

                    lit = false;
                }
                else
                {
                    ren1.material = lit_mat;
                    ren2.material = lit_mat;

                    lit = true;
                }
            }
        }

    }

    public void TurnOn()
    {
        lit = true;

        flicker = true;

        counter = 1;
    }

    public void TurnOff()
    {
        lit = false;

        ren1.material = unlit_mat;
        ren2.material = unlit_mat;

        flicker = false;

        counter = 1;
    }
}
