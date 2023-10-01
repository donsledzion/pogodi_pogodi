using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Transform pauseMenu;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button unpauseButton;
    [SerializeField] private ButtonsController buttonsController;
    private bool gamePaused = false;

    public void PauseGame()
    {
        //disable buttons interactions
        //hide collectibles from player
        //hide player ?
        //stop time
        //show pause menu
        Debug.Log("Pause button clicked");
        gamePaused = true;
        buttonsController.SetButtonsActive(!gamePaused);
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(true);
    }

    [ContextMenu("Unpause Game")]
    public void UnpauseGame()
    {
        Debug.Log("Unpause button clicked");
        gamePaused = false;
        buttonsController.SetButtonsActive(!gamePaused);
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
