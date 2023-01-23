using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreatAndJoin : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI creatField;
    [SerializeField] TextMeshProUGUI joinField;

    public void CreatRoom()
    {
        if (creatField.text != null)
        {
            PhotonNetwork.CreateRoom(creatField.text); 
        }
    }

    public void JoinRoom()
    {
        if (joinField.text != null)
        {
            PhotonNetwork.JoinRoom(joinField.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainScene");
    }
}
