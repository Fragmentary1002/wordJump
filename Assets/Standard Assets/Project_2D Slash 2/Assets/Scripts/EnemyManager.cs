using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [Header("enemy")]
    public Enemy enemyPrototype;
    public int length;
    public int min;
    public int max;
    [Header("positon")]
    public int positionNum;
    public Transform lowerLeft;
    public Transform upperRight;

    Dictionary<char, List<Enemy>> enemies = new Dictionary<char, List<Enemy>>();
    public Dictionary<char, int> KillCount = new Dictionary<char, int>();

    void Awake()
    {
        Instance = this;
        for (char c = 'A'; c <= 'Z'; c++)
        {
            enemies[c] = new List<Enemy>();
            KillCount[c] = 0;
        }
    }



    public void CreateEnemy()
    {
        EnemyCreater.Create(RandomString.GetString(WordManager.Instance.Word, length, min, max), enemyPrototype, _createPositons());
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!enemies.ContainsKey(enemy.Character))
        {
            enemies[enemy.Character] = new List<Enemy>();
        }
        enemies[enemy.Character].Add(enemy);

    }

    public void KillEnemy(Enemy enemy)
    {
        KillCount[enemy.Character]++;
        enemies[enemy.Character].Remove(enemy);
        enemy.Death();
        WordManager.Instance.Reflesh();
    }

    public void KillAll(char c)
    {
        List<Enemy> list = enemies[c];
        while (list.Count > 0)
        {
            KillEnemy(list[0]);
        }
    }

    private List<Vector3> _createPositons()
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < positionNum; i++)
            positions.Add(new Vector3(Random.Range(lowerLeft.position.x, upperRight.position.x), Random.Range(lowerLeft.position.y, upperRight.position.y)));
        return positions;
    }
}
