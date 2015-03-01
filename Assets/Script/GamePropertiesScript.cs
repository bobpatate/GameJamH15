using UnityEngine;
using System.Collections;

public class GamePropertiesScript : MonoBehaviour {

    private static GamePropertiesScript _instance;

    public static GamePropertiesScript instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GamePropertiesScript>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    int characterId;

    public void setCharacter(int i)
    {
        characterId = i;
    }
}
