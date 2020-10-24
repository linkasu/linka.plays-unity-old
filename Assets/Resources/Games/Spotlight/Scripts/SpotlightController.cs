using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;

public class SpotlightController : MonoBehaviour
{
    private Sprite[] sprites ;

    private RectTransform rectTransform;
    private Image image;
   private Image fireSpriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        fireSpriteRenderer = transform.GetChild(0).GetComponent<Image>();

        sprites = Resources.LoadAll<Sprite>("imgs/typing");

        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GazePoint point = TobiiAPI.GetGazePoint();
        Vector2 guipoint = point.Screen;
        bool gazeOnButton = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, guipoint);
        
        if (gazeOnButton&&image.enabled) { 
    
            SoundController.ControllerInScene.PlayClip("good");
            
           StartCoroutine( Move());
        }        
    }

    IEnumerator Move()
    {
        fireSpriteRenderer.enabled = true;
        image.enabled = false;
        yield return new WaitForSeconds(2);
        SoundController.ControllerInScene.PlayClip("newTask");

        fireSpriteRenderer.enabled = false;
        image.enabled = true;
       image.sprite= sprites[Random.Range(0, sprites.Length-1)];
        float width = Screen.width;
        float height = Screen.height;
        transform.position = new Vector2(Random.Range(0, width), Random.Range(0, height))*0.75f;
        
    }

}
