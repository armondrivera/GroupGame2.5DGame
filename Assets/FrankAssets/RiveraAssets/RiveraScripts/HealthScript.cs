using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Let's assume (please) that the HP is integers only? C: (You can adapt this code and also work with Image sliders later! yw.)
public class HealthScript : MonoBehaviour {
	[SerializeField] private int maxHP = 10;
	[SerializeField] private bool alive = true;
	private int curHP;

	public event UnityAction onHPChanged;

	public int HP {
		get { return curHP; }
		set {
			curHP = Mathf.Clamp(value, 0, maxHP);

			Debug.Log("The player's HP is now " + curHP + "!");
			if (curHP <= 0) {
				alive = false;
				GameObject.Destroy(gameObject);
			}

			if (onHPChanged != null)
				onHPChanged();
		}
	}

	public int MaxHP {
		get { return maxHP; }
	}

	// Start is called before the first frame update
	void Start() {
		HP = maxHP;
	}

	// Update is called once per frame
	public void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			HP--;
		}
	}

	public void TakeDamage(int amount) {
		if (!alive)
			return;
		HP -= amount;
	}
}
