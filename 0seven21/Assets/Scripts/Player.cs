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

    [SerializeField]
    Enemy[] enemy;
    //[SerializeField]
    //Enemy enemy;

    // 長押しフレーム数
    private int presskeyFrames = 0;
    // 長押し判定の閾値（フレーム数）
    private int thresholdLong = 15;
    // 軽く押した判定の閾値（フレーム数）
    private int thresholdShort = 0;
    private float timeleft;

    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;

    public OperationStatusWindow playerScript;

    // ButttonEvent用
    public GameObject targetObject;

    // OperationStatusWindow用
    public GameObject StatusObject;

    int x = 0, y = 0, i = 0;

    // 階段判別用
    public int Stairs = 0;

    Animator anim;

    void Start()
    {
        anim = GetComponent("Animator") as Animator;

        var enemytile = GameObject.Find("EnemyTileContainer").GetComponentsInChildren<Transform>();
        int i = 0;
        foreach (Transform child in enemytile)
        {

            enemy[i] = child.gameObject.GetComponent<Enemy>();
            i++;
        }
    }

    void Update()
    {
        // ButtonEventから値を取得
        int btn = targetObject.GetComponent<ButtonEvent>().canselBtn;

        // OperationStatusWindowから値を取得
        int ops = StatusObject.GetComponent<OperationStatusWindow>().menuOpen;

        // 階段の上、メニュー画面を開いていない場合
        if (Stairs == 0 && ops != 2 || btn == 1 && ops != 2)
        {
            presskeyFrames += (
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W)) ? 1 : 0;

            if (Input.GetKeyUp(KeyCode.A)) presskeyFrames = 0;
            if (Input.GetKeyUp(KeyCode.S)) presskeyFrames = 0;
            if (Input.GetKeyUp(KeyCode.D)) presskeyFrames = 0;
            if (Input.GetKeyUp(KeyCode.W)) presskeyFrames = 0;

            if (thresholdLong <= presskeyFrames)
            {
                //長押し
                timeleft -= Time.deltaTime;
                if (timeleft <= 0.0)
                {
                    timeleft = 0.2f;
                    if (Input.GetKey(KeyCode.A))
                    {
                        WallFrag(-1, 0, 0);
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        WallFrag(1, 0, 0);
                    }
                    else if (Input.GetKey(KeyCode.W))
                    {
                        WallFrag(0, 1, 0);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        WallFrag(0, -1, 0);
                    }
                }
            }
            else if (thresholdShort <= presskeyFrames)
            {
                //短押し
                if (Input.GetKeyDown(KeyCode.A))
                {
                    WallFrag(-1, 0, 0);
                    anim.SetInteger("isWalk", 2);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    WallFrag(1, 0, 0);
                    anim.SetInteger("isWalk", 3);
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    WallFrag(0, 1, 0);
                    anim.SetInteger("isWalk", 1);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    WallFrag(0, -1, 0);
                    anim.SetInteger("isWalk", 0);
                }
            }

        }
      
        Vector3 tmp = GameObject.Find("Player").transform.position;

        //階段の上に乗った時
        if (r_generator.spmap[(int)tmp.x, (int)tmp.y] == 2)
        {
            
            if (Stairs == 0)
            {
                propertyWindow.SetActive(!propertyWindow.activeSelf);
                //　MainWindowをセット
                ChangeWindow(windowLists[2]);

                Stairs = 1;
            }

            //   rigidbodyCache.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 10f);
          
        }
        // 階段から移動した時
        else if (Stairs == 1)
        {
            Stairs = 0;

            targetObject.GetComponent<ButtonEvent>().canselBtn = Stairs;

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

    public void WallFrag(int x2, int y2, int z2)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        x = (int)tmp.x;
        y = (int)tmp.y;
        if (scontroller.map[x + x2, y + y2] != 0 && scontroller.map[x + x2, y + y2] != 8)
        {
            PlayerWas(scontroller.map);
            //enemy.EnemyWas(scontroller.map);
            transform.Translate(x2, y2, z2);
            PlayerNow(scontroller.map);

            for (int i = 1; i < 4; i++)
            {
                //Debug.Log(enemy[i]);
                enemy[i].EnemyMove();
            }
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

    public void PlayerNow(int[,] map)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;

        int x = 0, y = 0;

        x = (int)tmp.x;
        y = (int)tmp.y;

        map[x, y] = 4;

    }

    public void PlayerWas(int[,] map)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;

        int x = 0, y = 0;

        x = (int)tmp.x;
        y = (int)tmp.y;

        map[x, y] = 1;
    }

}
