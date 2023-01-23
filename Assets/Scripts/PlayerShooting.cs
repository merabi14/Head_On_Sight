using UnityEngine;
using Photon.Pun;

public class PlayerShooting : MonoBehaviour
{
    public PlayerWeapon weapon;
    public const string Player_Tag = "Player";
    PhotonView view;

    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }   
    }
    void Shoot()
    {
        RaycastHit _hit;
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.Range, mask))
        {
            if(_hit.collider.tag == Player_Tag) 
            {
                view.RPC("RPC_Shoot", RpcTarget.All, _hit.collider.name);
            }
        }
    }
    [PunRPC]
    void RPC_Shoot(string _playerID)
    {
        Debug.Log(_playerID + "has been shot");
    }
}
