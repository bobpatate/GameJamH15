using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    private int currentPos;
    private bool showControl = false;
    private bool showNewGameGUI = false;

    // Use this for initialization
    void Start()
    {
        currentPos = 0;
        changeSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePos(int side)
    {
        currentPos = (currentPos + side) % 3;
        currentPos = currentPos == -1 ? 2 : currentPos;
        changeSprite();
    }

    public int getCurrentPos()
    {
        return currentPos;
    }

    public void changeSprite()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Equals("NewGame"))
            {
                if (currentPos == 0)
                {
                    child.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    child.GetComponent<Image>().color = Color.white;
                }

            }
            else if (child.name.Equals("Controls"))
            {
                if (currentPos == 1)
                {
                    child.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    child.GetComponent<Image>().color = Color.white;
                }
            }
            else
            {
                if (currentPos == 2)
                {
                    child.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    child.GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

    public void showControls()
    {
        showControl = true;
    }

    public void hideControls()
    {
        showControl = false;
    }

    public void showNewGame()
    {
        showNewGameGUI = true;
    }

    public void hideNewGame()
    {
        showNewGameGUI = false;
    }

    void OnGUI()
    {
        if (showControl)
        {

        }
        if (showNewGameGUI)
        {

        }
    }
}
