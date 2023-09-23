using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _maxFails;/*
    [SerializeField] private float _startSpawnInterval;
    [SerializeField] private float _startFallingInterval;*/
    [SerializeField] private int _upspeedScoreInterval;
    [SerializeField] private float _upspeedFactor;
    public static GameManager Instance { get; private set; }

    private int _score;
    private int _fails;
    private int _startHighScore;
    private bool _isGameOver;

    private PlayerController _player;
    private EggsSpawner _eggSpawner;
    private RunawayChickenSpawner _runawayChickenSpawner;
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
            ManageDificulty();

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
        _eggSpawner.enabled = false;
        _isGameOver = true;
        _player.gameObject.SetActive(false);
        _uiController.GameOver(_score, _score > _startHighScore);
        AudioController.PlayGameOver();
    }

    internal void RegisterEggSpawner(EggsSpawner eggsSpawner)
    {
        _eggSpawner = eggsSpawner;
        _eggSpawner.enabled = true;
    }

    public void ResetStats()
    {
        _isGameOver = false;
        _score = 0;
        _fails = 0;
    }

    private void ManageDificulty()
    {
        if(_score % _upspeedScoreInterval == 0)
        {
            HurryUp();
            if (_score % (2 * _upspeedScoreInterval) == 0)
                IncreaseSpeed();
            else
                DecreaseInterval();
        }
    }

    private void IncreaseSpeed()
    {
        _eggSpawner.SetSpawnableInterval(1f - _upspeedFactor);
    }

    private void DecreaseInterval()
    {
        _eggSpawner.SetSpawnInterval(1f - _upspeedFactor);
    }

    private void HurryUp()
    {
        _uiController.HurryUp();
    }
}
