using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask groundLayer;
    private float horizontalInput;
    
        private Rigidbody2D rb;

    private float moveSpeed;

    private bool moveLeft, moveRight;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 6;
        moveLeft = false;
        moveRight = false;
    }

        public void MoveLeft()
    {
        moveLeft = true;        
    }

    public void MoveRight()
    {
        moveRight = true;

    }

        public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
    }



    public void Update()
    {

        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, body.velocity.y);
            transform.localScale = new Vector3(-4,4,4);
            
        }

        if (moveRight)
        {
            
            rb.velocity = new Vector2(moveSpeed, body.velocity.y);
            transform.localScale = new Vector3(4,4,4);
        }

        
        if(Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

           

        anim.SetBool("run", moveRight == true || moveLeft == true);
        anim.SetBool("grounded", isGrounded());
    }
 
    public void Jump()
    {
        if(isGrounded() ){
        body.velocity = new Vector2(body.velocity.x, speed * 2.25f);
        anim.SetTrigger("jump");
     }
        
    }


    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
        0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }



    public bool canAttack()
    {
        return isGrounded();

    }

    public void Replay()
    {

         SceneManager.LoadScene("BadEnd");
    }



}
