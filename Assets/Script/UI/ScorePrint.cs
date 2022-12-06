using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    Text[] ArrText = null;

    [SerializeField]
    GameObject NameInputObj = null;

    // Start is called before the first frame update
    void Awake()
    {
        LogicValue.ScoreLoad();

        if (NameInputObj ==null)
        {
            Debug.LogError("None");
            return;
        }
        if (LogicValue.ScoreCheck() ==true)
        {
            NameInputObj.SetActive(true);
        }
        



    
    }

    // Update is called once per frame
    void Update()
    {
        ArrText = GetComponentsInChildren<Text>();

        for (int i = 0; i < ArrText.Length; i++)
        {
            if (ArrText[i].name == "")
            {
                ArrText[i].name = "Empty";
            }
            ArrText[i].text = (i + 1).ToString() + ". " + LogicValue.ScoreArr[i].Name + " " + LogicValue.ScoreArr[i].Score;
        }
    }
}
