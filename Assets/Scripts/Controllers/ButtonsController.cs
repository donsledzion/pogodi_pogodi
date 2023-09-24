using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    Button _bottomLeftBtn, _bottomRightBtn, _topLeftBtn, _topRightBtn;



    public void SetButtonsActive(bool active)
    {
        _bottomLeftBtn.interactable = active;
        _bottomRightBtn.interactable = active;
        _topLeftBtn.interactable = active;
        _topRightBtn.interactable = active;
    }
}
