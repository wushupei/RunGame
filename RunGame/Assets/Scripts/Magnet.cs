using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    //找到玩家
    public GameObject player;
    //找到血量条
    public GameObject MagnetHp;
    //找到HP图片
    public Image HpPhoto;
    //HP数值
    public float Hp;
    //是否移动
    public bool IsFollow = false;

	// Use this for initialization
	void Start ()
    {
        Hp = HpPhoto.rectTransform.localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (IsFollow==true)
        {
            //改变Rotation
            transform.eulerAngles = new Vector3(0,0,0);
            transform.localScale = new Vector3(0.17f, 0.17f, transform.localScale.z);
            transform.position = new Vector3(player.transform.position.x-0.5f, player.transform.position.y+1, transform.position.z);
            player.GetComponent<PlayerMove>().Hp.gameObject.SetActive(true);
            Hp = Hp - 0.002f;
            if(Hp<0)
            {
                Hp = 0;
                Destroy(transform.parent.gameObject);     //销毁磁铁
                Destroy(MagnetHp);      //销毁血条
            }

            //实时更新面板上的HP数值
            HpPhoto.rectTransform.localScale = new Vector3(Hp, HpPhoto.rectTransform.localScale.y, HpPhoto.rectTransform.localScale.z);
        }
        else
        {
            transform.Rotate(Vector3.up * 3, Space.World);    //世界坐标原地旋转
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            IsFollow = true;
        }
    }
}
