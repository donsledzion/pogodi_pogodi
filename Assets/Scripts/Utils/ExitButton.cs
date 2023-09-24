using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private int click = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click++;
            StartCoroutine(ClickTime());

            if (click > 1)
            {
                Application.Quit();
            }
        }
    }
    IEnumerator ClickTime()
    {
        yield return new WaitForSeconds(0.5f);
        click = 0;
    }
}
