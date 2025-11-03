using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Speed")]
    public float speed;
    public float FastSpeed;
    private float CurrnentSpeed;

    [Header("PlayerJump")]
    public float JumpForce;
    public float GravityMode;
    //private int JumpCount;
    //private int JumpAlllow = 1;

    [Header("CharcterCrotller")]
    public CharacterController characterController;

    [Header("PlayerDirection")]
    private float Horizontal;
    private float Vertical;
    private Vector3 movedir;
    private Vector3 movement;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGround;

    [Header("PlayerCamera")]
    public Transform playerviewPoint;
    public float mouseSensitivity;
    private float verticalRotation;
    private Vector2 mouseInput;
    public bool invertLook;
    private Camera maincamera;

    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        maincamera = Camera.main;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed();
        PlayerCamera();
        CursorLock();
        
        
        
    }


    public void PlayerSpeed()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        movedir = new Vector3(Horizontal * CurrnentSpeed, 0f, Vertical * CurrnentSpeed);

        float VerticalVelocity = movement.y;

        movement = ((transform.forward * movedir.z) + (transform.right * movedir.x)).normalized * CurrnentSpeed;
        movement.y = VerticalVelocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrnentSpeed = FastSpeed;
            //Debug.Log(CurrnentSpeed);
        }

        else
        {
            CurrnentSpeed = speed;
            //Debug.Log(speed);
        }

        if (characterController.isGrounded)
        {
            movement.y = 0f;
        }

        isGround = Physics.Raycast(groundCheck.position, Vector3.down, 0.25f, groundLayer);
        /*if (isGround)
        {
            JumpCount = 0;
        }*/

        if (Input.GetButtonDown("Jump") )/*&& JumpCount<JumpAlllow)*/ 
        {
            movement.y = JumpForce;
            AudioManager.instance.PlaySFX(4);
            //JumpCount++;
        }
        movement.y += (Physics.gravity.y * GravityMode * Time.deltaTime);

        characterController.Move(movement*Time.deltaTime);

    }

    public void PlayerCamera()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y+mouseInput.x,transform.rotation.eulerAngles.z);
        verticalRotation += mouseInput.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);
        if (invertLook)
        {
            playerviewPoint.rotation = Quaternion.Euler(verticalRotation, playerviewPoint.eulerAngles.y, playerviewPoint.eulerAngles.z);
        }
        else
        {
            playerviewPoint.rotation = Quaternion.Euler(-verticalRotation, playerviewPoint.eulerAngles.y, playerviewPoint.eulerAngles.z);
        }

    }

    public void CursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        
    }

    private void LateUpdate()
    {
        maincamera.transform.position = playerviewPoint.transform.position;
        maincamera.transform.rotation = playerviewPoint.transform.rotation;
    }



}

