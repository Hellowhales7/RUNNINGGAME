using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text TextCom = null;
    // Start is called before the first frame update
    void Awake()
    {
        
        TextCom = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TextCom == null)
        {
            Debug.LogError("No TextCom");
            return;
        }
        TextCom.text = LogicValue.Score.ToString();
    }
}
