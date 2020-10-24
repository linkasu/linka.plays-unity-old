using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;


public class GazeTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gaze = TobiiAPI.GetGazePoint();
        Vector3 pos = Camera.main.ScreenToWorldPoint(gaze.Screen);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
