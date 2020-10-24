using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    private Slider dslider;
    private Slider cnslider;

    // Start is called before the first frame update
    void Start()
    {
        dslider = GameObject.Find("DelaySlider").GetComponent<Slider>();
        dslider.value = PlayerPrefs.GetFloat("buttonDelay", 1f);
        cnslider = GameObject.Find("CardsNumberSlider").GetComponent<Slider>();
        cnslider.value = PlayerPrefs.GetFloat("cardsNumber", 4f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("buttonDelay", dslider.value);
        PlayerPrefs.SetInt("cardsNumber", (int) cnslider.value);
        SceneManager.LoadScene(0);
    }
}
