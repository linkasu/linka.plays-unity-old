using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    public RandomImageSetter[] answers;
    public RandomImageSetter target;
    private bool wait;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var answer in answers)
        {
            answer.GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    if (wait) return;
                    StartCoroutine(CheckResult(answer.currentSprite==target.currentSprite));
                });
        }
    }

    private IEnumerator CheckResult(bool v)
    {
        wait = true;
        SoundController.ControllerInScene.PlayAnswerEffect(v);
        GameProcessor.InstanceInScene.CheckAnswer(v);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(3);
        if(v)SetGameSet();
        wait = false;
        yield return null;
    }

    private void ColorAllButtons(bool v)
    {
        foreach (var answer in answers)
        {
  //          answer.SetColor(v ? Color.green : Color.red);
        }
    }

    void SetGameSet()
    {
        SoundController.ControllerInScene.PlayClip("newTask");
       Sprite tsprite = target.SetRandomImage();
        int truePosition = UnityEngine.Random.Range(0, answers.Length);
        answers[truePosition].currentSprite = tsprite;
        for (int i = 0; i < answers.Length; i++)
        {
            if (i == truePosition) continue;
            answers[i].SetRandomImage();
            while (answers[i].currentSprite == tsprite)
            {
                answers[i].SetRandomImage();
            }
        }
    }

}
