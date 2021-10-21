using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public GameObject head;
    public float mouseSensitivity;
    public float speed;
    private float originSpeed;
    private Rigidbody rb;
    float mouseX = 0;
    float mouseY = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        originSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * speed;
        float zAxis = Input.GetAxis("Vertical") * speed;
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        mouseY = Mathf.Clamp(mouseY, -90, 90);
        Vector3 movePos = transform.right * xAxis + transform.forward * zAxis;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);
        rb.velocity = newMovePos;
        head.transform.localEulerAngles = new Vector3(mouseY, 0, 0);
        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = originSpeed;
        }
    }
}
