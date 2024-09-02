using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickEvent : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController cc;
    GameManager gm;
    TalkManager tm;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        tm = GameObject.Find("TalkManager").GetComponent<TalkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit(); 

            if(Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.collider.name);
                if (hitInfo.transform.CompareTag("Door"))
                {
                    cc.enabled = false;
                    transform.position = new Vector3(55, 3, 187);
                    cc.enabled = true;

                    
                    //Destroy(hitInfo.transform.gameObject);
                }

                else if (hitInfo.transform.CompareTag("Dialog"))
                {

                    gm.Action(hitInfo.transform.gameObject);
                    
                }
                else if (hitInfo.transform.CompareTag("Item"))
                {

                    gm.QuestAction(hitInfo.transform.gameObject);

                }
                else if (hitInfo.transform.CompareTag("DoorMove"))
                {
                    Vector3 vel = Vector3.zero;
                    hitInfo.transform.position = Vector3.MoveTowards(hitInfo.transform.position, hitInfo.transform.position+new Vector3(-1,0,0), 1f);
                }
                else if (hitInfo.transform.CompareTag("DontMoveDoor"))
                {
                    Vector3 vel = Vector3.zero;
                    hitInfo.transform.position = Vector3.MoveTowards(hitInfo.transform.position, hitInfo.transform.position + new Vector3(-1, 0, 0), 1f);
                }


            }
        }
    }
}
