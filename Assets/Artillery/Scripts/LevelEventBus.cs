using System;
using UnityEngine;

public class LevelEventBus : MonoBehaviour
{
    public static LevelEventBus Instance { get; private set; }

    public Action OnEnemyDie;

    private void OnEnable()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}