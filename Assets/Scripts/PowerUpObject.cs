using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/New PowerUp", order = 1)]
public class PowerUpObject : ScriptableObject {
	[SerializeField] public float duration;
	[SerializeField] public bool isOverwritable = true;
	[SerializeField] public PowerUpEvent applyAction;
	[SerializeField] public PowerUpEvent removeAction;
	[SerializeField] public Color color;
	[SerializeField] public PowerUpType type;


    public void Apply(PowerUpHandler handler) {
		applyAction?.Invoke(handler);
	}

	public void Remove(PowerUpHandler handler) {
		removeAction?.Invoke(handler);
	}

    [Serializable]
	public class PowerUpEvent : UnityEvent<PowerUpHandler> {
	}

	public enum PowerUpType {
		PADDLE_LENGTH,
		BALL_COUNT,
		BALL_EFFECT
	}
}