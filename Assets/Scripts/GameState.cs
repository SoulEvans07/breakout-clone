using System.Collections.Generic;
using UnityEngine;

public static class GameState {
    public static List<TextAsset> storyLevels = new List<TextAsset>();
    public static List<TextAsset> userLevels = new List<TextAsset>();
    
    public static string selectedLevel;
}