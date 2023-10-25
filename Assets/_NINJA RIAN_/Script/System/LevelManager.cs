using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class LevelManager : MonoBehaviour {
	public static LevelManager Instance{ get; private set;}
    public GameObject testLevelMap;
    [SerializeField] int TestLevel;
    //public GameObject[] LevelMaps;

	CameraFollow Camera;

    void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("LastLevel"))
        {
            GlobalValue.levelPlaying = PlayerPrefs.GetInt("LastLevel");
        }

        if (PlayerPrefs.HasKey("LastCheckPoint"))
        {
            GlobalValue.checkpointNumber = PlayerPrefs.GetInt("LastCheckPoint");
        }

        if (TestLevel > 0)
        {
            GlobalValue.levelPlaying = TestLevel;
        }

        if (FindObjectOfType<LevelMapType>())
        {
            Debug.LogError("Notice: There are a Level on this scene!");
            return;
        }
            
        if (DefaultValue.Instance)
        {
            //Instantiate(LevelMaps[GlobalValue.levelPlaying - 1], Vector2.zero, Quaternion.identity);
            var _go = Resources.Load("LevelMap/Final Level/Level Map " + GlobalValue.levelPlaying ) as GameObject;
            Instantiate(_go, Vector2.zero, Quaternion.identity);
        }
        else
        {
            if (testLevelMap)
                Instantiate(testLevelMap, Vector2.zero, Quaternion.identity); 
        }

    }

	void Start () {
		Camera = FindObjectOfType<CameraFollow> ();
	}
}
