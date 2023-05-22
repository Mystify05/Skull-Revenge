using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float damage = 10;

    public float Speed { get { return speed; } set { speed = value; } }
    public float Damage { get { return damage; } set { damage= value; } }
    // Start is called before the first frame update
    void Start()
    {
        Speed = speed;
        Damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector2.up);
    }
}
