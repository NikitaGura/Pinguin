using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{   
    public GameObject projectile;
    public Transform shotPoint;
    public Player player;

    private float timeBetweenShots = 0; 
    public float startTimeBetweenShots;

    private void Start() {
        //player = GetComponent<Player>();  
    }
    
    private void Update()
    {
        timeBetweenShots -= Time.deltaTime;
        if (Input.touchCount > 0 )
        {
            for ( var i = 0 ; i < Input.touchCount ; i++ ) {
                var touch = Input.GetTouch(i);

                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)){
               
                } else { 
                     switch (touch.phase)
                        {
                            case TouchPhase.Began:
                            case TouchPhase.Moved:
                            case TouchPhase.Stationary:
                                
                                player.isShooting = true;

                                Vector3 difference = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                                if(player.facingRight && difference.x < 0) {
                                    player.Flip();
                                } else if (!player.facingRight && difference.x > 0) {
                                    player.Flip();
                                    
                                }
                                
                                if (rotZ < -90 || rotZ > 90) {
                                    transform.rotation = Quaternion.Euler(180f, 0f, -rotZ);
                                }else {
                                    transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
                                }
                               

                                if ( timeBetweenShots <= 0 ){
                                       Instantiate(projectile, shotPoint.position,  transform.rotation);
                                       timeBetweenShots = startTimeBetweenShots;
                                }
                                
                              

                                break;

                            case TouchPhase.Canceled:
                            case TouchPhase.Ended:
                            player.isShooting = false ;
                                break;
                        }
                }

            }
           
        }
    }
}
