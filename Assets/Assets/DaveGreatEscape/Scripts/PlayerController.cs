using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BubblesSleepyEffectPrefab;
    private Animator anim;
    public Animator animator;
    private Rigidbody2D rb;
    public Transform FeetPos;
    public LayerMask GroundmMask;
    public AudioClip JumpSound;
    private float jumpTimeCounter;
    private float speed = 3f;
    private float JumpForce = 6f;
    private float jumpTime = 0.2f;
    public float CheckRadius, defaultAnimatorSpeed;
    private bool isHit, isJumping, hasEntered, privatePlayerControl;
    public bool PlayerControl, groundTouch;
    void Start()
    {
        privatePlayerControl = true;
        isHit = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        defaultAnimatorSpeed = animator.speed;
    }

    void Update()
    {
        if(PlayerControl == true 
            && privatePlayerControl == true) 
        {
            IsTouchingGround();
        }
    }


    void FixedUpdate()
    {
        if(PlayerControl == true 
            && isHit == false
            && privatePlayerControl == true)
        {
            PlayerMovement();
            animator.speed = defaultAnimatorSpeed;
        }
        else if(PlayerControl == false)
        {
            this.transform.position = new Vector2 (transform.position.x, transform.position.y);
            animator.speed = 0;
        }
    }
    private void PlayerMovement()
    {
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            //running animation
            if (moveInput == 0)
            {
                anim.SetBool("IsRunning", false);
            }
            else
            {
                anim.SetBool("IsRunning", true);
            }
            //jump animation
            if ( rb.velocity.y >0)
            {
                anim.SetBool("IsJumpingUp", true);
            }
            else if( rb.velocity.y < 0 && groundTouch == false)
            {
                anim.SetBool("IsJumpingUp", false);
                anim.SetBool("IsFalling", true);   
            }
            else if(groundTouch == true)
            {
                anim.SetBool("IsJumpingUp", false);
                anim.SetBool("IsFalling", false);
            }
            if(moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0,180,0);
            }
            else if(moveInput > 0)
            {
                transform.eulerAngles = new Vector3(0,0,0);
            }
    }

    private void IsTouchingGround()
    {
        groundTouch = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, GroundmMask);

        if(groundTouch == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * JumpForce;
            SoundManager.instance.PlaySFX(JumpSound);
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "enemy" && !hasEntered)
        {
            hasEntered = true;
            CallPlayerDeath();
        }
    }
    IEnumerator PlayerDeath()
    {
        float transitionTime = 0.8f;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        anim.SetBool("IsHit", true);
        isHit = true;
        yield return new WaitForSeconds(transitionTime);
        GameObject.Find("LifePointsHealthPoints").GetComponent<DaveHealthPoints>().HealthPoints--;
        if(GameObject.Find("LifePointsHealthPoints").GetComponent<DaveHealthPoints>().HealthPoints > 0)
        {
            LevelManager.instance.Respawn();                   
        }
        Destroy(this.gameObject);
    }

    private void CallPlayerDeath()
    {
        StartCoroutine(PlayerDeath());
        anim.SetBool("IsFalling" , false);
        anim.SetBool("IsJumpingUp" , false);
        anim.SetBool("IsRunning" , false);
    }
    public void startEndSceneAnim()
    {
        StartCoroutine(startEndSceneSequence());
    }
    private IEnumerator startEndSceneSequence()
    {
        privatePlayerControl = false;
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("IsRunning" , true);
        if(transform.position.x > 12.2f)
        {
            if(transform.rotation.y != -180f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -180f, transform.rotation.eulerAngles.z);
            }
            do
            {
                transform.position += Vector3.left * (speed * Time.deltaTime);
                yield return null;
            }
            while(transform.position.x >= 12.1f);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0.0f, transform.rotation.eulerAngles.z);
        }
        else if(transform.position.x < 12.1f)
        {
            if(transform.rotation.y != 0.0f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0.0f, transform.rotation.eulerAngles.z);
            }
            do
            {
                transform.position += Vector3.right * (speed * Time.deltaTime);
                yield return null;
            }
            while(transform.position.x <= 12.2f);
        }
        transform.position = new Vector2(12.2f, transform.position.y);
        anim.SetBool("IsRunning" , false);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        anim.SetBool("isEndGameAnim", true);
    }
    private void StopPart1EndAnimation()
    {
        gameObject.transform.position = new Vector2(transform.position.x +0.1f, transform.position.y +0.35f); //-0.5f;
        anim.SetBool("isEndGameAnim", false);
        Instantiate(BubblesSleepyEffectPrefab,transform.position,transform.rotation);
    }
}
