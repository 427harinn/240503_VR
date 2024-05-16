using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ChangeHP_s : MonoBehaviour
{
    int playerID;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == playerID)
            {
                if (playerID != other.transform.parent.gameObject.GetComponent<PhotonView>().OwnerActorNr)
                {
                    other.transform.parent.gameObject.GetComponent<MyHP_s>().DecHPvalue();
                }
                
            }
        }
    }

    public void SetID(int playerID)
    {
        this.playerID = playerID;
    }
}
