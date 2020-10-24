using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorController : MonoBehaviour
{
    private Text text;
    private string currentWord;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }
    public void Print(string word)
    {
        currentWord = word;
        if (text == null)
        {
            Start();
        }
        text.text = word;
    }
    public void ColorSymbols(PointColoring[] points)
    {
        string word = currentWord;
        int offset = 0;
        foreach (var item in points)
        {

            string dye = "<color=#" + ColorToHex(item.color) + ">";

            word = word.Insert(item.start + offset, dye);
            offset += dye.Length;
            word = word.Insert(item.end + offset, "</color>");
            offset += "</color>".Length+1;
        }
        text.text = word;

    }

    string ColorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    public class PointColoring
    {
        internal Color color;
        internal int start;
        internal int end;
        internal PointColoring(int start, int length, Color color)
        {
            this.start = start;
            this.end = start + length;
            this.color = color;
        }
    }
}