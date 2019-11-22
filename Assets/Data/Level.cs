using System;

/*
    {
        "name": "level_01",
        "map": [
            ...
        ]
    }
*/ 

[Serializable]
public class Level {
    public string name;
    public Brick[] map;
}