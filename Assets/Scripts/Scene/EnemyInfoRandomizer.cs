using System.Collections.Generic;
using UnityEngine;

public class EnemyInfoRandomizer : MonoBehaviour
{
    [SerializeField] private List<EnemyInfo> _enemiesInfo;

    private int[] _enemySettings;

    private void Start()
    {
        foreach (var enemy in _enemiesInfo)
        {
            _enemySettings = new int[3] { Random.Range(0, enemy.CountMaterials), Random.Range(0, enemy.CountFlags), Random.Range(0, enemy.CountNames) };
            enemy.SetInfo(_enemySettings[0], _enemySettings[1], _enemySettings[2]);
        }
    }
}
