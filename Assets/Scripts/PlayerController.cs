using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject visPlayerLeft;
    [SerializeField] private GameObject visPlayerRight;
    [SerializeField] private GameObject visBasketLeftBottom;
    [SerializeField] private GameObject visBasketLeftTop;
    [SerializeField] private GameObject visBasketRightBottom;
    [SerializeField] private GameObject visBasketRightTop;
    private BoardPosition _playerPosition;

    public BoardPosition PlayerPosition => _playerPosition;

    private void Awake()
    {
    }

    private void Start()
    {
        SwitchOffAll();
        GoLeftBottom();
        GameManager.Instance.RegisterPlayer(this);
        GoLeftBottom();
    }

    private void SwitchOffPlayer()
    {
        visPlayerLeft.SetActive(false);
        visPlayerRight.SetActive(false);
    }

    private void SwitchOffBaskets()
    {
        visBasketLeftBottom.SetActive(false);
        visBasketLeftTop.SetActive(false);
        visBasketRightBottom.SetActive(false);
        visBasketRightTop.SetActive(false);
    }

    private void SwitchOffAll()
    {
        SwitchOffPlayer();
        SwitchOffBaskets();
    }

    public void GoLeftBottom()
    {
        _playerPosition = BoardPosition.BottomLeft;
        SwitchOffAll();
        visPlayerLeft.SetActive(true);
        visBasketLeftBottom.SetActive(true);
    }

    public void GoLeftTop()
    {
        _playerPosition = BoardPosition.TopLeft;
        SwitchOffAll();
        visPlayerLeft.SetActive(true);
        visBasketLeftTop.SetActive(true);
    }

    public void GoRightBottom()
    {
        _playerPosition = BoardPosition.BottomRight;
        SwitchOffAll();
        visPlayerRight.SetActive(true);
        visBasketRightBottom.SetActive(true);
    }

    public void GoRightTop()
    {
        _playerPosition = BoardPosition.TopRight;
        SwitchOffAll();
        visPlayerRight.SetActive(true);
        visBasketRightTop.SetActive(true);
    }
}

public enum BoardPosition
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
}