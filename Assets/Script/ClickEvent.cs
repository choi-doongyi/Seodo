using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController cc;
    GameManager gm;
    void Start()
    {
        cc = GetComponent<CharacterController>();
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

                else if (hitInfo.transform.CompareTag("Item"))
                {
                    Destroy(hitInfo.transform.gameObject);
                    ObjData data = hitInfo.transform.GetComponent<ObjData>();
                    
                }


            }
        }
    }
}
