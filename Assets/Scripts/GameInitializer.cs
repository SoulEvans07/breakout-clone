using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
    public static string GAME_FOLDER = ".breakout-clone";
    public static string USER_HOME = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public List<TextAsset> storyLevels = new List<TextAsset>();
    public TextAsset userLevelTemplate;
    public List<TextAsset> userLevels = new List<TextAsset>();

    private void Awake() {
        string absoluteGameFolderPath = USER_HOME + Path.DirectorySeparatorChar + GAME_FOLDER;
        string templateFilePath = absoluteGameFolderPath + Path.DirectorySeparatorChar + userLevelTemplate.name + ".json";

        if(!Directory.Exists(absoluteGameFolderPath)) {
            Directory.CreateDirectory(absoluteGameFolderPath);
        }

        if(!File.Exists(templateFilePath)) {
            WriteJsonToFile(templateFilePath, userLevelTemplate.text);
        }

        string[] userLevelPathList = Directory.GetFiles(absoluteGameFolderPath);
        foreach(string path in userLevelPathList) {
            TextAsset asset = new TextAsset(ReadJsonFromFile(path));

            string[] parts = path.Split(Path.DirectorySeparatorChar);
            asset.name = parts[parts.Length - 1];
            
            userLevels.Add(asset);
        }
    }

    private string ReadJsonFromFile(string path) {
        StreamReader reader = new StreamReader(path); 
        return reader.ReadToEnd();
    }

    private void WriteJsonToFile(string path, string text) {
        File.WriteAllText(path, text);
    }
}