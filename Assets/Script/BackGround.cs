using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private float Inter;
    [SerializeField]
    int Sort = 0;
    private float DivInter;
    private float CheckInter;

    bool m_IsNext = false;
    // Start is called before the first frame update
    private void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = Sort;
    }

    // Update is called once per frame
    void Update()
    {
        //만드는 로직
        if (m_IsNext==false && Player.PlayerPos.x > transform.position.x)
        {
            GameObject NextBG =  Instantiate<GameObject>(gameObject);
            NextBG.name = gameObject.name;

            Vector3 Pos = transform.position;
            Pos.x += Inter;
            NextBG.transform.position = Pos;
            m_IsNext = true;
        }
        if (  Inter *2  <= Player.PlayerPos.x - transform.position.x)
        {
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        if (Player.IsDeath == true)
        {
            Destroy(gameObject);
        }
    }
}
