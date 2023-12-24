using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash2 : Slash
{
    private void Start() {
        id=2;
    }
    protected override void effect(Enemy enemy)
    {
        Debug.Log($"Slash2 effect kill all enemy {enemy.Character}");
        // EnemyManager.Instance.KillAll(enemy.Character);
    }
}
