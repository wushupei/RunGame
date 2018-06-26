using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //找到方块
    public GameObject player;
    //找到金币移动到的目标点
    public GameObject AllCoin;
    //磁铁
    public GameObject magnet;
    //是否跟着移动
    public bool IsRun=false;
    //获取目标点的世界坐标
    public Vector3 UIcoin;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * 4, Space.World);    //原地旋转

        if (IsRun == true)
        {
            CoinMove();
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            IsRun = true;
        }
    }

    //金币向目标点移动
    public void CoinMove()
    {
        //UI坐标转换成世界坐标
        UIcoin = Camera.main.ScreenToWorldPoint(AllCoin.transform.position);

        //当前物体向这某一个物体移动
        transform.position = Vector3.MoveTowards(transform.position, UIcoin + Vector3.forward, 25 * Time.deltaTime);

        //两个坐标相减是方向,用sqrMagnitude获取方向的距离
        if ((transform.position - (UIcoin + Vector3.forward)).sqrMagnitude < 0.1f)
        {
            player.GetComponent<PlayerMove>().money++;
            player.GetComponent<PlayerMove>().SetMoney();
            Destroy(gameObject);
        }
    }
}

