using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    //public float scrollSpeed = 0.5f;
    //public Renderer rend;

	// Use this for initialization
	void Start ()
    {
        //rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float offset = Time.time * scrollSpeed;
        //rend.material.mainTextureOffset = new Vector2(offset, 0);    //纹理偏移

        transform.position = new Vector3(transform.position.x-0.03f,transform.position.y,transform.position.z);
    }
}
