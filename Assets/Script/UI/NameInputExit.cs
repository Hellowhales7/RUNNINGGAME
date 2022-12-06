using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NameInputExit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject NameInputWindow = null;
    [SerializeField]
    Text NewUserName = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        LogicValue.ScoreInput(NewUserName.text);
        NameInputWindow.SetActive(false);
    }
}
