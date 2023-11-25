using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [Header("End Game")]
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TextMeshProUGUI _pointsTxt;

    public Button PlayAgainButton => _playAgainButton;
    public Button MenuButton => _menuButton;
    public static LevelUIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        SetTimeText(GameSessionTimer.SessionTime);
    }

    public void SetEndGamePanel(bool set)
    {
        _endGamePanel.SetActive(set);
        int points = PointsManager.Points;
        _pointsTxt.text = $"Points: {points}";
    }

    public void SetTimeText(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        _timeText.text = $"{minutes}:{seconds}";
    }

}
