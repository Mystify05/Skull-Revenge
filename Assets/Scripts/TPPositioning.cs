using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TPPositioning : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject handle;
    private GameObject player;
    private JoyStickTest joystick;
    // Start is called before the first frame update
    void Start()
    {
        handle = GameObject.FindGameObjectWithTag("Handle");
        joystick = handle.GetComponent<JoyStickTest>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Es soll nur eine bestimmte Reichweite haben
        transform.Translate(joystick.Direction * Time.deltaTime * speed);
    }

    public void DestroyObjekt()
    {
        player.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
}
