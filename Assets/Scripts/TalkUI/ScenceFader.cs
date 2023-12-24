using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenceFader : MonoBehaviour
{
    // Start is called before the first frame update
    public Image blackimage;
    public GameObject image;
    [SerializeField] private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
        
    }

    public void FadeTo(string senceName)
    {
        StartCoroutine(Fadeout(senceName));
    }

    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            blackimage.color = new Color(0, 0, alpha);
            
            yield return new WaitForSeconds(0);
        }
        image.SetActive(false);
    }

    IEnumerator Fadeout(string scenceName)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackimage.color = new Color(0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene("Scenes/Level_1");
    }
}
