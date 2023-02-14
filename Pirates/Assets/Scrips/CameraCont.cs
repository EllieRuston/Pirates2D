using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  // camera follower player value z = unity value
        transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
    }
}
