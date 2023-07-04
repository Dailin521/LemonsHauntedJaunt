using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
