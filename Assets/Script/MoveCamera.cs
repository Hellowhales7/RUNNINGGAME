using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    static Vector3 StartPos = Vector3.zero;
    private static MoveCamera GameCamera = null;
    public static Camera Camcom;
    // Update is called once per frame
    public static void CameraReset()
    {

        GameCamera.transform.position = StartPos;

    }
    private void Awake()
    {
        Camcom = GetComponent<Camera>();
        StartPos = transform.position;
        GameCamera = this;
    }
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime* LogicValue.MoveSpeed;


    }
}
