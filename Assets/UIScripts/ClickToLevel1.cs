using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickToLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        /*SceneManager.LoadScene("Scenes/Level_1");*/

        SceneManager.LoadScene("AEND/TalkScence1");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
