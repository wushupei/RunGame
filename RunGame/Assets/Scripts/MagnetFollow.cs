using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFollow : MonoBehaviour
{
    //找到金币移动到的目标点
    public GameObject AllCoin;
    //找到方块
    public GameObject player;
    //是否跟着移动
    public bool IsFollow = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsFollow == true)
        {
            //跟着玩家移动
            transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y + 1, transform.position.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("coin"))
        {
            coll.GetComponent<Coin>().IsRun = true;          
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            IsFollow = true;
        }
    }
}
