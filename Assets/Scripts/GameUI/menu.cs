using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject menuxin;
    public bool isStop = true;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuxin.SetActive(true);
                isStop = false;
                Time.timeScale = (0);//游戏停止运行
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuxin.SetActive(false);
            isStop = true;
            Time.timeScale = (1);//游戏开始运行
        }
        
    }
    public void Resume()
    {
        menuxin.SetActive(false);
        Time.timeScale = (1);//游戏开始运行
    }
    public void zanting()
    {
        menuxin.SetActive(true);
        Time.timeScale = (0);//游戏暂停
    }
}
