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
        public DictionaryRoom room;
        public string typeRoom;
        [Space]
        public string yourName;

        /*--------------------------------------------------------------------*/

        private string roomName;
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

        }

        /*--------------------------------------------------------------------*/

        public override void OnConnectedToMaster(){

            print( "Connected to Master!" );

            var options = new RoomOptions
            {
                MaxPlayers = room.GetDictionary()[$"{typeRoom}"]
            };
            
            roomName = $"{Random.Range( 1000, 9999 )}";
            PhotonNetwork.JoinOrCreateRoom( $"{roomName}", options, TypedLobby.Default );

            print( PhotonNetwork.CountOfRooms );

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