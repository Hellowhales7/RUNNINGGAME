using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBack : MonoBehaviour
{
    [SerializeField]
    private float DeathLen = 5;
    [SerializeField]
    private float CreateLen = 5;
    [SerializeField]
    private int Order = 5;

    private bool m_IsCreate = false;
    [SerializeField]
    private int Speed = 5;
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        if (SR == null)
        {
            Debug.LogError("Error");
            return;
        }
        SR.sortingOrder = Order;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * Speed;

        if (m_IsCreate == false && CreateLen > transform.position.x)
        {
            GameObject Obj = LogicValue.NameInst(gameObject);

            Obj.transform.position += (Vector3.right * 50.7f);

            m_IsCreate = true;
        }
        if (DeathLen * 2  > (transform.position.x))
        {
            Destroy(gameObject);
        }
    }
}
