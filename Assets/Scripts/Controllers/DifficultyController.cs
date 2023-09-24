using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] private CollectiblesSpawner _collectiblesSpawner;
    [SerializeField] private UIController _uiController;
    [SerializeField] private int _speedUpScoreInterval;
    [SerializeField] private float _speedUpFactor;
    [SerializeField] private float _giveMeABreakInterval;


    private void Start()
    {
        GameManager.Instance.RegisterDifficultyController(this);
    }

    internal void ManageDificulty(float score)
    {
        if (score % _speedUpScoreInterval == 0)
        {
            HurryUpIndicator();
            if (score % (2 * _speedUpScoreInterval) == 0)
                IncreaseSpeed();
            else
                DecreaseInterval();

            if (score % _giveMeABreakInterval == 0)
                DoubleSpeedUpInterval();
        }
    }

    private void HurryUpIndicator()
    {
        _uiController.HurryUp();
    }

    private void IncreaseSpeed()
    {
        _collectiblesSpawner.SetSpawnableInterval(1f - _speedUpFactor);
    }

    private void DecreaseInterval()
    {
        _collectiblesSpawner.SetSpawnInterval(1f - _speedUpFactor);
    }

    private void DoubleSpeedUpInterval()
    {
        _speedUpScoreInterval *= 2;
    }
}
