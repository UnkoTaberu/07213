using UnityEngine;
using System.Collections;
public class Windos_Change : MonoBehaviour
{

    public int ScreenWidth;
    public int ScreenHeight;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(ScreenWidth, ScreenHeight, false);
        }
    }
}