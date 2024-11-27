using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -7);

    void Start() 
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

 
}
