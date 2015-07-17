using UnityEngine;
using UnityEngine.Networking;

public class DisableNetworkUnlocalplayerBehavior : NetworkBehaviour {

	public Behaviour cntrlScript;
	//public AudioSource audioS;
	public Camera camera;
	public AudioListener audioL;
	
	void Start () {
		if( ! isLocalPlayer ){
		
			cntrlScript.enabled = false;
			//audioS.enabled		= false;
			camera.enabled		= false;
			audioL.enabled		= false;	
		}
	}
		
	void OnApplicationFocus( bool focusStatus ) {
		if( isLocalPlayer ){
			
			cntrlScript.enabled = focusStatus;
			//audioS.enabled		= focusStatus;
			camera.enabled		= true;
			audioL.enabled		= focusStatus;
			
		}
	}
}
