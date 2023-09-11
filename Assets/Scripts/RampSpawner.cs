using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private BoardPosition _boardPosition;
    [ContextMenu("Spawn Egg")]
    public void SpawnEgg(float fallingProgresTimeInterval)
    {
        GameObject eggInstance = Instantiate(_eggPrefab,transform);
        Egg egg = eggInstance.GetComponent<Egg>();
        egg.SetOrigin(_boardPosition);
        egg.SetInterval(fallingProgresTimeInterval);
        egg.SetClip(AudioController.NextClip());
        egg.enabled = true;
    }
}
