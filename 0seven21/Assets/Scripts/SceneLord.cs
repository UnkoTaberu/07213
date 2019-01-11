using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLord : MonoBehaviour {


    float startTime;

    public static int score = 1;

    private Text text;

    // Use this for initialization
    void Start () {
        

        startTime = Time.time;


        this.text = this.GetComponent<Text>();
        this.text.text = score + "階";
        score++;    

    }
	
	// Update is called once per frame
	void Update () {

        if(score <= 3)
        {
            
            if (Time.time - startTime > 1f)
            {
                
                // シーン切り替え
                SceneManager.LoadScene("Main");

            }
        }
        else
        {
            if (Time.time - startTime > 1f)
            {
                score = 1;
                SceneManager.LoadScene("Game_Title");
            }

        }

    }
    
}   
