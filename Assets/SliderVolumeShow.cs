using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeShow : MonoBehaviour
{
    Slider slider;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<Text>();
        text.text = slider.value.ToString();

        slider.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<float>((float v) =>
        {
            text.text = v.ToString();
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
