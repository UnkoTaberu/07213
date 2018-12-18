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

    public int v;
    private int a;

    void Update()
    {
        // Playerから値を取得
        play = targetObject.GetComponent<Player>().a;

        if (play == 0 && a <= 1)
        {
            //　ステータスウインドウのオン・オフ
            if (Input.GetButtonDown("Start"))
            {
                propertyWindow.SetActive(!propertyWindow.activeSelf);
                //　MainWindowをセット
                ChangeWindow(windowLists[0]);

                // メニューが開いているか判別
                v = 2;

                // メニューが閉じるまでの判別
                a++; 
            }     
        }
        else if(a == 2)
        {

            // 値を再設定
            v = 0;
            a = 0;

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
            //　それぞれのウインドウのMenuAreaの最初の子要素をアクティブな状態にする
            EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
        }
            
    }


}

