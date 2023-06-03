using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private Dictionary<string, Vector2> directions = new Dictionary<string, Vector2>();
    private Vector2 richtung = Vector2.zero;
    private bool freeze = false;

    public Dictionary<string, Vector2> Directions
    {
        get { return directions; }
        set { Directions = value; }
    }
    public Vector2 Richtung
    { 
        get 
        {
            if (freeze)
                return Vector2.zero;
            richtung = Vector2.zero;
            foreach(KeyValuePair<string, Vector2> direction in directions)
            {
                richtung += direction.Value;
            }
            return richtung; 
        } 
    }

    public void SetZero()
    {
        freeze = true;
        richtung = Vector2.zero; 
    }
    public void UnFreeze(string key)
    {
        freeze = false;
        Directions.Remove(key);
    }
}