using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    [SerializeField]
    DungeonGenerator generator;

    [SerializeField]
    Train_Object Train;

    [SerializeField]
    Transform ItemtileContainer;

    [SerializeField]
    Transform StepstileContainer;

    public int[,] spmap;
    [Range(0, 20)]
    public int sp_capacity = 3;
    

    public void SpGenerate(int[,] map)
    {
        int x = 0, y = 0, i = 0;

        spmap = new int[generator.width, generator.height];

        // マップを複製
        for (x = 0; x != generator.width; x++)
        {
            for (y = 0; y != generator.height; y++)
            {
                spmap[x, y] = map[x, y];
            }
        }

        // アイテム、階段を配置
        while (i != sp_capacity + 1)
        {
            System.Random rx = new System.Random();
            System.Random ry = new System.Random(rx.Next());

            if (spmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1 && i != sp_capacity) // アイテムを配置
            {
                spmap[x, y] = 3;
                var tile = Instantiate(Train.ItemTrain[rx.Next(Train.ItemTrain.Length - 1)]);
                tile.transform.SetParent(ItemtileContainer);
                tile.transform.localPosition = new Vector2(x, y);
                tile.AddComponent<Item_Pick_Up>();

                i++;

            }else if(i == sp_capacity) //階段を配置
            {
                if (spmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
                {
                    spmap[x, y] = 2;
                    var tile = Instantiate(Train.ItemTrain[10]);
                    tile.transform.SetParent(StepstileContainer);
                    tile.transform.localPosition = new Vector2(x, y);

                    i++;
                }
            }

        }

    }

    //public void StepsGenerate(int[,] map)
    //{
    //    int x = 0, y = 0, i = 0;
    //    steps.gameObject.SetActive(true);

    //    stepsmap = new int[generator.width, generator.height];

    //    for (x = 0; x != generator.width; x++)
    //    {
    //        for (y = 0; y != generator.height; y++)
    //        {
    //            stepsmap[x, y] = map[x, y];
    //        }
    //    }

    //    while (i != 1)
    //    {
    //        System.Random rx = new System.Random();
    //        System.Random ry = new System.Random();
    //        if (itemmap[x = rx.Next(generator.width), y = ry.Next(generator.height)] == 1)
    //        {
    //            stepsmap[x, y] = 2;
    //            var tile = Instantiate(steps);
    //            tile.transform.SetParent(StepstileContainer);
    //            tile.transform.localPosition = new Vector2(x, y);

    //            i++;
    //        }

    //    }
    //}

}
