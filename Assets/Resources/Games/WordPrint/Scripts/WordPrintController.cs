using UnityEngine;

using UnityEngine.UI;


public class WordPrintController : MonoBehaviour
{
    public Button[] buttons;
    public TextColorController textColorController;

    internal static string[] WORDS = new string[]
    {
        "мама",
        "папа",
        "кот",
        "сова",


"река", "аист", "брат", "боец", "врач", "волк", "винт", "глаз", "горе", "день", "дело", "дочь", "ночь", "печь", "речь", "ёжик", "жаль", "жест", "зима", "заря", "зонт", "змея", "зона", "итог", "игра", "идея", "бант", "лицо", "лист", "матч"
    };
    internal static string ALPHABET = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    private string word;
    int pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => Clicked(button));
        }
        ResetWord();
    }

    private void ResetWord()
    {
        SoundController.ControllerInScene.PlayClip("newTask");
        pos = 0;
        word = WORDS[Random.Range(0, WORDS.Length - 1)];
        textColorController.Print(word);
        var arr = word.ToCharArray();
        while (arr.Length < 5)
        {
            var tmp = new char[arr.Length + 1];
            arr.CopyTo(tmp, 0);
            tmp[arr.Length] = ALPHABET[Random.Range(0, ALPHABET.Length)];
            arr = tmp;     
        }
        Shuffle(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = arr[i].ToString();
        }
       ColorPosition();
    }

    private void ColorPosition()
    {
        textColorController.ColorSymbols(new TextColorController.PointColoring[] {new TextColorController.PointColoring(0,pos, Color.green), new TextColorController.PointColoring(pos-1, 1, Color.red) });
    }

    private void Clicked(Button button)
    {
        char symbol = button.GetComponentInChildren<Text>().text[0];

        bool answer = symbol == word[pos];
        SoundController.ControllerInScene.PlayAnswerEffect(answer);
        if (answer)
        {
            pos++;
            if (word.Length == pos)
            {
                ResetWord();
                GameProcessor.InstanceInScene.IncrementStep();
                return;
            }
            ColorPosition();
        }
        else
        {
            GameProcessor.InstanceInScene.IncrementError();
        }
    }


    private void Shuffle(char[] arr)
    {
        int n = arr.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            var t = arr[n];
            arr[n] = arr[k];
            arr[k] = t;
        }
    }

}
