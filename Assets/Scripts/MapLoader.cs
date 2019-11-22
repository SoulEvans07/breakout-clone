using System.IO;
using UnityEngine;

public class MapLoader : MonoBehaviour {
    public GameObject brickPrefab;
    public string path = "Assets/Resources/level_01.json";

    public void Awake() {
        string json = ReadJsonFile(path);
        Level level = JsonUtility.FromJson<Level>(json);
        Load(level);
    }

    private string ReadJsonFile(string path) {
        StreamReader reader = new StreamReader(path); 
        return reader.ReadToEnd();
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
        }
    }
}