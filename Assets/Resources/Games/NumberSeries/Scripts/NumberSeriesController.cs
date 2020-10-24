using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberSeriesController : MonoBehaviour
{
    public Text[] Output;
    public Button[] Input;
    private Text[] InputTexts;
    private int[] answers;
    private int trueAnswer;
    private bool wait;

    // Start is called before the first frame update
    void Start()
    {
        InputTexts = new Text[Input.Length];
        for (int i = 0; i < Input.Length; i++)
        {
            int fixI = i;

            InputTexts[i] = Input[i].GetComponentInChildren<Text>();
            InputTexts[i].text = i.ToString();
            Input[i].onClick.AddListener(() =>
            {
                if (answers == null) return;
               StartCoroutine( Click(answers[fixI]));
            });
        }

        FillAnswers();
    }

    void FillAnswers()
    {
        SoundController.ControllerInScene.PlayClip("newTask");
        answers = new int[Input.Length];
       trueAnswer = Random.Range(1, 9);
        answers[Random.Range(0, answers.Length-1)] = trueAnswer;
        for (int i = 0; i < Input.Length; i++)
        {
            if (answers[i] == 0)
            {
                answers[i] = Random.Range(1, 9);

            }
            InputTexts[i].text = answers[i].ToString();
        }

        Output[trueAnswer - 1].text = "?";
        Output[trueAnswer - 1].color = Color.red;
    }
    IEnumerator Click(int answer)
    {

        SoundController.ControllerInScene.PlayAnswerEffect(answer == trueAnswer);
        GameProcessor.InstanceInScene.CheckAnswer(answer == trueAnswer);
        if (wait) yield break; ;
        wait = true;
        Text text = Output[answer- 1];
        text.text = answer.ToString();
        text.color = Color.green;
        yield return new WaitForSeconds(2);
        text.color = Color.black;
        FillAnswers();
        wait = false;
    }
    
}
