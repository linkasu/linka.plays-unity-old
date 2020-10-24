using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "GameInfo", menuName = "MironGames/New Game Info File", order = 2)]

public class GameInfo : ScriptableObject
{
#if UNITY_EDITOR
    private void Awake()
    {
        string path = Path.GetDirectoryName(UnityEditor.AssetDatabase.GetAssetPath(this));
        path = path.Substring(path.LastIndexOf("\\")+1);
        GameId = path;
    }
#endif

    [SerializeField]
    private int Type;
    [SerializeField]
    private string Title;
    [SerializeField]
    private string GameId;


    public int type
    {
        get => Type;
    }
    public string title
    {
        get => Title;
    }
    public string gameId
    {
        get => GameId;
    }

}
