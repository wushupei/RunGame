using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground7LeftMove : MonoBehaviour
{
    bool IsChange = false;
    float nowx;

    // Use this for initialization
    void Start ()
    {
        nowx = transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < nowx - 7)
        {
            IsChange = true;
        }
        if (transform.position.x > nowx + 7)
        {
            IsChange = false;
        }

        if (IsChange == false)
        {
            transform.Translate(-6 * Time.deltaTime, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(6 * Time.deltaTime, 0, 0, Space.World);
        }
    }
}
