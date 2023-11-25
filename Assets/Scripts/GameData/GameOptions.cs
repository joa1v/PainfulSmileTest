using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    [SerializeField] private SliderWithText _gameSessionTimeSlider;
    [SerializeField] private SliderWithText _enemySpawnTimeSlider;

    private void Start()
    {
        SetCurrentOptions();
        _gameSessionTimeSlider.Slider.onValueChanged.AddListener(SetGameSessionTimer);
        _enemySpawnTimeSlider.Slider.onValueChanged.AddListener(SetEnemySpawnTimer);
    }

    private void SetGameSessionTimer(float value)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.GameSessionTime, (int)value);
    }

    private void SetEnemySpawnTimer(float value)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.EnemySpawnTime, (int)value);
    }

    private void SetCurrentOptions()
    {
        int sessionTime = PlayerPrefs.GetInt(PlayerPrefsKeys.GameSessionTime);
        int spawnTime = PlayerPrefs.GetInt(PlayerPrefsKeys.EnemySpawnTime);

        _gameSessionTimeSlider.Value = sessionTime;
        _enemySpawnTimeSlider.Value = spawnTime;
    }
}
