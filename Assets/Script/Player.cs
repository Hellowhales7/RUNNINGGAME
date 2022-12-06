using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody m_Rigi = null;
    private Animator m_Ani = null;
    private bool m_IsJump = false;
    private int m_Jumpcount;
    private static bool m_IsDeath = false;
    public static bool IsDeath
    {
        get
        {
            return m_IsDeath;
        }
    }
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos
    {
        get
        {
            return m_PlayerPos;
        }
    }
    private void Awake()
    {
        LogicValue.ScoreReset();
        m_Rigi = GetComponent<Rigidbody>();
        m_Jumpcount = LogicValue.JumpCount;
        m_Ani = GetComponent<Animator>();
        if (m_Rigi ==null)
        {
            Debug.LogWarning("None Rigidbody");
        }
    }
    private void FixedUpdate()
    {
        if (m_IsDeath==true)
        {
            PlatManager.PlatReset();

            LogicValue.NameInst(LogicValue.BSPrefab1);
            LogicValue.NameInst(LogicValue.BSPrefab2);
            LogicValue.NameInst(LogicValue.BSPrefab3);
            LogicValue.NameInst(LogicValue.BMPrefab);

            m_IsDeath = false;
        }
     
    }
    void Update()
    {
        // 플레이어 사망
        if (transform.position.y <= -MoveCamera.Camcom.orthographicSize)
        {

            //플레이어를 맨처음으로
            SceneManager.LoadScene(2);
         //   transform.position = Vector3.zero;
         //   MoveCamera.CameraReset();
            

         //   m_IsDeath = true;
        }
        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;

        m_PlayerPos = transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && m_Jumpcount != 0)
        {
            m_Ani.SetTrigger("JUMP");
            m_Rigi.velocity = Vector3.zero;
            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            //m_IsJump = true;
            m_Jumpcount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_Ani.SetTrigger("RUN");
        //m_IsJump = false;
        m_Jumpcount = LogicValue.JumpCount;
    }
}
