using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImageSetter : MonoBehaviour
{
    public Sprite[] sprites;

    private Image buttonImage;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = transform.GetChild(0).GetComponent<Image>();
        
    }

    public Sprite SetRandomImage()
    {
        Sprite sprite = sprites[Random.Range(0, sprites.Length - 1)];
        currentSprite = sprite;

        return sprite;
    }

    public void SetColor(Color color)
    {
        buttonImage.color = color;
    }

    public Sprite currentSprite
    {
        get
        {
            return buttonImage.sprite;
        }
        set
        {
            buttonImage.color = Color.white;
            buttonImage.sprite = value;
        }
    }
}
