using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15.0f;
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float minPressTime = 0.5f;
    [SerializeField] private float maxPressTime = 3.0f;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private float waitTime = 1.0f;

    public GameObject centerOfMass;
    public Slider slider;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    private float initDrag;
    private float keyDownTime;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        initDrag = playerRb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                keyDownTime = Time.time;
                playerAnimator.SetBool("Pre_jump_b", true);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                float holdTime = Time.time - keyDownTime;
                holdTime = Mathf.Clamp(holdTime, minPressTime, maxPressTime);
                slider.SetValueWithoutNotify((holdTime - minPressTime) / (maxPressTime - minPressTime));
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isOnGround = false;
                float holdTime = Time.time - keyDownTime;
                holdTime = Mathf.Clamp(holdTime, minPressTime, maxPressTime);
                playerRb.drag = 0;
                playerRb.AddRelativeForce(new Vector3(0, 1, 1) * jumpForce * holdTime, ForceMode.Impulse);
                playerAnimator.SetFloat("Jump_speed_f", 1.0f / holdTime);
                playerAnimator.SetBool("Pre_jump_b", false);
            }


            float horizontalInput = Input.GetAxis("Horizontal");
            float verticelInput = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up, horizontalInput);
            playerRb.AddRelativeForce(Vector3.forward * walkSpeed * verticelInput);
            playerAnimator.SetFloat("Speed_f", Mathf.Abs(verticelInput) + Mathf.Abs(horizontalInput));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerRb.drag = initDrag;
        }
    }
}