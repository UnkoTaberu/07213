using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pick_Up : MonoBehaviour {

    void Start()
    {
        
    }
    void Update()
    {
        Vector3 player = GameObject.Find("Player").transform.position;
        Vector3 item = this.transform.position;

        if(player.x == item.x && player.y == item.y)
        {
            Destroy(this.gameObject);
        }

    }

}
