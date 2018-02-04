using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleManager : MonoBehaviour {

    //i don't want to use arrays it's a game jam

    [SerializeField] PlaneManager plane_manager;

    [SerializeField] Material lit;
    [SerializeField] Material unlit;

    [SerializeField] List<LEDControl> console_1_lights = new List<LEDControl>();
    [SerializeField] List<LEDControl> console_2_lights = new List<LEDControl>();
    [SerializeField] List<LEDControl> console_3_lights = new List<LEDControl>();

    [SerializeField] Light room_light;


    //console 1
    //lights
    [SerializeField] VRBasics_Slider[] runway_buttons = new VRBasics_Slider[3];
    [SerializeField] bool[] runway_button_states = new bool[3];
    [SerializeField] Renderer[] runway_button_r = new Renderer[3];

    //runway buttons
    [SerializeField] VRBasics_Hinge[] light_levers = new VRBasics_Hinge[8];
    [SerializeField] bool[] light_lever_states = new bool[8];

    ////console 2
    [SerializeField] VRBasics_Slider[] plane_buttons = new VRBasics_Slider[8];
    [SerializeField] bool[] plane_button_states = new bool[8];
    [SerializeField] Renderer[] plane_button_r = new Renderer[8];

    [SerializeField] VRBasics_Hinge land_lever;
    [SerializeField] bool land_plane_status = false;

    [SerializeField] VRBasics_Hinge take_off_lever;
    [SerializeField] bool take_off_plane_status = false;

    ////map sliders
    [SerializeField] VRBasics_Slider slider_x;
    public float map_y_axis = 0.5f;
    [SerializeField] VRBasics_Slider slider_y;
    public float map_x_axis = 0.5f;

    ////console 3
    ////dials
    [SerializeField] VRBasics_Hinge dial_1_hinge;
    [SerializeField] VRBasics_Hinge dial_2_hinge;
    public float dial_1 = 0.5f;
    public float dial_2 = 0.5f;
 

    // Use this for initialization
    void Start()
    {
        dial_1 = dial_1_hinge.angle;
        dial_2 = dial_2_hinge.angle;

        map_x_axis = slider_x.percentage;
        map_y_axis = slider_y.percentage;

        land_lever.angle = 40.0f;

        for (int i = 0; i < light_lever_states.Length; i++)
        {
            light_lever_states[i] = false;
            light_levers[i].angle = -40.0f;
        }

        for (int i = 0; i < console_1_lights.Count; i++)
        {
            console_1_lights[i].TurnOff();
        }

        for (int i = 0; i < console_2_lights.Count; i++)
        {
            console_2_lights[i].TurnOff();
        }

        for (int i = 0; i < console_3_lights.Count; i++)
        {
            console_3_lights[i].TurnOff();
        }

        for (int j = 0; j < runway_button_states.Length; j++)
        {
            if (j == 0)
            {
                runway_button_states[j] = true;
                runway_button_r[j].material = lit;
            }

            else
            {
                runway_buttons[j].position = 0.0f;
                runway_button_states[j] = false;
            }
        }

        for (int x = 0; x < plane_button_states.Length; x++)
        {
            if (x == 0)
            {
                plane_button_states[x] = true;
                plane_button_r[x].material = lit;
            }

            else
            {
                plane_buttons[x].position = 0.0f;
                plane_button_states[x] = false;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (dial_1 != dial_1_hinge.angle)
        {
            dial_1 = dial_1_hinge.angle;
        }

        if(dial_2 != dial_2_hinge.angle)
        {
            dial_2 = dial_2_hinge.angle;
        }

        if (map_y_axis != slider_y.percentage)
        {
            map_y_axis = slider_y.percentage;
        }

        if (map_x_axis != slider_x.percentage)
        {
            map_x_axis = slider_x.percentage;
        }

        for (int i = 0; i < runway_buttons.Length; i++)
        {
            if (runway_buttons[i].position > 0.1f)
            {
                for (int j = 0; j < runway_button_states.Length; j++)
                {
                    if (j != i)
                    {
                        runway_button_states[j] = false;
                        runway_buttons[j].position = 0.0f;
                        runway_button_r[j].material = unlit;
                    }
                }

                runway_button_states[i] = true;
                runway_button_r[i].material = lit;
            }
        }

        for (int x = 0; x < plane_buttons.Length; x++)
        {
            if (plane_buttons[x].position > 0.1f)
            {
                for (int j = 0; j < plane_button_states.Length; j++)
                {
                    if (j != x)
                    {
                        plane_button_states[j] = false;
                        plane_buttons[j].position = 0.0f;
                        plane_button_r[j].material = unlit;
                    }
                }

                plane_button_states[x] = true;
                plane_button_r[x].material = lit;
            }
        }

        if (land_lever.angle < -35)
        {
            LandPlane();
            land_plane_status = true;
        }

        if (land_plane_status)
        {
            if (land_lever.angle > 35)
            {
                land_plane_status = false;
            }
        }

        if (take_off_lever.angle < -35)
        {
            TakeOff();
            take_off_plane_status = true;
        }

        if (take_off_plane_status)
        {
            if (take_off_lever.angle > 35)
            {
                take_off_plane_status = false;
            }
        }

        for (int j = 0; j < light_lever_states.Length; j++)
        {
            //if (light_lever_states[j] == false)
            {
                if (light_levers[j].angle > 30)
                {
                    if (light_lever_states[j] == false)
                    {
                        light_lever_states[j] = true;

                        LightOn(j, true);
                    }
                }
            }

            //else if (light_lever_states[j] == true)
            {
                if (light_levers[j].angle < -30)
                {
                    if (light_lever_states[j] == true)
                    {
                        light_lever_states[j] = false;

                        LightOn(j, false);
                    }
                }
            }
        }
    }

    public int GetRunwayButton()
    {
        for (int i = 0; i < runway_buttons.Length; i++)
        {
            if (runway_button_states[i] == true)
            {
                return i;
            }
        }

        return 0;
    }

    public int GetPlaneButton()
    {
        for (int i = 0; i < plane_buttons.Length; i++)
        {
            if (plane_button_states[i] == true)
            {
                return i;
            }
        }

        return 0;
    }

    public void LandPlane()
    {
        plane_manager.LandLeverPulled();
    }

    public void TakeOff()
    {
        plane_manager.TakeOffLeverPulled();
    }

    private void LightOn(int j, bool on)
    {
        switch (j)
        {
            case 0:
                if (on)
                {
                    room_light.enabled = true;
                }
                else
                {
                    room_light.enabled = false;
                }
                break;
            case 1:
                if (on)
                {
                    room_light.enabled = true;
                }
                else
                {
                    room_light.enabled = false;
                }
                break;
            case 2:
                
                break;
            case 3:

                break;
            case 4:

                break;
            case 5:
                if (on)
                {
                    for (int i = 0; i < console_2_lights.Count; i++)
                    {
                        console_2_lights[i].TurnOn();
                    }
                }

                else
                {
                    for (int i = 0; i < console_2_lights.Count; i++)
                    {
                        console_2_lights[i].TurnOff();
                    }
                }
                break;
            case 6:
                if (on)
                {
                    for (int i = 0; i < console_3_lights.Count; i++)
                    {
                        console_3_lights[i].TurnOn();
                    }
                }

                else
                {
                    for (int i = 0; i < console_3_lights.Count; i++)
                    {
                        console_3_lights[i].TurnOff();
                    }
                }
                break;
            case 7:
                if (on)
                {
                    for (int i = 0; i < console_1_lights.Count; i++)
                    {
                        console_1_lights[i].TurnOn();
                    }
                }

                else
                {
                    for (int i = 0; i < console_1_lights.Count; i++)
                    {
                        console_1_lights[i].TurnOff();
                    }
                }
                break;
        }
    }
}
