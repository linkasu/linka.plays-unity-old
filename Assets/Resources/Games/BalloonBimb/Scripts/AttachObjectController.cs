using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class AttachObjectController : MonoBehaviour
{
    private SpriteRenderer Balloon, Rope, Bomb, Boy;
    private float time;
    public float WaitTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        Balloon = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Rope = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Bomb = transform.GetChild(2).GetComponent<SpriteRenderer>();
        Boy = transform.GetChild(3).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gaze;

        Vector3 point = TobiiAPI.GetGazePoint().Screen;
        if (point.x < 0 || point.y < 0) return;
        gaze = Camera.main.ScreenToWorldPoint(point);
        gaze.z = 0;
        if (!Balloon.bounds.Contains(gaze))
        {
            time = Time.time;
            Balloon.gameObject.GetComponent<Animation>().Stop();
            Balloon.gameObject.GetComponent<AudioSource>().Stop();

            Balloon.color = Color.white;
        }
        else
        {
           if(!Balloon.GetComponent<AudioSource>().isPlaying) Balloon.gameObject.GetComponent<AudioSource>().Play();
            Balloon.gameObject.GetComponent<Animation>().Play();
        }
        if (Time.time - time > WaitTime)
        {

            GameProcessor.InstanceInScene.IncrementStep();
            SoundController.ControllerInScene.PlayAnswerEffect(true);
            GameObject.Destroy(Balloon.gameObject);
            GameObject.Destroy(Rope.gameObject);
            Bomb.gameObject.GetComponent<Animation>().Play();
            Boy.gameObject.GetComponent<Animation>().Play();
            GameObject.Destroy(this);
        }
    }
}