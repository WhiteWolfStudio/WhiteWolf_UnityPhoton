using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;

namespace WhiteWolf {

    public class WW_PhotonPlayer : MonoBehaviour {

        public bool showName;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        PhotonView photonView;

        bool player;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        void Start(){

            photonView = GetComponent<PhotonView>();

            if ( photonView.IsMine ) { player = true; }
            if ( showName && player ){ this.gameObject.name = photonView.Owner.NickName; }

        }

        void Update() => this.gameObject.name = PhotonNetwork.NickName;

    }

}