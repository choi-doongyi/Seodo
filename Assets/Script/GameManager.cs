using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text talkText;
    public GameObject scanObject;
    public TalkManager talkManager;

    public int talkIndex;


    public void Action(GameObject scanObj)
    {

    }

    // Update is called once per frame
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
    }
}
