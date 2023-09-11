using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunawayChickenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _runawayLeftPrefab, _runawayRightPrefab;
    [SerializeField] private Transform _leftSpawnTransform, _rightSpawnTransform;

    private void Start()
    {
        GameManager.Instance.RegisterRunawayChickenSpawner(this);
    }

    public void Spawn(BoardPosition eggOrigin)
    {
        if (eggOrigin == BoardPosition.TopLeft || eggOrigin == BoardPosition.BottomLeft)
        {
            Instantiate(_runawayLeftPrefab, _leftSpawnTransform);
        }
        else
        {
            Instantiate(_runawayRightPrefab, _rightSpawnTransform);
        }
    }
}
