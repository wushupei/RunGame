using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailPanle : MonoBehaviour
{
    public static FailPanle instance;
    public Image black;

    // Use this for initialization
    void Start ()
    {
        instance = this;
        this.gameObject.SetActive(false);
        black.gameObject.SetActive(false);
        this.transform.Find("beginbtn").GetComponent<Button>().onClick.AddListener(BeginGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //重新开始游戏
    public void BeginGame()
    {
        SceneManager.LoadScene("RunGame");
        Time.timeScale = 1;      //游戏继续
    }
}
