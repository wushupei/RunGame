using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedown : MonoBehaviour
{
    public bool isRun = true;
    public GameObject player;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isRun==true)
        {
            //玩家靠近绝对值距离小于4时火焰下落
            if (Mathf.Abs(player.transform.position.x-transform.position.x)<4)
            {
                transform.Translate(0, -9 * Time.deltaTime, 0, Space.World);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("ground"))
        {
            isRun = false;
        }
    }
}
