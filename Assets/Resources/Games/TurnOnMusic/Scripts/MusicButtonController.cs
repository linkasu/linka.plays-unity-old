using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButtonController : MonoBehaviour
{
    private InstrumentsContoller source;
    private Button button;

    private bool plays = false;
    private Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<InstrumentsContoller>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Click();
        });

        buttonImage = transform.GetChild(0).GetComponent<Image>();
        buttonImage.color = Color.black;
    }

    void Click()
    {
        plays = !plays;
        if (plays)
        {
            source.Enable();
            buttonImage.color = Color.white;
            GetComponent<GazeClicker>().enabled = false;
        }
        else
        { buttonImage.color = Color.black;

     
            source.Disable();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}