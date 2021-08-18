using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : SpawnEnemies
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public double HP = 100;
    public static double curHP;
    private bool canAttack = true;
    private float attackTime;
    public float EnemyAttackSpeed;
    public float EnemyAttackDamage;
    public GameObject damageTaking;
    private int curGem = 0;

    public FixedJoystick NavJoystick;
    public FixedButton Jump;
    public FixedInputField TouchPanel;
    Text HPText;
    Text GemText;
    Text Pointer;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        GemText = GameObject.Find("GemText").GetComponent<Text>();
        HPText = GameObject.Find("HPText").GetComponent<Text>();
        Pointer = GameObject.Find("PointerText").GetComponent<Text>();
        curHP = HP;
        HPText.text = "HP:  " + curHP + '/' + HP;
        GemText.text = "Gems: " + curGem + '/' + "18";
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        damageTaking.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ZombieEnemy" && canAttack)
        {
            curHP = curHP - EnemyAttackDamage;
            Handheld.Vibrate();
            curHP = Math.Round(curHP, 1);
            canAttack = false;
            attackTime = 0f;
            damageTaking.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {
            curGem++;
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.tag == "Heal")
        {
            other.gameObject.SetActive(false);
            curHP = 100;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (curHP <= 0f)
        {
            SceneManager.LoadScene("LosingScene");
        }
        attackTime += Time.deltaTime;
        
        if (attackTime > EnemyAttackSpeed)
        {
            damageTaking.SetActive(false);
            canAttack = true;
            attackTime = attackTime - EnemyAttackSpeed;
        }
        HPText.text = "HP:  " + curHP + '/' + HP;
        GemText.text = "Gems: " + curGem + '/' + "18";
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        if(curGem == 18 && curEnemy == 0)
        {
            
            //SceneManager.UnloadScene("GameScene");
            Pointer.text = "Congrats! And Next Level is About to Start in 3 Sec...";
            NextLevelTime += Time.deltaTime;
            if(NextLevelTime >= 3f)
            {
                Pointer.text = "";
                numZombPerSpawn++;
                curGem = 0;
                curEnemy = numZombPerSpawn * 9;
            }
            
        }

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        //Mobile
        /*
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * NavJoystick.Vertical : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) *  NavJoystick.Horizontal: 0;
        */
        //PC
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if ((Jump.Pressed || Input.GetKey(KeyCode.Space) ) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            //Mobile
            /*
            rotationX += -TouchPanel.TouchDist.y * lookSpeed; //Input.GetAxis("Mouse X")
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, TouchPanel.TouchDist.x * lookSpeed, 0); //Input.GetAxis("Mouse Y")
            */

            //PC
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}