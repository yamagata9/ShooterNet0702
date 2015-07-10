using UnityEngine;
using UnityEngine.Networking;

public class DisableNetworkUnlocalplayerBehavior : NetworkBehaviour {

	//[SerializeField]
	//Behaviour[] behaviours;
	
	public Behaviour cntrlScript;
	//public AudioSource audioS;
	public Camera camera;
	
	void Start () {
		if( ! isLocalPlayer ){
		
			//foreach( var behaviour in behaviours ){
			//	behaviour.enabled = false;
			//}
			
			cntrlScript.enabled = false;
			//audioS.enabled		= false;
			camera.enabled		= false;
			
		}
	}
		
	void OnApplicationFocus( bool focusStatus ) {
		if( isLocalPlayer ){
		
			//foreach( var behaviour in behaviours ){
				//behaviour.enabled = focusStatus;
			//}
			
			cntrlScript.enabled = focusStatus;
			//audioS.enabled		= focusStatus;
			camera.enabled		= true;
			
		}
	}
}














