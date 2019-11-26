using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class LevelSelector : MonoBehaviour {
    private RectTransform _transform;
    public GameObject levelButtonPrefab;
    public float spacing = 0.2f;
    private float btnHeight;

    public UnityEvent backToMainMenu;

    private void Awake() {
        _transform = GetComponent<RectTransform>();
        btnHeight = levelButtonPrefab.GetComponent<RectTransform>().rect.height;

        int i = 1;
        foreach(TextAsset lvl in GameState.storyLevels) {
            PlaceButton(NextPos(i), () => this.SelectLevel(lvl), lvl.name);
            i++;
        }

        PlaceButton(NextPos(i) + Vector3.down * btnHeight, backToMainMenu.Invoke, "Back");
        
    }

    private Vector3 NextPos(int i) {
        return new Vector3(0, -1 * (i * btnHeight/2 + (i-1) * (1 + spacing) * btnHeight/2 + btnHeight), 0);
    }

    private void PlaceButton(Vector3 pos, UnityAction action, string labelText) {
        GameObject lvlObj = Instantiate(levelButtonPrefab, Vector3.zero, Quaternion.identity);
        lvlObj.GetComponent<RectTransform>().SetPositionAndRotation(pos, Quaternion.identity);
        lvlObj.transform.SetParent(_transform, false);

        Button lvlBtn = lvlObj.GetComponent<Button>();
        lvlBtn.onClick.AddListener(action);

        TextMeshProUGUI label = lvlObj.GetComponentInChildren<TextMeshProUGUI>();
        label.text = labelText;
    }


    public void SelectLevel(TextAsset lvl) {
        GameState.selectedLevel = lvl.text;
        SceneManager.LoadScene("GameScene");
    }
}