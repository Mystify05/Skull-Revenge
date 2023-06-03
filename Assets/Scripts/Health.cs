using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField]
    private float maxHealth = 100;
    private float health;

    public float HealthC { get { return health; } set { health = value; } }

    public void Start()
    {
        slider = GetComponentInChildren<Slider>();
        HealthC = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void Damage(float damage)
    {
        HealthC -= damage;
        SetHealth(HealthC);

        if(HealthC <= 0.0f)
        {
            Destroy(gameObject);
        }

        if(HealthC > maxHealth / 3 * 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if(HealthC > maxHealth / 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 165, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Attack")
        {
            Damage(collision.gameObject.GetComponent<Shot>().Damage);
        }
    }
}
