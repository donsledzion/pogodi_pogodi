using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScaler : MonoBehaviour
{
    [SerializeField] protected float scaleFactor;

    public virtual void Scale(float camSize)
    {
        float newScale = 1f/camSize * scaleFactor;
        Debug.Log("<color=yellow>Scale factor: " + scaleFactor + "</color> | <color=green>camSize: " + camSize + "</color> |<color=white> newScale: " + newScale + "</color>");
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }
}
