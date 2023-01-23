using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ConfigurableJoint))]
public class CharacterMovment : MonoBehaviour
{
    Rigidbody rb;
    ConfigurableJoint joint;
    Vector3 playerMovmentInput;
    PhotonView view;

    [SerializeField] float playerSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    [Space]
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform groundCheck;
    [Space]
    [Header("SpringSettings")]
    [SerializeField] float jointSpring = 20f;
    [SerializeField] float jointMaxForce = 40f;
    [SerializeField] float springFuel = 150f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<ConfigurableJoint>();
        //SetJointSettings(jointSpring);
        view = GetComponent<PhotonView>();
    }

    void Update()
    {

        playerMovmentInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Checks if We are local player
        if (view.IsMine)
        {
            MovePlayer();
        }

    }
    void MovePlayer()
    {
        Vector3 _moveVector = transform.TransformDirection(playerMovmentInput) * playerSpeed;
        rb.velocity = new Vector3(_moveVector.x, rb.velocity.y, _moveVector.z);
        if (Input.GetButton("Jump") && springFuel > 0)
        {
            SetJointSettings(0);
            rb.AddForce(Vector3.up * jumpForce * (Time.deltaTime * 100) , ForceMode.Acceleration);
            springFuel -=100 * Time.deltaTime;
            Debug.Log(Time.deltaTime * 100);
        }
        else
        {
            SetJointSettings(jointSpring);
            if (rb.position.y < 2f && springFuel <= 150f)
            {
                springFuel +=40f * Time.deltaTime;
            }
        }
    }
    void SetJointSettings(float _positionSpring)
    {
        joint.yDrive = new JointDrive
        {
            positionSpring = _positionSpring,
            maximumForce = jointMaxForce
        };
    }
}
