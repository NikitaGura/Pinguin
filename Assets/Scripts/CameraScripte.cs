using UnityEngine;

public class CameraScripte : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 2f, -10f);
    }
}
