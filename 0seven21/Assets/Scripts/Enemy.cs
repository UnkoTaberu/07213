using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    [SerializeField]
    SceneController scontroller;
    [SerializeField]
    HpBarCtrl hbc;

    Transform mytransform;

    //プレイヤーの位置
    Vector3 player_tmp;

    int enemy_num = 0;
    int max_x = 0;
    int max_y = 0;
    int cost_max = 100;

    //コストを保持
    int[] enemy_cost = new int[10];

    //偶数カウントを保持
    int[] count_x = new int[4];
    int[] count_y = new int[4];

    // Use this for initialization
    void Start()
    {
        //   e_tmp = GameObject.Find("teki1(Clone)").transform.position;
        Vector3 e_tmp = transform.position;
        player_tmp = GameObject.Find("Player").transform.position;

        mytransform = this.transform;
        GameObject sc = GameObject.Find("SceneController");
        scontroller = sc.gameObject.GetComponent<SceneController>();

        Slider slider = GameObject.Find("Slider").GetComponent<Slider>();
        hbc = slider.gameObject.GetComponent<HpBarCtrl>();

    }

    // Update is called once per frame
    public void EnemyMove()
    {

        player_tmp = GameObject.Find("Player").transform.position;
        Vector3 e_tmp = transform.position;
        mytransform = this.transform;

        cost_max = 100;
        enemy_num = 0;
        max_x = 0;
        max_y = 0;

        int count = 1;
        int count_move = 0;
        int count_count = 0;

        //移動できるか
        for (int xx = (int)e_tmp.x - 1; (int)e_tmp.x + 2 != xx; xx++)
        {
            for (int yy = (int)e_tmp.y + 1; (int)e_tmp.y - 2 != yy; yy--)
            {

                Debug.Log(xx + "  " + yy);

                Debug.Log(count);
                //壁じゃない　かつ　自身の位置　ではない
                if (scontroller.map[xx, yy] != 0 && scontroller.map[xx, yy] != scontroller.map[(int)e_tmp.x, (int)e_tmp.y])
                {

                    //コスト計算
                    enemy_cost[enemy_num] = Math.Abs(xx - (int)player_tmp.x) + Math.Abs(yy - (int)player_tmp.y);

                    //一番低いコストを保持
                    if (cost_max > enemy_cost[enemy_num])
                    {
                        cost_max = enemy_cost[enemy_num];

                        max_x = xx;
                        max_y = yy;

                        count_move = count;



                    }

                    enemy_num++;
                }

                //偶数の座標を保持
                if (count % 2 == 0)
                {
                    count_x[count_count] = xx;
                    count_y[count_count] = yy;

                    count_count++;
                }

                count++;
            }
        }

        int xxx = 0;
        int yyy = 0;

        Debug.Log("カウントコスト" + count_move);
        if (count_move % 2 != 0)
        {
            //斜め上に移動しようとしている
            if (count_move % 3 != 0)
            {
                //左上の場合
                if (count_move == 1)
                {
                    //2を評価
                    xxx = count_x[0];
                    yyy = count_y[0];
                    if (scontroller.map[xxx, yyy] == 0)
                    {
                        //4を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[1];
                        yyy = count_y[1];
                        if (scontroller.map[xxx, yyy] != 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[xxx, yyy] != 4 && scontroller.map[xxx, yyy] != 8)
                            {
                                e_tmp.x = xxx;
                                e_tmp.y = yyy;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }

                        }
                    }
                    else if (scontroller.map[xxx, yyy] != 0)
                    {
                        //4を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[1];
                        yyy = count_y[1];
                        if (scontroller.map[xxx, yyy] == 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[count_x[0], count_y[0]] != 4 && scontroller.map[count_x[0], count_y[0]] != 8)
                            {
                                e_tmp.x = count_x[0];
                                e_tmp.y = count_y[0];
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                        else if (scontroller.map[xxx, yyy] != 0)
                        {
                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[max_x, max_y] != 4)
                            {
                                e_tmp.x = max_x;
                                e_tmp.y = max_y;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                }

                //右上の場合
                if (count_move == 7)
                {
                    //4を評価
                    xxx = 0;
                    yyy = 0;
                    xxx = count_x[1];
                    yyy = count_y[1];
                    if (scontroller.map[xxx, yyy] == 0)
                    {
                        //8を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[3];
                        yyy = count_y[3];
                        if (scontroller.map[xxx, yyy] != 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[xxx, yyy] != 4 && scontroller.map[xxx, yyy] != 8)
                            {
                                e_tmp.x = xxx;
                                e_tmp.y = yyy;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                    else if (scontroller.map[xxx, yyy] != 0)
                    {

                        //8を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[3];
                        yyy = count_y[3];
                        if (scontroller.map[xxx, yyy] == 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[count_x[1], count_y[1]] != 4 && scontroller.map[count_x[1], count_y[1]] != 8)
                            {
                                e_tmp.x = count_x[1];
                                e_tmp.y = count_y[1];
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                        else if (scontroller.map[xxx, yyy] != 0)
                        {
                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[max_x, max_y] != 4)
                            {
                                e_tmp.x = max_x;
                                e_tmp.y = max_y;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                }

            }
            else if (count_move % 3 == 0) //斜め下の場合
            {
                //左下の場合
                if (count_move == 3)
                {
                    //2を評価
                    xxx = 0;
                    yyy = 0;
                    xxx = count_x[0];
                    yyy = count_y[0];
                    if (scontroller.map[xxx, yyy] == 0)
                    {
                        //6を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[2];
                        yyy = count_y[2];
                        if (scontroller.map[xxx, yyy] != 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[xxx, yyy] != 4 && scontroller.map[xxx, yyy] != 8)
                            {
                                e_tmp.x = xxx;
                                e_tmp.y = yyy;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                    else if (scontroller.map[xxx, yyy] != 0)
                    {
                        //6を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[2];
                        yyy = count_y[2];
                        if (scontroller.map[xxx, yyy] == 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[count_x[0], count_y[0]] != 4 && scontroller.map[count_x[0], count_y[0]] != 8)
                            {
                                e_tmp.x = count_x[0];
                                e_tmp.y = count_y[0];
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                        else if (scontroller.map[xxx, yyy] != 0)
                        {
                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[max_x, max_y] != 4)
                            {
                                e_tmp.x = max_x;
                                e_tmp.y = max_y;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                }

                //右下の場合
                if (count_move == 9)
                {
                    //6を評価
                    xxx = 0;
                    yyy = 0;
                    xxx = count_x[2];
                    yyy = count_y[2];
                    if (scontroller.map[xxx, yyy] == 0)
                    {
                        //8を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[3];
                        yyy = count_y[3];
                        Debug.Log("座標 " + xxx + "  " + yyy);
                        if (scontroller.map[xxx, yyy] != 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[xxx, yyy] != 4 && scontroller.map[xxx, yyy] != 8)
                            {
                                e_tmp.x = xxx;
                                e_tmp.y = yyy;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                    else if (scontroller.map[xxx, yyy] != 0)
                    {
                        //8を評価
                        xxx = 0;
                        yyy = 0;
                        xxx = count_x[3];
                        yyy = count_y[3];
                        if (scontroller.map[xxx, yyy] == 0)
                        {

                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[count_x[2], count_y[2]] != 4 && scontroller.map[count_x[2], count_y[2]] != 8)
                            {
                                e_tmp.x = count_x[2];
                                e_tmp.y = count_y[2];
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                        else if (scontroller.map[xxx, yyy] != 0)
                        {
                            Debug.Log("結果 " + max_x + "  " + max_y);
                            if (scontroller.map[max_x, max_y] != 4)
                            {
                                e_tmp.x = max_x;
                                e_tmp.y = max_y;
                                EnemyWas(scontroller.map);
                                mytransform.position = e_tmp;
                                EnemyNow(scontroller.map);
                            }
                            else
                            {
                                hbc.HpDamage();
                            }
                        }
                    }
                }
            }
        }
        else if (count_move % 2 == 0)//横の場合
        {
            Debug.Log("結果 " + max_x + "  " + max_y);
            if (scontroller.map[max_x, max_y] != 4)
            {
                e_tmp.x = max_x;
                e_tmp.y = max_y;
                EnemyWas(scontroller.map);
                mytransform.position = e_tmp;
                EnemyNow(scontroller.map);
            }
            else
            {
                hbc.HpDamage();
            }
        }

        ////進む方向を評価
        ////斜めの場合
        //if(count_move % 2 != 0)
        //{

        //}



    }

    public void EnemyNow(int[,] map)
    {
        //e_tmp = GameObject.Find("teki1(Clone)").transform.position;
        Vector3 e_tmp = transform.position;

        int x = 0, y = 0;

        x = (int)e_tmp.x;
        y = (int)e_tmp.y;

        map[x, y] = 8;

        //enemy_map = new int[generator.width, generator.height];

        //// マップを複製
        //for (int e_x = 0; e_x != generator.width; x++)
        //{
        //    for (int e_y = 0; e_y != generator.height; y++)
        //    {
        //        enemy_map[e_x, e_y] = map[e_x, e_y];
        //    }
        //}
    }
    public void EnemyWas(int[,] map)
    {
        //Vector3 e_tmp = GameObject.Find("teki1(Clone)").transform.position;
        Vector3 e_tmp = transform.position;

        int x = 0, y = 0;

        x = (int)e_tmp.x;
        y = (int)e_tmp.y;

        map[x, y] = 1;
    }
}
