using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private string horizontalInputName = "Horizontal";
    private string verticalInputName = "Vertical";

    [SerializeField] private float walkSpeed, runSpeed;
    [SerializeField] private float runBuildUpSpeed;
    [SerializeField] private KeyCode runKey;

    private PatrollAgent[] Lpa;

    private float movementSpeed;

    private bool walking;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    [SerializeField] private float crouchHeight;

    private bool isJumping;
    public bool hidden;

    public int Lives = 3;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        walking = false;
    }

    private void Start()
    {
        Lpa = GameObject.FindObjectsOfType<PatrollAgent>();
    }

    private void Update()
    {
        PlayerMovement();

        Crouch();

        GameOver();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        SetMovementSpeed();
        JumpInput();
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
        {
            walking = false;
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        }

        else
        {
            walking = true;
            movementSpeed = Mathf.Clamp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hide")
        {
            hidden = true;
            onHidden?.Invoke(true);
        }

        if (other.gameObject.tag == "PlayerRoom")
        {
            foreach(PatrollAgent PA in Lpa)
            {
                PA.setHype(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hide")
        {
            hidden = false;
            onHidden?.Invoke(false);
        }

        if (other.gameObject.tag == "PlayerRoom")
        {
            foreach (PatrollAgent PA in Lpa)
            {
                PA.setHype(false);
            }
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) || hidden == true)
        {
            charController.height = crouchHeight;
            movementSpeed = 0.5f;
            isJumping = true;
        }

        else
        {
            charController.height = 2;
            isJumping = false;
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

    public event System.Action <bool> onHidden;

    public void teleport(Vector3 teleportPoint)
    {
        charController.enabled = false;
        transform.position = teleportPoint;
        charController.enabled = true;
    }

    public void GameOver()
    {
        if(Lives <= 0)
        {
            SceneManager.LoadScene("YouLose");
        }
    }
}