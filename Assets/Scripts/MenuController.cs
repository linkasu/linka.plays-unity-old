using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Analytics;

public class MenuController : MonoBehaviour
{
    public Text EyeStatus;
    private GameInfo[] games;
    public Button ButtonPrefab;


    private void Start()
    {
       games = Resources.LoadAll<GameInfo>("Games").OrderBy(o => o.type).ToArray<GameInfo>();
        GenerateButtons();

    }

    private void GenerateButtons()
    {
        GameObject[] views= GameObject.FindGameObjectsWithTag("ScrollViewForButtons").OrderBy(v=>v.name).ToArray<GameObject>();

        int lastType = -1;
        int[] ys = new int[views.Length];
        for (int i = 0; i < ys.Length; i++)
        {
            ys[i] = 0;
        }
        for (int i = 0; i < games.Length; i++)
        {
            GameInfo game = games[i];

            if (lastType != game.type)
            {
                lastType = game.type;
            }
            //Rect position = ;
            Debug.Log(views[lastType].name);
            Button button = GameObject.Instantiate(ButtonPrefab, views[lastType].transform);
            button.GetComponentInChildren<Text>().text = game.title;
            button.GetComponent<RectTransform>().localPosition -= new Vector3(0, ys[lastType], 0);
            ys[lastType] += 30;

            button.onClick.AddListener(() =>
            {
                Analytics.SendEvent("runGame", game.gameId);
                SceneManager.LoadScene("Assets/Resources/Games/" + game.gameId + "/scene.unity");
                
            });

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        var point = TobiiAPI.GetGazePoint();

        EyeStatus.text = point.IsValid ? "Трекер готов к работе" : "Глаза не найдены";
        EyeStatus.color = point.IsValid ? Color.green : Color.red;
        
    }
    public void OpenScene(int number)
    {
        SceneManager.LoadScene(number);
    }
    
}
