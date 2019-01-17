using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    [SerializeField]
    SceneController scontroller;

    Transform mytransform;

    //プレイヤーの位置
    Vector3 player_tmp;

    int enemy_num = 0;
    int max_x = 0;
    int max_y = 0;
    int cost_max = 100;

    //コストを保持
    int[] enemy_cost = new int[10];

    //hpbar用
    [SerializeField]
    HpBarCtrl hbc;

    // Use this for initialization
    void Start()
    {
        //   e_tmp = GameObject.Find("teki1(Clone)").transform.position;
        Vector3 e_tmp = transform.position;
        player_tmp = GameObject.Find("Player").transform.position;

        mytransform = this.transform;
        GameObject sc = GameObject.Find("SceneController");
        scontroller = sc.gameObject.GetComponent<SceneController>();

        //hpbar用
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

        //移動できるか
        for (int xx = (int)e_tmp.x - 1; (int)e_tmp.x + 2 != xx; xx++)
        {
            for (int yy = (int)e_tmp.y - 1; (int)e_tmp.y + 2 != yy; yy++)
            {

                //Debug.Log(xx + "  " + yy);
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
                    }
                    enemy_num++;
                }

            }
        }



        //Debug.Log("結果 " + max_x + "  " + max_y);
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
