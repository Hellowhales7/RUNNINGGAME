using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatManager : MonoBehaviour
{
    [SerializeField]
    Sprite PlatSprite = null;

    [SerializeField]
    private float CreateRandomRangeYStart = -2.0f;
    [SerializeField]
    private float CreateRandomRangeYEnd = 2.0f;

    [SerializeField]
    private int CreateRandomScaleXStart = 5;
    [SerializeField]
    private int CreateRandomScaleXEnd = 10;

    [SerializeField]
    private float CreateRandomInterXStart = 2.0f;
    [SerializeField]
    private float CreateRandomInterXEnd = 4.0f;

    [SerializeField]
    private float CreateRange = 20.0f;

    //마지막 판자의 x위치
    [SerializeField]
    private float LastCreatePosX = 0;
    //마지막 판자의 x크기
    [SerializeField]
    private float LastCreateScaleX = 0;

    private float ResetLastCreatePosX = 0;
    private float ResetLastCreateScaleX = 0;


    public static PlatManager MainPlatMgr;
    private void Awake()
    {
        ResetLastCreatePosX = LastCreatePosX;
        ResetLastCreateScaleX = LastCreateScaleX;
        MainPlatMgr = this;
        CheckPlatCreate();
    }
    public static void PlatReset()
    {
        MainPlatMgr.ResetData();
    }
    public void ResetData()
    {
        LastCreatePosX = ResetLastCreatePosX;
        LastCreateScaleX = ResetLastCreateScaleX;
        CheckPlatCreate();
    }
    bool NewPlatLogic()
    {

        if (LastCreatePosX >= Player.PlayerPos.x + CreateRange)
        {
            return false;
        }
        int NewFloorCount = Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd);
        GameObject NewPlat = new GameObject("Plat");
        //NewPlat.transform.localScale = new Vector3(Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1.0f, 1.0f);
        
        Vector3 CreatPos = new Vector3();

        CreatPos.x = LastCreatePosX+LastCreateScaleX + (NewFloorCount * 0.5F);
        CreatPos.x += Random.Range(CreateRandomInterXStart, CreateRandomInterXEnd);
        CreatPos.z = 0.0f;
        CreatPos.y = Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        NewPlat.transform.position = CreatPos;

        // SpriteRenderer NewSP = NewPlat.AddComponent<SpriteRenderer>();
        // NewSP.sprite = PlatSprite;
        // NewSP.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        Platform PS = NewPlat.AddComponent<Platform>();
        PS.FloorCount = NewFloorCount;

        LastCreatePosX = CreatPos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5F);

        BoxCollider NewBC = NewPlat.AddComponent<BoxCollider>();
        NewBC.size = new Vector3(NewFloorCount, 1, 1);
        NewBC.center = new Vector3(-0.5f, 0.18f, 0);



        return true;
    }
    // Update is called once per frame

    void CheckPlatCreate()
    {
        while (NewPlatLogic()) ;
    }
    void Update()
    {
        NewPlatLogic();
    }
}
