using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;

namespace WhiteWolf.Pun{

    public class WW_PUN_CORE : MonoBehaviourPunCallbacks {

        public bool isConnected;
        public bool inRoom;

        [Space]

        public string roomName;
        public byte maxPlayers = 2;
        public string playersInRoom;
        public string[] players;

        [Space]

        public string yourName;

        /*--------------------------------------------------------------------*/

        //private PhotonView photonView;

        /*--------------------------------------------------------------------*/

        void Start(){

            //photonView = GetComponent<PhotonView>();

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }

        void Update(){

            isConnected = PhotonNetwork.IsConnected;
            inRoom = PhotonNetwork.InRoom;

            playersInRoom = $"{PhotonNetwork.PlayerList.Length}/{maxPlayers}";

            players = new string[ PhotonNetwork.PlayerList.Length ];

            for ( int i = 0; i< PhotonNetwork.PlayerList.Length; i++ )
                players[ i ] = PhotonNetwork.PlayerList[ i ].NickName;

        }

        /*--------------------------------------------------------------------*/

        public override void OnConnectedToMaster(){

            print( "Connected to Master!" );

            RoomOptions options = new RoomOptions();
            options.MaxPlayers = maxPlayers;

            roomName = $"{Random.Range( 1000, 9999 )}";

            PhotonNetwork.JoinOrCreateRoom( $"{roomName}", options, TypedLobby.Default );

        }

        /*--------------------------------------------------------------------*/

        public override void OnCreatedRoom() => print( $"Created {roomName}!" );

        public override void OnJoinedRoom(){

            yourName = PhotonNetwork.NickName = $"Player_{ Random.Range( 1000, 9999 ) }";
            print( $"Created: { PhotonNetwork.NickName }" );

            //PhotonNetwork.Instantiate( $"{prefabName}", spawn.transform.position, Quaternion.identity );
            //print( $"Joined {roomName}!" );

        }

    }

}