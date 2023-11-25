using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _menuSceneId;
    [SerializeField] private GameSessionTimer _timer;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private PlayerShip _playerShip;

    private void OnEnable()
    {
        LevelUIManager.Instance.PlayAgainButton.onClick.AddListener(RestartGame);
        LevelUIManager.Instance.MenuButton.onClick.AddListener(ReturnToMenu);

        _timer.OnTimeEnded += EndGame;
        _playerShip.HealthPoints.OnDeath += EndGame;
    }

    private void OnDisable()
    {
        LevelUIManager.Instance.PlayAgainButton.onClick.RemoveListener(RestartGame);
        LevelUIManager.Instance.MenuButton.onClick.RemoveListener(ReturnToMenu);

        _timer.OnTimeEnded -= EndGame;
    }

    private void Start()
    {
        Debug.Log($"Game starting with time of {GameSessionTimer.SessionTime / 60} minutes and enemies spawning every {_spawner.SpawnTime} seconds");
    }

    public void EndGame()
    {
        SetPause(true);
        LevelUIManager.Instance.SetEndGamePanel(true);
    }

    private void SetPause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    private void RestartGame()
    {
        SetPause(false);
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        PointsManager.ResetPoints();
        SceneManager.LoadScene(currentSceneId);
    }

    private void ReturnToMenu()
    {
        SetPause(false);
        PointsManager.ResetPoints();
        SceneManager.LoadScene(_menuSceneId);
    }
}
