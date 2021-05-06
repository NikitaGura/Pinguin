using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    public Rigidbody2D playRG;
    public float speed = 20f;

    private bool isMoveLeft;
    private bool isMoveRight;
    private float horizontalMove;
    public bool facingRight = true;
    public bool isShooting  = false;

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();  
        playRG = GetComponent<Rigidbody2D>();  
        isMoveLeft = false; 
        isMoveRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        MovemntPlayer();
       

        // rigidBody.velocity = new Vector2(joystick.Horizontal * 5f, 0);
    }

    private void FixedUpdate(){
        playRG.velocity = new Vector2(horizontalMove, playRG.velocity.y);
        
       
      
        if (facingRight && horizontalMove < 0 && !isShooting){
            Flip();
        } else if (!facingRight && horizontalMove > 0 && !isShooting ){
            Flip();
        }

        if(horizontalMove == 0 ){
            animator.SetBool("isRunning", false);
        } else {
            animator.SetBool("isRunning", true);
        }
    }

    private void MovemntPlayer() {
        if(Mathf.Abs(joystick.Vertical) > 0.1f || Mathf.Abs(joystick.Horizontal) > 0.1f){
            if (joystick.Horizontal < 0){
                horizontalMove = -speed * joystick.Horizontal * -1;
            } else if (joystick.Horizontal > 0){
                horizontalMove = speed * joystick.Horizontal;
            }
        } else {
            horizontalMove = 0;
        }
        
    }

    public void Flip(){
         facingRight = !facingRight;
         transform.Rotate(new Vector3(0, 180, 0));
    }
}
