using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _maxFails;
    public static GameManager Instance { get; private set; }

    private int _score;
    private int _fails;
    private int _startHighScore;
    private bool _isGameOver;

    private PlayerController _player;
    private CollectiblesSpawner _collectiblesSpawner;
    private RunawayChickenSpawner _runawayChickenSpawner;
    private DifficultyController _difficultyController;
    private UIController _uiController;

    public int Score => _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _score = 0;
        _fails = 0;
        _startHighScore = PlayerPrefs.GetInt("highScore", 0);
        _isGameOver = false;
    }

    public void RegisterPlayer(PlayerController player)
    {
        _player = player;
    }

    public void RegisterUICOntroller(UIController uiController)
    {
        _uiController = uiController;
        _uiController.UpdateScore(_score);
        _uiController.UpdateScore(_fails);
    }

    public void RegisterRunawayChickenSpawner(RunawayChickenSpawner runawayChickenSpawner)
    {
        _runawayChickenSpawner = runawayChickenSpawner;
    }

    public void HandleEggFall(Egg egg)
    {
        if (_isGameOver) return;
        int highScore = PlayerPrefs.GetInt("highScore");
        if (egg.Origin == _player.PlayerPosition)
        {
            AudioController.PlayItemCollected();
            _score++;
            if (_score > highScore)
                PlayerPrefs.SetInt("highScore", _score);
            _uiController.UpdateScore(_score);
            _difficultyController.ManageDificulty(_score);

        }
        else
        {
            AudioController.PlayFailToCollect();
            _fails++;
            _runawayChickenSpawner.Spawn(egg.Origin);
            if(_fails <= _maxFails)
                _uiController.UpdateFails(_fails);
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        _collectiblesSpawner.enabled = false;
        _isGameOver = true;
        _player.gameObject.SetActive(false);
        _uiController.GameOver(_score, _score > _startHighScore);
        AudioController.PlayGameOver();
    }

    internal void RegisterCollectiblesSpawner(CollectiblesSpawner collectiblesSpawner)
    {
        _collectiblesSpawner = collectiblesSpawner;
        _collectiblesSpawner.enabled = true;
    }

    internal void RegisterDifficultyController(DifficultyController difficultyController)
    {
        _difficultyController = difficultyController;
    }

    public void ResetStats()
    {
        _isGameOver = false;
        _score = 0;
        _fails = 0;
    }
}
