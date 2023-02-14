using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float start_pos;
    private GameObject cam;
    
    [SerializeField] 
    float parallax_effect;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        start_pos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = (cam.transform.position.x * parallax_effect);
        transform.position = new Vector3(start_pos + distance, transform.position.y, transform.position.z);
    }
}
