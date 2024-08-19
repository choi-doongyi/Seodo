using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
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
        scanObject = scanObj;
        ObjData data = scanObj.transform.GetComponent<ObjData>();
        talkText.gameObject.SetActive(true);
        Talk(data.Id, data.NPC);
        
    }

    // Update is called once per frame
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            talkText.gameObject.SetActive(false);
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        talkIndex++;
    }
}
