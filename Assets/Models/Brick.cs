using System;

/* {
        "type": 0, 
        "x": -7, 
        "y": 0, 
        "value": 1, 
        "color": "#0000ff", 
        "powerup": { 
            "name": "BallSpeedUp", 
            "duration": 15 
        } 
    }
*/

[Serializable]
public class Brick {
    public int type;
    public int x, y;
    public int value;
    public string color;
    public PowerUp powerUp;
}