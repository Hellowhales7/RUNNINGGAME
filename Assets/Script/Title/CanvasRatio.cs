using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRatio : MonoBehaviour
{
    [SerializeField]
    private Vector2 BasicSize;
    [SerializeField]
    private Camera Cam;
    // Start is called before the first frame update
    void Awake()
    {
        if (Cam == null)
        {
            Debug.LogError("No camera");
            return;
        }

        CanvasScaler CS = GetComponent<CanvasScaler>();

        if ((BasicSize.x /BasicSize.y) > (Cam.pixelWidth /Cam.pixelHeight))
        {
            CS.matchWidthOrHeight = 0.0f;
        }
        else
        {
            CS.matchWidthOrHeight = 1.0f;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
