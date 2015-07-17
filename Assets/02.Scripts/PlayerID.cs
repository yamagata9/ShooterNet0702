using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerID : NetworkBehaviour {

	//SyncVar: [Command]で変更後に全クライアントへ変更結果を送信
	[SyncVar]
	private string playerUniqueIdentity;
	private NetworkInstanceId playerNetID;
	private Transform myTransform;
	
	//NetworkManagerによってPlayerが生成されたときに実行される
	public override void OnStartLocalPlayer()
	{
		GetNetIdentity();
		SetIdentity();
	}
	
	void Awake()
	{
		//自分の名前を取得するときに使う
		myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//例外が発生したときにSetIdentityメソッド実行
		if( myTransform.name == "" || myTransform.name == "Player(Clone)" ){
			SetIdentity();
		}
	}
	
	[Client]
	void GetNetIdentity()
	{
		//NetworkIdentityのNetID取得
		playerNetID = GetComponent<NetworkIdentity>().netId;
		//名前を付けるメソッド実行
		CmdTellServerMyIdentity(MakeUniqueIdentity());
	}
	
	void SetIdentity()
	{
		//自分以外のPlayerオブジェクトの場合
		if(!isLocalPlayer){
			//今ついている名前のまま
			myTransform.name = playerUniqueIdentity;
		}else{
			//自分自身の場合MakeUniqueIdentityメソッドで名前を取得
			myTransform.name = MakeUniqueIdentity();
		}
	}
	
	string MakeUniqueIdentity()
	{
		//Player + NetIDで名前を付ける
		string uniqueName = "Player" + playerNetID.ToString();
		return uniqueName;
	}
	
	//Command: SyncVar変数を変更し変更結果をクライアントへ送る
	[Command]
	void CmdTellServerMyIdentity( string name )
	{
		playerUniqueIdentity = name;
	}
}
