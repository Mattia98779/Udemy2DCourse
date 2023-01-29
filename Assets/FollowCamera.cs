using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    public GameObject thingsToFollow;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingsToFollow.transform.position + Vector3.back;
    }
}
