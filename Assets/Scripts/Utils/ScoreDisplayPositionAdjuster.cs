using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayPositionAdjuster : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        transform.position = Camera.main.WorldToScreenPoint(targetTransform.position);
    }
}
