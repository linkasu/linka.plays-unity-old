using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="PicCard", menuName ="MironGames/New Pic Card", order =2)]
public class PicCard : ScriptableObject
{
    [SerializeField]
    private string Text;
    [SerializeField]
    private Sprite Sprite;
    [SerializeField]
    private AudioClip Clip;
    private static readonly string PATH = "PicCards";

    public static PicCard[] cards
    {
        get
        {
          return  Resources.LoadAll<PicCard>(PATH);
        }
    }
    public static PicCard FindCard(string name)
    {
        return Resources.Load<PicCard>(PATH + "/" + name);
    }

#if UNITY_EDITOR
    [MenuItem("Tools/Create Cards")]
    public static void CreateCards()
    {
       Sprite[] sprites =  Resources.LoadAll<Sprite>("Typing/wordimgs");
        foreach(Sprite sprite in sprites)
        {
           string name= sprite.name;
            AudioClip clip = Resources.Load<AudioClip>("Typing/wordaudio/" + name);
            var obj = ScriptableObject.CreateInstance<PicCard>();
            obj.Clip = clip;
            obj.Sprite = sprite;
            obj.name = obj.Text = name;
            string path = "Assets/Resources/"+ PATH + "/" + name + ".asset";
            
            AssetDatabase.CreateAsset(obj, path);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
    }
#endif
    public string text
    {
        get
        {
            return Text;
        }
    }


    public Sprite sprite
    {
        get
        {
            return Sprite;
        }
    }
    public AudioClip clip
    {
        get
        {
            return Clip;
        }
    }
}
