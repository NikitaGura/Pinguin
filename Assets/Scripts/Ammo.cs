using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    // public GameObject destroyEffect;

    void Start() {
        Invoke("DestroyAmmo", lifeTime);
    }
  
    void Update()
    {   
       transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    protected void DestroyAmmo () {

        Destroy(gameObject);
    }
}
