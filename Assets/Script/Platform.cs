using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Platform : MonoBehaviour
{
    [SerializeField]
    private int Count;

    public int FloorCount
    {
        get
        {
            return Count;
        }
        set
        {
            Count = value;
            float MoveSize = Count * -0.5f;
            for (int i = 0; i < Count; i++)
            {
                GameObject NewObj = new GameObject("Floor");
                NewObj.transform.SetParent(transform);
                NewObj.transform.localPosition = new Vector3(i+ MoveSize, 0, 0);

                SpriteRenderer SR = NewObj.AddComponent<SpriteRenderer>();
                SR.sprite = LogicValue.MainFloorSprite;

                GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
                NewCoin.transform.position = NewObj.transform.position + Vector3.up;

            }
            GameObject Left = new GameObject("Left");
            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-0.65f+ MoveSize, 0, 0);

            SpriteRenderer LeftSR = Left.AddComponent<SpriteRenderer>();
            LeftSR.sprite = LogicValue.LeftFloorSprite;

            GameObject Right = new GameObject("Right");
            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(Count - 1 + 0.64f+ MoveSize, 0, 0);

            SpriteRenderer RightSR = Right.AddComponent<SpriteRenderer>();
            RightSR.sprite = LogicValue.RightFloorSprite;


        }
    }

    private void Awake()
    {
        if (LogicValue.CoinPrefab == null)
        {
            Debug.LogError("NO COIN!");
            Destroy(gameObject);
            return;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Player.PlayerPos.x - transform.position.x >= 10.0f)
        {
            //멀리 떨어진 판자 삭제
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
