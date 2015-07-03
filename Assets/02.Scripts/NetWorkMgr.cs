using UnityEngine;
using System.Collections;

public class NetWorkMgr : MonoBehaviour {
	
	// 接続IP
	private const string ip = "127.0.0.1";
	// 接続ポート
	private const int port = 30000;
	// NAT機能の使用の有無
	private bool _useNat = false;
	
	void OnGUI(){
		// 現在のユーザーのネットワーク接続の有無を判断
		if( Network.peerType == NetworkPeerType.Disconnected )
		{
			//　ゲームサーバー生成ボタン
			if( GUI.Button ( new Rect( 20, 20, 200, 25 ), "Start Server" ) )
			{
				//ゲームサーバー生成 : InitializeServer（接続者数、ボート番号、NATの使用の有無）
				Network.InitializeServer( 20, port, _useNat );
			}
			//
			if( GUI.Button ( new Rect ( 20, 50, 200, 25 ), "Connect to Server" ) )
			{
				Network.Connect(ip, port);
			}
		}else{
			//
			if( Network.peerType == NetworkPeerType.Server )
			{
				GUI.Label( new Rect ( 20, 20, 200, 25 ), "Initialization Server" );
			}
			//
			if( Network.peerType == NetworkPeerType.Client )
			{
				GUI.Label( new Rect ( 20, 20, 200, 25 ), "Initialization Server" );
			}
		}
	}
}














