using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;

namespace WhiteWolf.Pun {

    public class WW_PhotonPlayer : MonoBehaviour {

        public bool showName;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        private PhotonView _photonView;

        private bool _player;

        /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

        private void Start(){

            _photonView = GetComponent<PhotonView>();

            if ( _photonView.IsMine ) { _player = true; }
            if ( showName && _player ){ this.gameObject.name = _photonView.Owner.NickName; }

        }

        private void Update() => this.gameObject.name = PhotonNetwork.NickName;

    }

}