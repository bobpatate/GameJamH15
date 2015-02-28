using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConstructionGUI : MonoBehaviour {

	public Sprite[] normal;
	public Sprite[] selected; 
	private int currentPos;
	private SpriteRenderer[] sprites;

	// Use this for initialization
	void Start () {
		currentPos = 0;
		changeGUI (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeGUI(int towerInUse){
        for (int i = 0; i < 3; i++)
        {
            if (i == towerInUse)
            {
                transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = selected[i];
            }
            else
            {
                transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = normal[i];
            }
        }
	}
}
