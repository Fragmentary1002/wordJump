using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [Header("enemy")]
    public Enemy enemyPrototype;
    public string word;
    public int length;
    public int min;
    public int max;
    [Header("positon")]
    public int positionNum;
    public Transform lowerLeft;
    public Transform upperRight;
    // public GameObject tag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CreateEnemy()
    {
        EnemyCreater.Create(RandomString.GetString(word, length, min, max), enemyPrototype, CreatePositons());
        // foreach (var item in RandomWord.GetWords(10))
        // {
        //     Debug.Log(item);
        // }
    }
    List<Vector3> CreatePositons()
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < positionNum; i++)
            positions.Add(new Vector3(Random.Range(lowerLeft.position.x, upperRight.position.x), Random.Range(lowerLeft.position.y, upperRight.position.y)));
        return positions;
    }
}
