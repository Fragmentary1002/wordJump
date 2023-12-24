using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject playerPre, enemyPre;

    MapC mapC;
    int x = 20;
    int y = 10;

    void Start()
    {
        mapC = GetComponent<MapC>();
        mapC.Init(x, y);
        CreatePlayer();
        CreateEnemy(1);
    }

    void CreatePlayer()
    {
        GameObject player = Instantiate(playerPre, new Vector2(2, 2), Quaternion.identity);
        player.name = "Player";
        Camera.main.GetComponent<CameraFollow>().Init(player.transform, x, y);
    }

    void CreateEnemy(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject enemy = ObjectPool.Instance.Get(enemyPre);
            //Vector2 pos = mapC.GetNullPos();
            enemy.transform.position = new Vector2(10,2);
        }
    }
}
