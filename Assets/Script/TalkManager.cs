using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }


    void GenerateData()
    {
        talkData.Add(0,new string[] {"안녕?", "이 곳에 처음 왔구나?","~~좀 가져와줄래??"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length) return null;
        
        else return talkData[id][talkIndex];
    }
}
