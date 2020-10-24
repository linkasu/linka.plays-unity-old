using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class RollBallController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
/*        GazePoint gaze = TobiiAPI.GetGazePoint();
        if (!gaze.IsValid&&gaze.Screen.magnitude<0) return;
       Vector3 point = Camera.main.ScreenToWorldPoint( gaze.Screen);
        point.z = 0;
           float dis = (Vector3.Distance(point, transform.position));
        bool inside = dis < transform.lossyScale.x;
        GetComponent<MeshRenderer>().material.color = inside ? Color.green : Color.red;
        if (inside)
        {
//            Roll();
        }
  */  }

    public void Roll()
    {
            rb.AddForce(Vector3.right*10F+Vector3.up*0.75f);

    }
}
