using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdateController : MonoBehaviour
{
    private readonly string URL ="http://linka.su/linkaplay/";

    public Button UpdateButton, PlayButton;
    private static bool close = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckUpdate());
        if (close)
            Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CheckUpdate()
    {


        Text text = UpdateButton.GetComponentInChildren<Text>();
       UnityWebRequest jWWW =  UnityWebRequest.Get(URL+ "version.json");

            yield return jWWW.SendWebRequest();
            if (jWWW.error != null)
            {
                text.text = "Ошибка сети";
        gameObject.transform.Find("ButtonsPanel").gameObject.SetActive(true);
            GameObject.Find("ButtonsPanel").SetActive(true);
                yield break;
            }
            string raw = System.Text.Encoding.UTF8.GetString(jWWW.downloadHandler.data);

            VersionJSON vj =
               JsonUtility.FromJson<VersionJSON>(raw);
            Version appVersion = new Version(Application.version);
            if (vj.Version.CompareTo(appVersion) > 0)
            {
                UpdateButton.enabled = true;
                text.text = "Есть обновление";
                text.color = Color.red;
                if (vj.Ctritical)
                {
                    PlayButton.enabled = false;
                    PlayButton.GetComponentInChildren<Text>().text = "Нельзя продолжить без этого обновления";
                }

            }
            else
            {
                text.text = "Нет обновлений";
            }
        gameObject.transform.Find("ButtonsPanel").gameObject.SetActive(true);

    }

    public void Play()
    {
        close = true;
        GameObject.Destroy(gameObject);
    }

    public void OpenUpdate()
    {
        Application.OpenURL(URL + "linkaplaysetup.exe");
        Application.Quit();
    }
}

internal class VersionJSON
{
public    string version;
  public  bool critical;

    public Version Version
    {
        get => new Version(version);

    }
    public bool Ctritical
    {
        get => critical;
    }
}