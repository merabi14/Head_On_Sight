using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        RegisterPlayer();

        if (!view.IsMine)
        {
            DisableComponents();
            AssingRemotLayer();
        }
    }

    void RegisterPlayer()
    {
        string _id = "Player-" + view.ViewID;
        transform.name = _id;
    }
    void DisableComponents()
    {
        foreach (var item in componentsToDisable)
            {
                item.enabled = false;
                Debug.Log(item + "Has been disabled");
            }
    }
    void AssingRemotLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("RemotePlayer");
    }
}
