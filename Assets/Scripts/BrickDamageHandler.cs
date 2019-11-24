using UnityEngine;

public class BrickDamageHandler : MonoBehaviour {
    private SpriteRenderer _renderer;

    public Sprite unbreakableSprite;
    public Sprite[] damageSprites;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetUnbreakable() {
        _renderer.sprite = unbreakableSprite;
    }

    public void SetDamage(int dmg, int hitPoints) {
        if (dmg == 0) {
            _renderer.sprite = null;
        } else if (dmg > 0) {
            int length = damageSprites.Length; 
            int index = length - (int) Mathf.Ceil(length / (float) (hitPoints-1)) * ((hitPoints - 1) - dmg) - 1;
            _renderer.sprite = damageSprites[index];
        }
    }
}