using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerShooting : NetworkBehaviour {
	
	private float damage = 25;  //ダメージ量
	private float range  = 200; //Raycastの距離
	
	//FirstPersonCharacterを指定
	[SerializeField]
	private Transform camTransform;
	private RaycastHit hit;
	
	void Update(){
		CheckIfShooting();
	}
	
	void CheckIfShooting()
	{
		if(!isLocalPlayer)
		{
			return ;
		}
		
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			Shooting();
		}
	}
	
	void Shooting()
	{
		//カメラの前方にをRaycast飛ばす
		//TransformPoint：指定した分だけ座標をずらす
		if( Physics.Raycast( camTransform.TransformPoint(0, 0, 0), camTransform.forward, out hit, range ) )
		{
			Debug.Log(hit.transform.tag);
			
			//RaycastがPlayerと衝突したとき
			if(hit.transform.tag == "Player")
			{
				//名前を取得
				string uIdentity = hit.transform.name;
				//名前とダメージ量を引数にメソッド実行
				CmdTellServerWhoWasShot(uIdentity, damage);
			}
		}
		
		Debug.Log("Shooting");
	}
	
	//Command: SyncVar変数の健康結果を全クライアントへ送信
	[Command]
	void CmdTellServerWhoWasShot(string uniqueID, float dmg)
	{
		//敵プレイヤーの名前でGameObjectを取得
		GameObject go = GameObject.Find(uniqueID);
		//Apply damage to that player
		
		Debug.Log("あたった");
	}
}
