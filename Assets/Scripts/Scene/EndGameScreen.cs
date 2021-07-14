using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private List<EnemyHealth> _enemies;

    [SerializeField] private GameObject _winGameScreen;
    [SerializeField] private GameObject _loseGameScreen;

    [SerializeField] private float _secondsBetweenStop = 1;

    private void OnEnable()
    {
        _playerAttack.OnDestroyObject += OnRemoveDeadEnemies;
        _playerHealth.PlayerDead += ShowLoseScreen;
    }

    private void OnDisable()
    {
        _playerAttack.OnDestroyObject -= OnRemoveDeadEnemies;
        _playerHealth.PlayerDead -= ShowLoseScreen;
    }

    private void Start()
    {
        Time.timeScale = 1;

        _winGameScreen.SetActive(false);
        _loseGameScreen.SetActive(false);
    }

    private void OnRemoveDeadEnemies()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.Health <= 0)
            {
                _enemies.Remove(enemy);
            }

            if (_enemies.Count == 0)
            {
                ShowWinScreen();
            }
        }
    }

    private void ShowWinScreen()
    {
        Time.timeScale = 0;
        _winGameScreen.SetActive(true);
    }

    private void ShowLoseScreen()
    {
        _playerAnimation.Die();
        _loseGameScreen.SetActive(true);
        StartCoroutine(StopTimeScale());
    }

    private IEnumerator StopTimeScale()
    {
        yield return new WaitForSeconds(_secondsBetweenStop);
        Time.timeScale = 0;
    }
}
