using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public static EndUI Instance;
    [SerializeField] private GameObject GameClearUI;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private GameObject DeathUI;
    private float timeCount = 0;


    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        timeCount += Time.deltaTime;
    }

    public void GameClear()
    {
        TimeText.text = $"Time: {timeCount}s";
        GameClearUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Death()
    {
        DeathUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameClearUI.SetActive(false);
        DeathUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
