using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float damage = 10;
    private Vector2 shotDirection;
    private PlayerMovement playerMovementScript;
    private Direction direction;

    public float Speed { get { return speed; } set { speed = value; } }
    public float Damage { get { return damage; } set { damage= value; } }
    // Start is called before the first frame update
    void Start()
    {
        Speed = speed;
        Damage = damage;
        direction = GetComponent<Direction>();
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        shotDirection = playerMovementScript.OldDirection.normalized;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        direction.Directions["Shot"] = shotDirection * Speed;
        transform.Translate(direction.Richtung * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
