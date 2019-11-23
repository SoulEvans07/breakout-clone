using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/New PowerUp", order = 1)]
public class PowerUp : ScriptableObject {
    //[SerializeField] public string name;
	[SerializeField] public float duration;
	[SerializeField] public bool isOverwritable = true;
	[SerializeField] public PowerUpEvent applyAction;
	[SerializeField] public PowerUpEvent removeAction;
	[SerializeField] public Color color;


    public void Apply(PowerUpHandler handler) {
		applyAction?.Invoke(handler);
	}

	public void Remove(PowerUpHandler handler) {
		removeAction?.Invoke(handler);
	}

    [Serializable]
	public class PowerUpEvent : UnityEvent<PowerUpHandler> {
	}
}