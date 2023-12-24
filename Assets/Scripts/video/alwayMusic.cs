using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwayMusic  : MonoBehaviour //脚本名与类名要一直,此代码脚本名为music
{
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}

