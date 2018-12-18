using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //Rigidbody2D rigidbodyCache;
    [SerializeField]
    DungeonGenerator generator;
    [SerializeField]
    SceneController scontroller;
    [SerializeField]
    RandomGenerator r_generator;
    [SerializeField]
    private GameObject propertyWindow;
    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;

    public OperationStatusWindow playerScript;

    int x = 0, y = 0, i = 0;
    int a = 0;


    void Start()
    {
       


        //rigidbodyCache = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (a == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                WallFrag(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                WallFrag(1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                WallFrag(0, 1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                WallFrag(0, -1, 0);
            }
        }
      

        Vector3 tmp = GameObject.Find("Player").transform.position;
        if (r_generator.spmap[(int)tmp.x, (int)tmp.y] == 2) //階段の上に乗った時
        {
            
            if (a == 0)
            {
                propertyWindow.SetActive(!propertyWindow.activeSelf);
                //　MainWindowをセット
                ChangeWindow(windowLists[2]);

                a = 1;
            }

            //   rigidbodyCache.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 10f);
          
        }
        //else if(a == 1)
        //{
        //    propertyWindow.SetActive(!propertyWindow.activeSelf);
        //    //　MainWindowをセット
        //   // ChangeWindow(windowLists[2]);

        //    a = 0;

        //}

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

    public void WallFrag(int x2, int y2, int z2)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        x = (int)tmp.x;
        y = (int)tmp.y;
        if (scontroller.map[x + x2, y + y2] != 0)
        {
            transform.Translate(x2, y2, z2);
        }
    }

    public void PlayerPut(int[,] map)
    {
        //var floors = GameObject.FindGameObjectsWithTag("Floor");
        //transform.position = floors[Random.Range(0, floors.Length)].transform.position;

        while (i != 1)
        {
            System.Random ry = new System.Random();
            System.Random rx = new System.Random(ry.Next());
            if (map[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
            {
                //              transform.Translate(x,y,0);

                Vector3 tmp = GameObject.Find("Player").transform.position;
                tmp.x = x;
                tmp.y = y;
                transform.position = tmp;
                i++;
            }

        }
    }

}
