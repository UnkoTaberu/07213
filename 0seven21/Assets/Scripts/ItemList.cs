using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour {

    private string[] ilist = new string[10];
    public static string[] ilist_c = new string[10];

    public Button[] blist = new Button[10];
    public Text[] tlist = new Text[10];

    int item_i;

    // Use this for initialization
    void Start () {
        if (SceneLord.score == 2)
        {
            for (int i = 0; i < ilist.Length; i++)
            {
                ilist[i] = "";
                ilist_c[i] = "";
                tlist[i].GetComponent<Text>().text = "";
            }
        }

        for (int i = 0; i < 10; i++)
        {
            ilist[i] = ilist_c[i];
            blist[i].gameObject.SetActive(true);
            tlist[i].GetComponent<Text>().text = ilist_c[i];

            if (ilist[i] == "")
            {
                blist[i].gameObject.SetActive(false);
            }
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

        Reloadlist();
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
                ilist[i] = "";
            }

        }
        Reloadlist();
        return ilist[0];
    }

    public void Reloadlist()
    {
        for (int i = 0; i < 10; i++)
        {
            ilist_c[i] = ilist[i];
        }

        //for (int i = 0; i > 10; i++)
        //{
        //    if (ilist_c[1] != "")
        //    {
        //        blist[i].gameObject.SetActive(true);
        //        tlist[i].GetComponent<Text>().text = ilist_c[i];
        //    }
        //}

    }

}
