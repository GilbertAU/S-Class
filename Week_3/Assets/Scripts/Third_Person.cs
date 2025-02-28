using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Third_Person : MonoBehaviour
{
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed;
    private Transform player;
    private float currentPosition;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void lateUpdate()
    {
        float HorizontalInput = Input.GetAxis("Mouse X");
        currentPosition += HorizontalInput * rotationSpeed;
        Vector3 desiredposition = player.position - new Vector3(0f, 0f, distance);
        desiredposition.y = player.position.y + height;
        transform.position = desiredposition;
        transform.LookAt(player.position);
        player.rotation = quaternion.Euler(0f, currentPosition, 0f);
    }
}
