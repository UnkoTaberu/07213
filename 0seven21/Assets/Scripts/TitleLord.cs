using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLord : MonoBehaviour {


    //private AudioSource sound01;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //sound01 = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            //sound01.PlayOneShot(sound01.clip);
            SceneManager.LoadScene("Scene");
            


        }

    }
}
