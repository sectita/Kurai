using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 0, -10f);
    public GameObject player;

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, 0.2f);
    }

}
