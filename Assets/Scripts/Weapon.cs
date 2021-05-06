using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{   
    public GameObject projectile;
    public Transform shotPoint;
    public Player player;
    public Joystick joystick;

    private float timeBetweenShots = 0; 
    public float startTimeBetweenShots;

    private void Update()
    {
        timeBetweenShots -= Time.deltaTime;
        
        if(Mathf.Abs(joystick.Vertical) > 0.3f || Mathf.Abs(joystick.Horizontal) > 0.3f){
              player.isShooting = true;
              float rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
                                
              if (rotZ < -90 || rotZ > 90) {
                    transform.rotation = Quaternion.Euler(180f, 0f, -rotZ);
                    if(player.facingRight ) {
                            player.Flip();
                    }
                }else {
                    transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
                    if(!player.facingRight ) {
                            player.Flip();
                    }
                }
                
                if ( timeBetweenShots <= 0 ){
                    Instantiate(projectile, shotPoint.position,  transform.rotation);
                    timeBetweenShots = startTimeBetweenShots;
                }
        }else{
            player.isShooting = false;
        }
    }
}
