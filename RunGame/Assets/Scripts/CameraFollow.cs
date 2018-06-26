using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //transform.position = new Vector3(player.transform.position.x + 5, transform.position.y, transform.position.z);

        if(player.transform.position.x>60 && player.transform.position.x < 170)
        {
            transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y + 2, transform.position.z);
        }
        else
        {
            //让相机跟着玩家移动
            transform.position = new Vector3(player.transform.position.x + 5, 0 , transform.position.z);
        }
    }
}
