using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
    public static string GAME_FOLDER = ".breakout-clone";
    public static string USER_HOME = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public List<TextAsset> storyLevels = new List<TextAsset>();
    public TextAsset userLevelTemplate;

    private void Awake() {
        GameState.storyLevels = new List<TextAsset>();
        GameState.userLevels = new List<TextAsset>();

        string absoluteGameFolderPath = USER_HOME + Path.DirectorySeparatorChar + GAME_FOLDER;
        string templateFilePath = absoluteGameFolderPath + Path.DirectorySeparatorChar + userLevelTemplate.name + ".json";

        if(!Directory.Exists(absoluteGameFolderPath)) {
            Directory.CreateDirectory(absoluteGameFolderPath);
        }

        if(!File.Exists(templateFilePath)) {
            WriteJsonToFile(templateFilePath, userLevelTemplate.text);
        }

        foreach (TextAsset lvl in storyLevels) {
            GameState.storyLevels.Add(lvl);
        }

        string[] userLevelPathList = Directory.GetFiles(absoluteGameFolderPath);
        foreach(string path in userLevelPathList) {
            string[] parts = path.Split(Path.DirectorySeparatorChar);
            
            string fileName = parts[parts.Length - 1];
            fileName = fileName.Substring(0, fileName.Length - 5);

            if (fileName != userLevelTemplate.name) {
                TextAsset asset = new TextAsset(ReadJsonFromFile(path));
                asset.name = fileName;
                GameState.userLevels.Add(asset);
            }
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