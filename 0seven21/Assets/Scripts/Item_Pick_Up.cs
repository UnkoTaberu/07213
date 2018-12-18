using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Pick_Up : MonoBehaviour {

    public Text title;
    public string unk;
    [SerializeField]
    private GameObject propertyWindow;
    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;


    void Start()
    {
        
    }
    void Update()
    {
        Vector3 player = GameObject.Find("Player").transform.position;
        Vector3 item = this.transform.position;

        if(player.x == item.x && player.y == item.y)
        {
            unk = this.transform.name;

            // title.text = unk;

            //propertyWindow.SetActive(!propertyWindow.activeSelf);
            ////　MainWindowをセット
            //ChangeWindow(windowLists[0]);


            Destroy(this.gameObject);


        }

    }

    ////　ステータス画面のウインドウのオン・オフメソッド
    //public void ChangeWindow(GameObject window)
    //{
    //    foreach (var item in windowLists)
    //    {
    //        if (item == window)
    //        {
    //            item.SetActive(true);
    //            EventSystem.current.SetSelectedGameObject(null);
    //        }
    //        else
    //        {
    //            item.SetActive(false);
    //        }
    //        //　それぞれのウインドウのMenuAreaの最初の子要素をアクティブな状態にする
    //        EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
    //    }
    //}
}
