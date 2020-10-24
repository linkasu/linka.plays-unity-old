using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcessor : MonoBehaviour
{
    public int steps = 10;

    public Text StepsText;
    public Text[] ErrorsTexts;
    public GameObject GameOverPanel;
    public Image Answer;
       
    private int step = 0;
    private int errors = 0;

    private string stepsPrefix;
    private string errorsPrefix;

    // Start is called before the first frame update
    void Start()
    {
        stepsPrefix = StepsText.text;
        errorsPrefix = ErrorsTexts[0].text;
        Answer.gameObject.SetActive(false);
        Render();
    }

    void Render()
    {
        StepsText.text = stepsPrefix + step + "/" + steps;
        foreach (var ErrorsText in ErrorsTexts)
        {
            ErrorsText.text = errorsPrefix + errors;

        }
    }

    public void IncrementStep()
    {
        step++;
        Render();
        if (step == steps)
        {
            GameOverPanel.SetActive( true);
        }
    }
    public void IncrementError()
    {
        errors++;
        Render();
    }

    public static GameProcessor InstanceInScene
    {
        get
        {
            return GameObject.Find("GameProcess").GetComponent<GameProcessor>();
        }
    }

    public bool end { get
        {
            return step+1 > steps;
        }
    }

    public int Step { get=> step;  }

    internal void CheckAnswer(bool success)
    {

        Answer.color = success ? Color.green : Color.red;
        Answer.gameObject.SetActive(true);

        StartCoroutine(WaitAnswerToggle());
        if (success)
        {
            IncrementStep();
        }
        else
        {
            IncrementError();
        }
    }
    IEnumerator WaitAnswerToggle()
    {
        yield return new WaitForSeconds(3);
        Answer.gameObject.SetActive(false);
    }
}
