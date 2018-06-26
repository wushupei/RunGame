using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float speed = 5;
    public float upspeed = 6;
    public Text MoneyText;
    public int money;
    public bool IsJump = false;
    public GameObject Hp;
    public bool IsStop = false;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        money = 0;
        SetMoney();
        Hp.gameObject.SetActive(false);
    }

    public void SetMoney()      //改变金币数量
    {
        MoneyText.text = money.ToString();
    }

    //碰到火焰就失败
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("fire"))
        {
            FailPanle.instance.gameObject.SetActive(true);
            FailPanle.instance.black.gameObject.SetActive(true);     
            Time.timeScale = 0;                              //游戏暂停 3是游戏加速
        }
        if (coll.gameObject.CompareTag("failground"))
        {
            FailPanle.instance.gameObject.SetActive(true);
            FailPanle.instance.black.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (coll.gameObject.CompareTag("success"))
        {
            SuccessPanel.instance.gameObject.SetActive(true);
            IsStop = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (IsStop==false)
        {
            //一直向右运动
            myRigidbody.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        float hight = GetComponent<BoxCollider2D>().bounds.size.y;

        //按下空格键可以使方块跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down,hight, LayerMask.GetMask("ground")))
            {
                myRigidbody.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);    //给它一个向上的力
            }
            if (Physics2D.Raycast(transform.position, Vector2.down, hight, LayerMask.GetMask("ceiling")))
            {
                myRigidbody.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);    //给它一个向上的力
            }
        }

        if (transform.localScale.x>0.3)
        {
            //按下A键可以缩小方块
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
                speed = speed + 0.05f;
                upspeed = upspeed + 0.05f;
            }
        }
        if(transform.localScale.x <=1)
        {
            //按下D键可以变大方块
            if (Input.GetKey(KeyCode.D))
            {
                //检测到方块上面是天花板则不能变大
                if (Physics2D.Raycast(transform.position, Vector2.up, 0.5f*hight, LayerMask.GetMask("ceiling")))
                {

                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);
                    speed = speed - 0.05f;
                    upspeed = upspeed - 0.05f;
                }
            }
        }
    }
}
