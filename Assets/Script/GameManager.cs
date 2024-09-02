using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text talkText;
    public TMP_Text questText;
    public GameObject scanObject;
    public TalkManager talkManager;

    public int talkIndex;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //나중에 옮기기,.. 마우스 커서 가운데 고정
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData data = scanObj.transform.GetComponent<ObjData>();
        talkText.gameObject.SetActive(true);
        Talk(data.Id, data.NPC);
        
    }

    public void Warning(int select)
    {
        if (select == 0)
        {
            talkText.text = "열리지 않는다.";
        }

    }

    public void QuestAction(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData data = scanObj.transform.GetComponent<ObjData>();
        questText.gameObject.SetActive(true);
        questText.text = "아이템을 획득하셨습니다.";

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
