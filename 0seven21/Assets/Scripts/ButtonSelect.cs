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

    //　階層表示のシーンに遷移
    public void TheSceneLord()
    {
        SceneManager.LoadScene("Scene");
    }

    //　タイトルのシーンに遷移
    public void TitleSceneLord()
    {
        SceneLord.score = 1;
        SceneManager.LoadScene("Game_Title");
    }
}