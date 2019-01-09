using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    public void ButtonClick()
    {
        switch (transform.name)
        {
            case "StartButton":
                SceneManager.LoadScene("Scene");
                break;
            case "Tips":
                SceneManager.LoadScene("Game_Rulu");
                break;
            default:
                break;
        }
    }
}