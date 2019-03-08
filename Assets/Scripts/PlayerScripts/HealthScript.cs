using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int maxHP = 6;
    [SerializeField] private bool destroyOnDeath = true;

    private int hp;
    public float invTimer;
    private float spareTimer;
    public event UnityAction onHPChanged;
    public event UnityAction onDeath;
    public GameObject gameOverCanvas;
    public GameObject KillBox;

    //C# Properties -- these are beautiful. They run just like methods.
    public bool IsAlive
    {
        get { return hp > 0; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int HP
    {
        get { return hp; }
        private set
        {
            int newValue = Mathf.Clamp(value, 0, maxHP);
            //This prevents redundancies. For ex: Trying to take damage when already at 0 hp.
            if (newValue == hp)
                return;
            hp = newValue;
            Debug.Log("Setting " + name + "'s HP to " + hp + ".");

            if (onHPChanged != null)
                onHPChanged();

            if (destroyOnDeath && !IsAlive)
            {
                if (onDeath != null)
                    onDeath();
                Destroy(gameObject);
            }
        }
    }

    //OnValidate runs in the editor, especially when you change stuff in this script's Inspector.
    public void OnValidate()
    {
        //This line below ensures that maxHP is never negative (it's always the highest number between itself and 0. No if statement needed!)
        maxHP = Mathf.Max(0, maxHP);
    }

    public void Awake()
    {
        spareTimer = invTimer;
        hp = maxHP;
    }

    public void Update()
    {
        if (GameManager.IsDeveloperMode)
        {
            if (Input.GetKeyDown(KeyCode.H))
                TakeDamage(1);
        }

        if (invTimer > 0)
        {
            invTimer -= Time.deltaTime;
        }

        if (hp <= 0 || HP <= 0)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    public void TakeDamage(int amount)
    {
        if (!IsAlive)
            return;
        if (invTimer < 0)
        {
            HP -= amount;
            invTimer = spareTimer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KillBox")
        {
            hp = 0;
            HP = 0;
            Destroy(gameObject);
        }
    }
}
