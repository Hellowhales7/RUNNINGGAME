using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //Scene in build�� ����س�����
        SceneManager.LoadScene("PlayScene");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("�巡��.");
    }

    public void SceneChange()
    {
        
    }
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
