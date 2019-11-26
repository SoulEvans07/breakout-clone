using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapLoader : MonoBehaviour {
    public GamePlayController _gameController;
    public GameObject brickPrefab;
    public List<PowerUpObject> powerupList = new List<PowerUpObject>();
    private Dictionary<string, PowerUpObject> powerupMap;

    public void Awake() {
        powerupMap = MapPowerUps(powerupList);
        Level level = JsonUtility.FromJson<Level>(GameState.selectedLevel);
        Load(level);
    }

    public static Dictionary<string, PowerUpObject> MapPowerUps(List<PowerUpObject> powerupList) {
        Dictionary<string, PowerUpObject> map = new Dictionary<string, PowerUpObject>();
        foreach(PowerUpObject pu in powerupList) {
            map.Add(pu.name, pu);
        }
        return map;
    }

    private void Load(Level level) {
        foreach (Brick brick in level.map) {
            SpawnBrick(brick);
        }
    }

    private void SpawnBrick(Brick brickData) {
        Vector3 pos = new Vector3(brickData.x * 16, brickData.y * -8);
        GameObject brick = Instantiate(brickPrefab, Vector3.zero, Quaternion.identity);
        brick.transform.parent = this.gameObject.transform;
        brick.transform.localPosition = pos;
        Color color;
        if (ColorUtility.TryParseHtmlString(brickData.color, out color)) {
            brick.GetComponent<SpriteRenderer>().color = color;
            BrickController controller = brick.GetComponent<BrickController>();
            controller.SetGameController(_gameController);
            controller.SetHitPoint(brickData.hitPoints);
            
            if (brickData.powerUp.name != null) {
                PowerUpObject pu = powerupMap[brickData.powerUp.name];

                if (pu != null) {
                    pu.duration = brickData.powerUp.duration;
                    controller.powerUp = pu;
                }
            }
        }
    }
}