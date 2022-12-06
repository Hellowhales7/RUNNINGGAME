using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        LogicValue.ScorePlus(100);
       // Debug.Log("코인입니다");
    }
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        if (Player.IsDeath == true || Player.PlayerPos.x > transform.position.x + 5)
        {
            Destroy(gameObject);
        }
    }
}
