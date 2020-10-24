using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TedsController : MonoBehaviour
{
    Image[] images;

    public int count { get
        {
            if (images == null) Start();
            return images.Length;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        images = new Image[transform.childCount];
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = transform.GetChild(i).gameObject.GetComponent<Image>();
        }   
    }

    void HideAll()
    {
        foreach (var item in images)
        {
            item.enabled = false;
        }
    }
    public void ShowCount(int count)
    {

        HideAll();
        for (int i = 0; i < count; i++)
        {
            images[i].enabled = true;
        }
    }
}
