using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowMove : MonoBehaviour
{
    public GameObject player;
    public Sprite tupian;
    public GameObject rainbowwall;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * 4,Space.World);    //世界坐标原地旋转
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            player.GetComponent<SpriteRenderer>().sprite = tupian;
            rainbowwall.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
