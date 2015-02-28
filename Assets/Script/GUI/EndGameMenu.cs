using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour {

	private int currentPos;
	private int currentPosSubMenu;
	private bool inSubMenu = false;
	public Sprite[] normal;
	public Sprite[] selected;

	// Use this for initialization
	void Start () {
		currentPos = 0;
		currentPosSubMenu = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void changePos(int side){
		if (inSubMenu) {
			currentPosSubMenu += side;
			if(currentPosSubMenu > 2)
				currentPosSubMenu = 0;
			else if(currentPosSubMenu < 0)
				currentPosSubMenu = 2;
		} else {
			currentPos += side;
			if(currentPos > 1)
				currentPos = 0;
			else if(currentPos < 0)
				currentPos = 1;
		}
	}

	void changeMenu(){
		if (inSubMenu)
			inSubMenu = true;
		else
			inSubMenu = false;
	}

	void changeSprite(){
		//changement des sprites, à faire quand on change les boutons pour des images
	}
}
