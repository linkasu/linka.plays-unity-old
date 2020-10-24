using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using System;
using UnityEngine.Events;

public class GazeClicker : MonoBehaviour
{
    private Button button;
    private RectTransform rectTransform;
    private Image image;
    private bool gazeOnButton;
    private bool wasGazeOnButton;
    private float enterTime;
    private float exitTime;

    public static float ERROR_TIME = 0.2f;
    public static float WAIT_TIME;

    public  UnityEvent OnGazeClick;

    // Start is called before the first frame update
    void Start()
    {
        WAIT_TIME = PlayerPrefs.GetFloat("buttonDelay", 1f);
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint point = TobiiAPI.GetGazePoint();
        Vector2 guipoint = point.Screen;
        gazeOnButton = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, guipoint);

        if (!wasGazeOnButton && gazeOnButton)
        {
            OnGazeEnter();
        } else if (wasGazeOnButton && !gazeOnButton)
        {
            OnGazeExit();
        } else if (wasGazeOnButton && gazeOnButton)
        {
            OnGazeStay();
        } else
        {
            if(Time.time - exitTime > ERROR_TIME)
            {
                image.color = Color.white;
            }
        }

        wasGazeOnButton = gazeOnButton;
    }

    private void OnGazeStay()
    {
        float cTime = Time.time - enterTime;

        float progress = cTime / WAIT_TIME;

        image.color = new Color(1-progress, 1-progress, 1-progress);
        if (progress > 1)
        {
            OnGazeClick.Invoke();
            button.onClick.Invoke();
            enterTime = Time.time;
        }
    }

    private void OnGazeExit()
    {
        exitTime = Time.time;
    }

    private void OnGazeEnter()
    {
        if (Time.time - exitTime < ERROR_TIME)
        {

        }
        else
        {
            enterTime = Time.time;
        }
    }
}
