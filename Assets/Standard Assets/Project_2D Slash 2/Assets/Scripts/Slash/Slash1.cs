using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash1 : Slash
{
    [SerializeField] int health = 1;

    private void Start() {
        id=1;
    }

    protected override void effect(Enemy enemy)
    {
        Debug.Log($"Slash1 effect health player hp {health}");
        PlayerController.Instance.HP += health;
        PlayerController.Instance.Life();
    }
}
