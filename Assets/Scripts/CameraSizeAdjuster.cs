using System.Collections;
using UnityEngine;

public class CameraSizeAdjuster : MonoBehaviour
{
    [SerializeField] private float cameraFactor;
    [SerializeField] private float baseSize;
    [SerializeField] private float baseRatio;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AdjustCameraSize());
    }

    // Update is called once per frame
    private IEnumerator AdjustCameraSize()
    {
        Vector2 screenSize = Screen.safeArea.size;
        float ratio = screenSize.x / screenSize.y;
        Debug.Log("Screen ratio: " + ratio.ToString("0.0"));
        yield return new WaitForEndOfFrame();
        cam.orthographicSize = baseSize * (baseRatio / ratio);
    }
}

