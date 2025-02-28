using UnityEngine;

public class Player_Moves : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    private Camera cam;
    public float rotationSpeed;
    private Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 
        float Vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveDirection = new Vector3(Horizontal, 0f, Vertical).normalized;

        if(moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0, 1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void FixedUpdate()
    {

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Impulse);

    }
}
