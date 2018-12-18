using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour {

    private string[] ilist = new string[10];

    public Button[] blist = new Button[10];
    public Text[] tlist = new Text[10];

    int item_i;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < ilist.Length; i++)
        {
            ilist[i] = "";
        }
    }
    public void setIlist(string item_name)
    {
        for (int i = 0; i < ilist.Length; i++)
        {
            if (ilist[i] == "")
            {
                ilist[i] = item_name.Replace("(Clone)", "");
                item_i = i;
                break;
            }
        }

        blist[item_i].gameObject.SetActive(true);
        tlist[item_i].GetComponent<Text>().text = ilist[item_i];
    }

}
