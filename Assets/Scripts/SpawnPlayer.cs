using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Space]
    [Header("Player Random Location")]
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 10;
    [SerializeField] float minZ = 0;
    [SerializeField] float maxZ = 10;
    const float fixedY = 1.5f;
    
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), fixedY, Random.Range(minZ, maxZ));
        
        //spawn playr on random positin
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }
}
