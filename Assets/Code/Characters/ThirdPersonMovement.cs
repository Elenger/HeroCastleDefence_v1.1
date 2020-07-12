using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Transform _holder_ThirdPersonCameraTransform;
    [SerializeField] private PhotonView _photonView;
    public CinemachineFreeLook cinemachineFreeLook;
    public Transform mainCameraTransform;
    public bool stopMovement = false;

    private const float speed = 6f;
    private const float turnSmoothTime = 0.0f;
    private float turnSmoothVelocity;

    private void SetStopMovement(int eventValue)
    {
        stopMovement = eventValue == 1 ? true : false;
    }
    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void Start()
    {
        cinemachineFreeLook.LookAt = _holder_ThirdPersonCameraTransform;
        cinemachineFreeLook.Follow = _holder_ThirdPersonCameraTransform;
    }

    private void Update()
    {
        if (stopMovement) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 movementDirection = Quaternion.Euler(0f, direction.y, 0f)*Vector3.forward;
            _capsuleCollider.transform.Translate(movementDirection.normalized * speed * Time.deltaTime);          
        }
    }
}
