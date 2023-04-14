using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 15f;
    [SerializeField] private float spinSpeed = 55f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float spacefromGround = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private float upInput;
    private float sideInput;
    private CapsuleCollider collider;
    private Rigidbody rigid;
    

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        
    }

    private void Update()
    {
        upInput = Input.GetAxis("Vertical") * rollSpeed;
        sideInput = Input.GetAxis("Horizontal") * spinSpeed;

        Movement();
    }

    private void Movement()
    {
        if (IsGrounded() & Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        Vector3 rotation = Vector3.up * sideInput;
        Quaternion angleR = Quaternion.Euler(rotation * Time.deltaTime);

        rigid.MovePosition(this.transform.position + this.transform.forward * upInput * Time.deltaTime);
        rigid.MoveRotation(rigid.rotation * angleR);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z);
        bool grounded = Physics.CheckCapsule(collider.bounds.center, capsuleBottom, spacefromGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

  
}