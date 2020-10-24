using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchAddController : MonoBehaviour
{
    private Text text;
    private Image image;
    private int answer;
    private bool wait =false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponent<Image>();

        for (int i = 1; i < 10; i++)
        {
            int fi = i;
            GameObject.Find(i.ToString()).GetComponent<Button>().onClick.AddListener(() =>
            {

                OnNumberEnter(fi);
            }    );

        }

        GenerateTask();
    }

    void GenerateTask()
    {
        SoundController.ControllerInScene.PlayClip("newTask");
        image.color = Color.white;
        answer = Random.Range(2, 10);
        int first = Random.Range(1, answer - 1);
        int second = answer - first;
        text.text = first + "+" + second + "=";
    }
    public void OnNumberEnter(int number) {
        if (wait) return;
        StartCoroutine(CheckAnswer(number));
    }
    IEnumerator CheckAnswer(int number)
    {
        text.text = text.text.Substring(0, 4);
        text.text += number;
        bool success = number == answer;
        image.color = success ? Color.green : Color.red;
        SoundController.ControllerInScene.PlayAnswerEffect(success);
        wait = true;
        if (success)
        {
            GameProcessor.InstanceInScene.IncrementStep();
        }
        else
        {
            GameProcessor.InstanceInScene.IncrementError();
        }
        yield return new WaitForSeconds(3);
        wait = false;
        if(success) GenerateTask();
    }
}
