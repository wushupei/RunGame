using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessPanel : MonoBehaviour
{
    public static SuccessPanel instance;

    // Use this for initialization
    void Start ()
    {
        instance = this;
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
