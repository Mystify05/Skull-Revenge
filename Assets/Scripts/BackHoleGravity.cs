using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHoleGravity : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    private float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == null)
            {
                objects.RemoveAt(i);
                continue;
            }

            Vector2 r = gameObject.transform.position - objects[i].transform.position;
            if (r.magnitude > 0.2f)
                objects[i].transform.Translate((1 / Mathf.Pow(r.magnitude, 2) + 6) * speed * Time.deltaTime * r.normalized);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        objects.Add(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        objects.Remove(collision.gameObject);
    }
}
