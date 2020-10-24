using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    float birthday;
    // Start is called before the first frame update
    void Start()
    {
        birthday = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - birthday > 2)
        {
            Destroy(gameObject);
        }
        
    }

    internal void LookAt(Vector3 position)
    {
        Vector3 diff = position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
                transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }
}
