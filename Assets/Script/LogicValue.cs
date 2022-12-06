using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraAndPlayerData
{
    [SerializeField]
    public float m_JumpPower = 10.0f;
    [SerializeField]
    public float m_MoveSpeed = 10.0f;
    [SerializeField]
    public int m_JumpCount = 3;
}
public class LogicValue : MonoBehaviour
{
    private static LogicValue Inst;
    // Start is called before the first frame update
    [SerializeField]
    CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();
    [SerializeField]
    private GameObject m_CoinPrefab;
    public static GameObject CoinPrefab
    {
        get
        {
            return Inst.m_CoinPrefab;
        }
    }

    [SerializeField]
    private GameObject m_BSPrefab1;
    public static GameObject BSPrefab1
    {
        get
        {
            return Inst.m_BSPrefab1;
        }
    }
    [SerializeField]
    private GameObject m_BSPrefab2;
    public static GameObject BSPrefab2
    {
        get
        {
            return Inst.m_BSPrefab2;
        }
    }
    [SerializeField]
    private GameObject m_BSPrefab3;
    public static GameObject BSPrefab3
    {
        get
        {
            return Inst.m_BSPrefab3;
        }
    }
    [SerializeField]
    private GameObject m_BMPrefab;
    public static GameObject BMPrefab
    {
        get
        {
            return Inst.m_BMPrefab;
        }
    }


    [SerializeField]
    private Sprite m_MainFloor;
    public static Sprite MainFloorSprite
    {
        get
        {
            return Inst.m_MainFloor;
        }
    }
    [SerializeField]
    private Sprite m_LeftFloor;
    public static Sprite LeftFloorSprite
    {
        get
        {
            return Inst.m_LeftFloor;
        }
    }
    [SerializeField]
    private Sprite m_RightFloor;
    public static Sprite RightFloorSprite
    {
        get
        {
            return Inst.m_RightFloor;
        }
    }
    [SerializeField]
    private static int m_Score;
    public static int Score { get { return m_Score; } }

    public static void ScoreReset()
    {
        m_Score = 0;
    }
    public static void ScorePlus(int _Score)
    {
        m_Score += _Score;
    }
    public static bool ScoreCheck()
    {
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_Score > ScoreArr[i].Score)
            {
                Debug.Log("New Record!");
                return true;
            }
        }
        return false;
    }

    public class ScoreData
    {
        public string Name;
        public int Score;

        public ScoreData()
        {
            Name = "Empty";
            Score = 0;
        }
        public ScoreData(string _Name, int _Score)
        {
            Name = _Name;
            Score = _Score;
        }
    }


    [SerializeField]
    private static List<ScoreData> m_ScoreArr;
    public static List<ScoreData> ScoreArr { get { return m_ScoreArr; } }

    public static void ScoreLoad()
    { 
        m_ScoreArr = new List<ScoreData>();
        if (PlayerPrefs.HasKey("Name0") ==true)
        {
            //기존 데이터 존재

            for (int i = 0; i < 5; i++)
            {
                m_ScoreArr.Add(new ScoreData(PlayerPrefs.GetString("Name" + i), PlayerPrefs.GetInt("Score" + i, 0)));
            }
            return;
        }
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString("Name" + i, "Empty");
            PlayerPrefs.SetInt("Score" + i, 0);
            m_ScoreArr.Add(new ScoreData());
        }
    }
    public static void ScoreInput(string _Name)
    {
        ScoreData NewData = new ScoreData(_Name, m_Score);
        if (_Name =="")
        {
            NewData.Name = "Anonymous";
        }
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (NewData.Score > ScoreArr[i].Score)
            {
                ScoreData TempData = ScoreArr[i];
                ScoreArr[i] = NewData;
                NewData = TempData;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString("Name" + i, m_ScoreArr[i].Name);
            PlayerPrefs.SetInt("Score" + i, m_ScoreArr[i].Score);
            m_ScoreArr.Add(new ScoreData());
        }
    }
    public static float MoveSpeed
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_MoveSpeed;
        }
    }
    public static float JumpPower
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpPower;
        }
    }
    public static int JumpCount
    {
        get
        {
            return Inst.m_CameraAndPlayerData.m_JumpCount;
        }
    }
    private void Awake()
    {
        //이 코드는 제일 빨리 실행되어야함
        Inst = this;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    static public GameObject NameInst(GameObject _NewObject)
    {
        GameObject NewObj = Instantiate(_NewObject);
        NewObj.name = _NewObject.name;
        return NewObj;
    }
}
