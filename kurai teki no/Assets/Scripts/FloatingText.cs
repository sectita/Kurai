using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, 0);
    void Start()
    {
        Destroy(gameObject, 0.5f);

        transform.localPosition += offset;

    }

    void Update()
    {
        
    }
}
