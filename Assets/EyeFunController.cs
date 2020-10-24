using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class EyeFunController : MonoBehaviour
{
    public RollBallController ball;
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gaze = TobiiAPI.GetGazePoint();
        if (!gaze.IsValid && gaze.Screen.magnitude < 0) return;
        Vector3 point = Camera.main.ScreenToWorldPoint(gaze.Screen);
        point.z = 0;
        float dis = (Vector3.Distance(point, transform.position));
        bool inside = dis < transform.lossyScale.x/2;
       // GetComponent<MeshRenderer>().material.color = inside ? Color.green : Color.red;
        if (inside)
        {
            animation.Play();
            ball.Roll();
        }else
        {
            animation.Stop();
        }


    }
}
