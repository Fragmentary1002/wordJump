using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;/*�л�����������ӵ�ǰ׺*/

public class MoveToScene : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    public void ChangeScene()/*����һ���л�����*/
    {
        SceneManager.LoadScene("Menu");
    }
}

