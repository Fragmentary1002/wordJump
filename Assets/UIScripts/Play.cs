using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene("AEND/Level_select");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
