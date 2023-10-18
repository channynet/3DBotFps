using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed;
    public float jumpForce;

    public float height;
    public float eyeHeight;

    public bool isGrounded;

    private float MouseX;
    private float MouseY;
    public float SensitiveX;
    public float SensitiveY;
    private float RotationX;
    private float RotationY;
    public float MaxRotationX;
    public float MinRotationX;
    public float MaxRotationY;
    public float MinRotationY;
    public Camera camera;

    public Transform WeaponPosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        camera.transform.position = transform.position+ new Vector3 ( 0, eyeHeight, 0);
        camReset();
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;
        //Debug.Log(new Vector3(dir.x * transform.forward.x * speed * Time.deltaTime, 0, dir.z * transform.forward.z * speed * Time.deltaTime));
        transform.position += transform.forward * speed * Time.deltaTime * dir.z + transform.right * speed * Time.deltaTime * dir.x;

        Jump();
    }

    private void Jump()
    {

        if(isGrounded && Input.GetKey(KeyCode.Space)){
            rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void MouseLook()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        RotationX += MouseX * SensitiveX;
        RotationY += -MouseY * SensitiveY;

        //RotationX = Mathf.Clamp(RotationX, MinRotationX, MaxRotationX);
        RotationY = Mathf.Clamp(RotationY, MinRotationY, MaxRotationY);

        transform.rotation = Quaternion.Euler(0, RotationX, 0);
        camera.transform.rotation = Quaternion.Euler(RotationY, RotationX,0);

    }


    public void camShake(Vector3 CamShake)
    {
        camera.transform.eulerAngles += new Vector3 (Random.Range(-CamShake.x,CamShake.x), Random.Range(-CamShake.y, CamShake.y), Random.Range(-CamShake.z, CamShake.z));
    }
    void camReset()
    {
        //camera.transform.eulerAngles = Vector3.zero;
    }
}
