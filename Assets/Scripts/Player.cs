using UnityEngine;

public class Player : MonoBehaviour
{

    // protected Joystick joystick;
    public Rigidbody2D circleBody;
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
        circleBody = GetComponent<Rigidbody2D>();  
        isMoveLeft = false; 
        isMoveRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        MovemntPlayer();
    //   circleBody.MovePosition(circleBody.position + Vector2.right * speed * joystick.Horizontal * Time.deltaTime);

        // rigidBody.velocity = new Vector2(joystick.Horizontal * 5f, 0);
    }

    private void FixedUpdate(){
        circleBody.velocity = new Vector2(horizontalMove, circleBody.velocity.y);
        
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

    public void PointerDownLeft() {
        isMoveLeft = true; 
    }

    public void PointerUpLeft() {
        isMoveLeft = false; 
    }

    public void PointerDownRight() {
        isMoveRight = true; 
    }

    public void PointerUpRight() {
        isMoveRight = false; 
    }

    private void MovemntPlayer() {
        if (isMoveLeft){
            horizontalMove = -speed;
        } else if (isMoveRight){
            horizontalMove = speed;
        } else {
            horizontalMove = 0;
        }
    }

    public void Flip(){
        
        // Vector3 scaler = transform.localScale;
        // scaler.x *= -1;
        // transform.localxscale  = -1;
        // if(facingRight) {
        //   transform.localRotation = Quaternion.Euler(180, 0, 180);
        //  }
        //  else {
        //     transform.localRotation = Quaternion.Euler(0, 0, 0);
        //  }
         facingRight = !facingRight;
         transform.Rotate(new Vector3(0, 180, 0));
    }
}
