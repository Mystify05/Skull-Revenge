using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    private float health;

    public float HealthC { get { return health; } set { health = value; } }

    public void Start()
    {
        HealthC = maxHealth;
    }

    public void Damage(float damage)
    {
        HealthC -= damage;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Attack")
        {
            Damage(collision.gameObject.GetComponent<Shot>().Damage);
        }
    }
}
