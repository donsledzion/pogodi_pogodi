using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggsSpawner : MonoBehaviour
{
    [SerializeField] private RampSpawner[] _ramps;

    [SerializeField] private float _spawnTimeInterval;
    [SerializeField] private float _fallDownTimeInterval;
    private float timer;

    private void Start()
    {
        GameManager.Instance.RegisterEggSpawner(this);
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > _spawnTimeInterval)
        {
            timer = 0;
            StartCoroutine(DelayedSpawnCor());
        }
    }

    IEnumerator DelayedSpawnCor()
    {
        yield return new WaitForSeconds(_fallDownTimeInterval/2f);
        SpawnEgg();
    }

    private void SpawnEgg()
    {
        int randomRamp = Random.Range(0, _ramps.Length);
        _ramps[randomRamp].SpawnEgg(_fallDownTimeInterval);
    }
    /// <summary>
    /// Changes current spawn interval by multiplying it by given factor
    /// </summary>
    /// <param name="currentIntervalFactor"></param>
    internal void SetSpawnInterval(float changeFactor)
    {
        _spawnTimeInterval *= changeFactor;
    }
    /// <summary>
    /// Changes speed of spawnable by changing its falling progres interval
    /// </summary>
    /// <param name="changeFactor"></param>
    internal void SetSpawnableInterval(float changeFactor)
    {
        _fallDownTimeInterval *= changeFactor;
    }
}
