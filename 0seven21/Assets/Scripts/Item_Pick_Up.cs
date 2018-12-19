using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Pick_Up : MonoBehaviour {


    [SerializeField]
    ItemList ilist;
    //[SerializeField]
    //private GameObject propertyWindow;
    ////　ステータスウインドウの全部の画面
    //[SerializeField]
    //private GameObject[] windowLists;

    //// 階段判別用
    //public int Item = 0;

    void Start()
    {
        GameObject imset = GameObject.Find("ItemMenuSet");
        ilist = imset.gameObject.GetComponent<ItemList>();
    }
    void Update()
    {
        Vector3 player = GameObject.Find("Player").transform.position;
        Vector3 item = this.transform.position;


        // アイテムの上に乗った時
        if (player.x == item.x && player.y == item.y)
        {

            //propertyWindow.SetActive(!propertyWindow.activeSelf);
            ////　MainWindowをセット
            //ChangeWindow(windowLists[3]);
            //ilist.setIlist(this.transform.name);

            //Destroy(this.gameObject);


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
