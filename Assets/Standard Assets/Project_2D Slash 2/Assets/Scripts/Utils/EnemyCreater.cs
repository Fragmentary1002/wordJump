using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater
{
    /// <summary>
    /// 在候选坐标点中随机生成敌人，敌人数量与字符串长度相同
    /// </summary>
    /// <param name="enemyStr">敌人标识字符串</param>
    /// <param name="enemyPrototype">敌人原型</param>
    /// <param name="positions">候选坐标点</param>
    public static void Create(string enemyStr, IPrototype enemyPrototype, List<Vector3> positions)
    {
        Debug.Log("Enemystr = " + enemyStr);
        SetEnemyByPosition(positions, CreatEnemy(enemyStr, enemyPrototype));
    }


    /// <summary>
    /// 根据字符串创建相应敌人
    /// </summary>
    /// <param name="str">敌人标识字符串</param>
    /// <param name="enemyPrototype">敌人原型</param>
    /// <returns></returns>
    static GameObject[] CreatEnemy(string str, IPrototype enemyPrototype)
    {
        GameObject[] enemies = new GameObject[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            enemies[i] = enemyPrototype.Clone(str[i], true);
        }

        return enemies;
    }

    /// <summary>
    /// 随机设置敌人位置
    /// </summary>
    /// <param name="positions">候选坐标点</param>
    /// <param name="enemies">敌人实体</param>
    static void SetEnemyByPosition(List<Vector3> positions, GameObject[] enemies)
    {
        if (positions.Count < enemies.Length)
        {
            Debug.LogWarningFormat("坐标数量{0}小于敌人数量{1}，无法生成相应数量敌人", positions.Count, enemies.Length);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            int index = Random.Range(0, positions.Count);
            enemies[i].transform.position = positions[index];
            positions.RemoveAt(index);
        }
    }
}
