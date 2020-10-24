using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedsCountGameProcessor : MonoBehaviour
{
    public TedsController teds;
    private int answer=0;

    // Start is called before the first frame update
    void Start()
    {
        CreateTask();        
    }

    void CreateTask()
    {
        int i = answer;
        while (i == answer)
        {
            i = Random.Range(1, teds.count);
        }
        answer = i;
        teds.ShowCount(answer);
        SoundController.ControllerInScene.PlayClip("newTask");
        
    }

    public void OnNumberInput(int number)
    {
        StartCoroutine(NumberInput(number));
    }
    public IEnumerator NumberInput(int number)
    {
        bool success = number == answer;
        SoundController.ControllerInScene.PlayAnswerEffect(success);
        GameProcessor.InstanceInScene.CheckAnswer(success);
        yield return new WaitForSeconds(3);
        if (success && !GameProcessor.InstanceInScene.end) CreateTask();
    }
}
