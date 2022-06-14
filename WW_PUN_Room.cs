using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;

namespace WhiteWolf.Pun {

    public class WW_PUN_Room : MonoBehaviourPunCallbacks {

        public string roomName;
        public int maxPlayers;
        [Space]
        public string playersInRoom = null;
        public string[] players = null;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        private void Start(){

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }

        private void Update(){

            if ( PhotonNetwork.InRoom ){

                players = new string[ maxPlayers ];

                for ( var i = 0; i < PhotonNetwork.PlayerList.Length; i++ )
                    players[ i ] = PhotonNetwork.PlayerList[ i ].NickName;

            }

        }

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        public override void OnJoinedRoom(){

            maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
            players = new string[ maxPlayers ];

            roomName = PhotonNetwork.CurrentRoom.Name;
            playersInRoom = $"{ PhotonNetwork.CurrentRoom.PlayerCount }/{ maxPlayers }";

            //PhotonNetwork.Instantiate( $"{prefabName}", spawn.transform.position, Quaternion.identity );
            //print( $"Joined {roomName}!" );

        }

    }

}