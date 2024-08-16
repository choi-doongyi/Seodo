using UnityEngine;
using System.Collections;

public class MoveObjectController : MonoBehaviour 
{
	public float reachRange = 1.8f;			

	private Animator anim;
	private Camera fpsCam;
	private GameObject player;

	private const string animBoolName = "isOpen_Obj_";

	private bool playerEntered;
	private bool showInteractMsg;
	private GUIStyle guiStyle;
	private string msg;

	private int rayLayerMask; 


	void Start()
	{

		anim = GetComponent<Animator>(); 
		anim.enabled = false;  //disable animation states by default.  


	}
		
	void OnTriggerEnter(Collider other)
	{		
		if (other.gameObject == player)		//player has collided with trigger
		{			
			playerEntered = true;

		}
	}

	void OnTriggerExit(Collider other)
	{		
		if (other.gameObject == player)		//player has exited trigger
		{			
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;		
		}
	}



	void Update()
	{		
		if (playerEntered)
		{

			if (Input.GetButtonDown("E"))
			{
				anim.enabled = true;
			}
		}

	}
}
