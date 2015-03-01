using UnityEngine;
using System.Collections;

public class BuildingBar : MonoBehaviour {

    private Texture2D background;
    private Texture2D foreground;

    private float buildingTime = 0.0f;
    private float currentBuildingTime = 0.0f;
    private float lastTickedTime = 0.0f;
    private bool isCompleted = false;

    public float width = 50;
    public float height = 6;

    void Start()
    {
        //Initialisation
        buildingTime = gameObject.GetComponent<Towers>().getBuildingTime();
        currentBuildingTime = gameObject.GetComponent<Towers>().getCurrentBuildingTime();

        background = new Texture2D(1, 1, TextureFormat.RGB24, false);
        foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);

        background.SetPixel(0, 0, Color.black);
        foreground.SetPixel(0, 0, Color.gray);

        background.Apply();
        foreground.Apply();
    }

    void Update()
    {
		if (!isCompleted) {
			if (GameObject.Find ("Player")) {
				currentBuildingTime = gameObject.GetComponent<Towers> ().getCurrentBuildingTime ();
				if (currentBuildingTime >= buildingTime) {
					isCompleted = true;
					GameObject.Find ("Player").GetComponent<PlayerController> ().enabled = true;
				} else {
					GameObject.Find ("Player").GetComponent<PlayerController> ().enabled = false;
				}
			}
		}
    }

    void OnGUI()
    {
        if (!isCompleted)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);// gets screen position.
            screenPosition.y = Screen.height - (screenPosition.y + 1);// inverts y

            Rect box = new Rect(screenPosition.x - 20, screenPosition.y - 35, width, height);

            GUI.DrawTexture(new Rect(box.x, box.y, box.width, box.height), background, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(box.x, box.y, box.width * currentBuildingTime / buildingTime, box.height), foreground, ScaleMode.StretchToFill);
        }
    }

}

