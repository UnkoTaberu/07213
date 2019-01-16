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
            tlist[i].GetComponent<Text>().text = "";
        }
    }
    public void SetIlist(string item_name)
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
    public string UnsetIlist()
    {
        for (int i = 0; i < ilist.Length - 1; i++)
        {
            if (tlist[i].GetComponent<Text>().text == "" && tlist[i + 1].GetComponent<Text>().text != "")
            {
                ilist[i] = ilist[i + 1];
                ilist[i + 1] = "";

                blist[i].gameObject.SetActive(true);
                tlist[i].GetComponent<Text>().text = ilist[i];
                blist[i + 1].gameObject.SetActive(false);
                tlist[i + 1].GetComponent<Text>().text = ilist[i + 1];

            }
            else if(tlist[i].GetComponent<Text>().text == "" && tlist[i + 1].GetComponent<Text>().text == "")
            {
                blist[i].gameObject.SetActive(false);
            }

        }
        return ilist[0];
    }

}
