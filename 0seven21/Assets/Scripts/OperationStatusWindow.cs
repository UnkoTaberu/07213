using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OperationStatusWindow : MonoBehaviour
{

    [SerializeField]
    private GameObject propertyWindow;
    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;

    public GameObject targetObject;

    public int play;

    public int menuOpen;
    private int menuClose;


    void Update()
    {

        // Playerから値を取得
        play = targetObject.GetComponent<Player>().Stairs;

        if (play == 0 && menuClose <= 1)
        {
            //　ステータスウインドウのオン・オフ
            if (Input.GetButtonDown("Start"))
            {
                propertyWindow.SetActive(!propertyWindow.activeSelf);
                //　MainWindowをセット
                ChangeWindow(windowLists[0]);

                // メニューが開いているか判別
                menuOpen = 2;

                // メニューが閉じるまでの判別
                menuClose++; 
            }     
        }
        else if(menuClose == 2)
        {

            // 値を再設定
            menuOpen = 0;
            menuClose = 0;

        }
       
    }

    //　ステータス画面のウインドウのオン・オフメソッド
    public void ChangeWindow(GameObject window)
    {
        foreach (var item in windowLists)
        {
            if (item == window)
            {
                item.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                item.SetActive(false);
            }
        
            EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
            
           
        }
            
    }


}

