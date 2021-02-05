using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    public float speed = 5;
    public float jumpStrength = 4;

    Rigidbody rb;
    CapsuleCollider col;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(h, 0, v);

        if (isGrounded() && Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}
 