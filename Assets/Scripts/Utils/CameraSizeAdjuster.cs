using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeAdjuster : MonoBehaviour
{
    [SerializeField] private float cameraFactor;
    [SerializeField] private float baseSize;
    [SerializeField] private float baseRatio;
    [SerializeField] private Camera cam;
    [SerializeField] private List<TransformScaler> scalers = new();
    private bool camRescaled = false;

    void Start()
    {
        //StartCoroutine(AdjustCameraSize());
    }

    private void Update()
    {
        AdjustCameraSizeUpdate();
        if (camRescaled)
        {
            foreach (TransformScaler scaler in scalers)
            {
                scaler.Scale(cam.orthographicSize);
            }
        }
    }

    private IEnumerator AdjustCameraSize()
    {
        Vector2 screenSize = Screen.safeArea.size;
        float ratio = screenSize.x / screenSize.y;
        Debug.Log("Screen ratio: " + ratio.ToString("0.0"));
        yield return new WaitForEndOfFrame();
        cam.orthographicSize = baseSize * (baseRatio / ratio);
        camRescaled = true;
    }

    private void AdjustCameraSizeUpdate()
    {
        Vector2 screenSize = Screen.safeArea.size;
        float ratio = screenSize.x / screenSize.y;
        /*Debug.Log("Screen ratio: " + ratio.ToString("0.0"));
        yield return new WaitForEndOfFrame();*/
        cam.orthographicSize = baseSize * (baseRatio / ratio);
        camRescaled = true;
    }
}

