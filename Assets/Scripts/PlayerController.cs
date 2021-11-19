using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minPressTime;
    [SerializeField] private float maxPressTime;
    [SerializeField] private bool isOnGround;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    private float initDrag;
    private float keyDownTime;

    private GameController gameController;
    private UIController uiController;
    private AudioController soundController;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 1;
        walkSpeed = 2.5f;
        rotateSpeed = 0.35f;
        minPressTime = 0.5f;
        maxPressTime = 3.0f;
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        soundController = GameObject.Find("Sound").GetComponent<AudioController>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        initDrag = playerRb.drag;
        isOnGround = false;
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
                uiController.SetSliderValue((holdTime - minPressTime) / (maxPressTime - minPressTime));
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isOnGround = false;
                float holdTime = Time.time - keyDownTime;
                holdTime = Mathf.Clamp(holdTime, minPressTime, maxPressTime);
                playerRb.drag = 0;
                playerRb.AddRelativeForce(new Vector3(0, 2, 1) * jumpForce * holdTime, ForceMode.Impulse);
                playerAnimator.SetFloat("Jump_speed_f", 1.0f / holdTime);
                playerAnimator.SetBool("Pre_jump_b", false);
                soundController.playJumpSfx();
            }


            float horizontalInput = Input.GetAxis("Horizontal");
            float verticelInput = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed);
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
            uiController.SetSliderValue(0);
        } else if (collision.gameObject.CompareTag("Trap"))
        {
            soundController.playHitTrapSfx();
            gameController.Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndPoint"))
        {
            gameController.CompleteLevel();
        }
        else if (other.gameObject.CompareTag("Star"))
        {
            soundController.playHitStarSfx();
            Static.lives += 1;
            uiController.UpdateUI();
            Destroy(other.gameObject);
        }
    }
}
