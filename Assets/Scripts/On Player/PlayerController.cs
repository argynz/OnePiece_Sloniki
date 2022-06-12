using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    public float walkSpeed;
    public float runSpeed;
    public float movementSpeed;

    private Rigidbody rb;
    public bool isRunning;
    public Vector3 movementDirection;

    public Animator anim;
    private int horizontalAnimHash;
    private int verticalAnimHash;
    private int speedAnimHash;

    public GameObject interactIcon;
    private Vector3 interactionBoxSize = new Vector3(1f, 1f, 1f);

    public GameObject GameOverScreen;
    public int maxHealth = 20;
    public int currentHealth;
    public int maxStarve = 20;
    public int currentStarve;

    public HealthBar healthBar;
    public StarveBar StarveBar;

    public bool isOpen;
    public bool attacks=false;

    
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody>();

        horizontalAnimHash = Animator.StringToHash("Horizontal");
        verticalAnimHash = Animator.StringToHash("Vertical");
        speedAnimHash = Animator.StringToHash("Speed");

        GameOverScreen.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime; 

        currentStarve = maxStarve;
        StarveBar.SetMaxStarve(maxStarve);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // if (FindObjectOfType<InventorySystem>().isOpen)
        //     Time.timeScale = 0.0f;
        // else Time.timeScale = 1.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeStarve(2);
        }

        HandleInputs();
        
        Move();

        if(Input.GetMouseButton(0) && currentState != PlayerState.attack 
           && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else
        {
            
            Animate();
        }
        
        
        
    }

    void HandleInputs()
    {
        
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    bool CanMoveOrInteract()
    {
        bool can = true;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;

        return can;
    }

    private void Move()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = movementDirection * movementSpeed * runSpeed;
        }
        else
        {
            rb.velocity = movementDirection * movementSpeed * walkSpeed;
        }

    }

    private void Animate()
    {
        if (movementDirection != Vector3.zero)
        {
            anim.SetFloat(horizontalAnimHash, movementDirection.x);
            anim.SetFloat(verticalAnimHash, movementDirection.z);
        }
        anim.SetFloat(speedAnimHash, movementSpeed);
    }

    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, interactionBoxSize, Vector3.forward, Quaternion.identity);
        
        if (hits.Length > 0){
            foreach (RaycastHit rc in hits){
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if(currentHealth<1){
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void TakeStarve(int starve)
    {
        currentStarve -= starve;

        StarveBar.SetStarve(currentStarve);
    }
    public void Knock(float knockTime)
    {
        // currentHealth.RuntimeValue -= damage;
        // playerHealthSignal.Raise();
        // if (currentHealth.RuntimeValue > 0)
        // {

             StartCoroutine(KnockCo(knockTime));
        // }else{
        //     this.gameObject.SetActive(false);
        // }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector3.zero;
            currentState = PlayerState.idle;
            rb.velocity = Vector3.zero;
        }
    }
}
