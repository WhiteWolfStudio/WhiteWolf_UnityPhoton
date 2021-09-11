using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Photon.Pun;
using Photon.Realtime;

namespace WhiteWolf {

    public class WW_LobbyManager : MonoBehaviourPunCallbacks {

        public string worldName = "@random";
        public string prefabName;
        public byte maxPlayers;
        public GameObject spawn;
  
        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Awake(){ if ( !Directory.Exists( "Assets/Resources" ) ){ Directory.CreateDirectory( "Assets/Resources" ); } }

        void Start(){

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        public override void OnConnectedToMaster(){

            print( "Connected to Master!" );

            RoomOptions options = new RoomOptions();
            options.MaxPlayers = maxPlayers;

            if ( worldName == "@random" ){ worldName = RandomWorld(); }

            PhotonNetwork.JoinOrCreateRoom( $"{worldName}", options, TypedLobby.Default );

        }

        public override void OnCreatedRoom() => print( $"Created {worldName}!" );

        public override void OnJoinedRoom(){

            PhotonNetwork.NickName = $"Player_{ Random.Range(1000, 9999) }";
            print( $"Created: {PhotonNetwork.NickName}" );

            PhotonNetwork.Instantiate( $"{prefabName}", spawn.transform.position, Quaternion.identity );
            print( $"Joined {worldName}!" );

        }

        public string RandomWorld(){ return $"world_{ Random.Range(1000, 9999) }";}

    }

}