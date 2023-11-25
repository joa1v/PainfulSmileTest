using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _closeOptionsButton;

    [SerializeField] private int _gameSceneIndex;
    [SerializeField] private GameObject _optionsPanel;

    private void Awake()
    {
        _playButton.onClick.AddListener(StartGame);

        _optionsButton.onClick.AddListener(()=> SetOptionsPanel(true));
        _closeOptionsButton.onClick.AddListener(()=> SetOptionsPanel(false));

        SetOptionsPanel(false);
    }

    private void SetOptionsPanel(bool set)
    {
        _optionsPanel.SetActive(set);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }
}
