using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PicCardButton : MonoBehaviour
{
    private PicCard Card;
    private Image image;
    private Text text;
    private AudioSource source;


    public bool ShowImage = true;
    public PicCard card
    {
        get
        {
            return Card;
        }
        set
        {
            Card = value;
            if (image == null)
            {
                Set();
            }
            image.sprite = Card.sprite;
            source.clip = Card.clip;
            text.text = Card.text;
        }
    }
    
    // Start is called before the first frame update
    void Set()
    {
        source = GetComponent<AudioSource>();
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<Text>();

        text.enabled = !(image.enabled = ShowImage);
    }

}
