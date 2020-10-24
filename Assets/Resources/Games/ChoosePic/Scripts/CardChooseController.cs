using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class CardChooseController : MonoBehaviour
{
    public    PicCardButton[] buttons;
    public Text label;
    public PicCardButton ImageLabel;
    private PicCard[] picCards;
    private int trueButtonId;
    private AudioSource source;
    private int cardNumber = 2;

    // Start is called before the first frame update
    void Start()
    {
        cardNumber = PlayerPrefs.GetInt("cardsNumber", 2);

        PicCardButton[] temp = new PicCardButton[cardNumber];
        if(buttons.Length>cardNumber)
        {
            for (int i = cardNumber; i < buttons.Length; i++)
            {
                GameObject.Destroy(buttons[i].gameObject);
            }
            for (int i = 0; i < cardNumber; i++)
            {
                temp[i] = buttons[i];
            }
        }

        buttons = temp;
        Debug.Log(buttons.Length);
        source = GetComponent<AudioSource>();
        picCards =  PicCard.cards;
        foreach (var item in buttons)
        {
            item.GetComponent<Button>()
                .onClick
                .AddListener(new UnityEngine.Events.UnityAction(()=>
                {
                  StartCoroutine(  CardClicked(item));
                }));
        }
        PrepareSet();
    }

    void PrepareSet()
    {
        int[] ids = new int[buttons.Length];
        for (int i = 0; i < ids.Length; i++)
        {
            int ind;
            do
            {
                ind = Random.Range(0, picCards.Length - 1);
            } while (ids.Contains(ind));

            ids[i] = ind;
            buttons[i].card = picCards[ind];
        }
        trueButtonId = ids[Random.Range(0, ids.Length - 1)];
        if (label) label.text = picCards[trueButtonId].text;
        else if (ImageLabel) ImageLabel.card = picCards[trueButtonId];
        source.clip = picCards[trueButtonId].clip;
        source.Play();
    }

    private IEnumerator CardClicked(PicCardButton item)
    {
        if (GameProcessor.InstanceInScene.end) yield break;
        bool success = picCards[trueButtonId] == item.card;
        SoundController.ControllerInScene.PlayAnswerEffect(success);
        GameProcessor.InstanceInScene.CheckAnswer(success);
       yield return new WaitForSeconds(3);
        if(success&&!GameProcessor.InstanceInScene.end) PrepareSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
