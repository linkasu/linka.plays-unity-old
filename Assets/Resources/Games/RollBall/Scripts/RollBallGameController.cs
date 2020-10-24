using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBallGameController : MonoBehaviour
{
    private GameObject sphere;
    private Vector3 sphereZero;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] finishes = GameObject.FindGameObjectsWithTag("Finish");
        GameProcessor.InstanceInScene.steps= finishes.Length+1;
        sphere = GameObject.Find("Sphere");
        sphereZero = sphere.transform.position;
        foreach (var finish in finishes)
        {
            finish.GetComponent<FinishController>()
                .OnFinish.AddListener(Move);
        }
        Move();
    }

    private void Move()
    {
        Vector3 move = Vector3.right * GameProcessor.InstanceInScene.Step * 30;
        Camera.main.transform.position = Vector3.forward*-10+ move;
        sphere.transform.position = sphereZero+move;

        if (GameProcessor.InstanceInScene.Step-1<GameProcessor.InstanceInScene.steps)
        {
            GameProcessor.InstanceInScene.IncrementStep();
            SoundController.ControllerInScene.PlayAnswerEffect(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
