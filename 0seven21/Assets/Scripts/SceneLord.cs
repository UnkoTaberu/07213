using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLord : MonoBehaviour {


    float startTime;

    private int scenenum = 1;

    private Text text;

    // Use this for initialization
    void Start () {
        startTime = Time.time;

        this.text = this.GetComponent<Text>();
        this.text.text = scenenum + "階";
        scenenum++;
    }
	
	// Update is called once per frame
	void Update () {

        

        if (Time.time - startTime > 0.5f)
        {
            // シーン切り替え
            SceneManager.LoadScene("Main");

            
        }
    }
}
