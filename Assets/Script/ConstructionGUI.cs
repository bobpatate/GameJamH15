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

	public void changeGUI(int side){
		if(currentPos + side > -1 && currentPos + side < 3){
			currentPos += side;
			for (int i = 0; i < 3; i++) {
				if(currentPos == i)
					transform.GetChild(i).GetComponent<Image>().sprite = selected[i];
				else
					transform.GetChild(i).GetComponent<Image>().sprite = normal[i];
			}
		}
	}
}
