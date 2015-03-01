using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour
{

    bool VDPadInUse = false;
    StartMenu sm;

    // Use this for initialization
    void Start()
    {
        sm = transform.GetComponent<StartMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            switch (transform.GetComponent<StartMenu>().getCurrentPos())
            {
                case 0:
                    //New game
                    sm.showNewGame();
                    break;
                case 1:
                    //Show gui controls
                    sm.showControls();
                    break;
                case 2:
                    //Quit
                    Application.Quit();
                    break;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            sm.hideNewGame();
            sm.hideControls();
        }

        if (Input.GetAxis("VDPad") < 0)
        {
            if (!VDPadInUse)
            {
                sm.changePos(1);
                VDPadInUse = true;
            }
        }
        if (Input.GetAxis("VDPad") > 0)
        {
            if (!VDPadInUse)
            {
                sm.changePos(-1);
                VDPadInUse = true;
            }
        }
        if (Input.GetAxis("VDPad") == 0)
        {
            VDPadInUse = false;
        }
    }
}
