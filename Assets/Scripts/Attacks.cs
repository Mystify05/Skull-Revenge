using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject shadowBall;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void ShadowBall()
    {
        GameObject sb = Instantiate(shadowBall, player.transform.position, Quaternion.identity);
        sb.transform.Rotate(0, 0, Mathf.Atan2(
            player.GetComponent<PlayerMovement>().Joystick.Direction.y, 
            player.GetComponent<PlayerMovement>().Joystick.Direction.x) * Mathf.Rad2Deg - 90);
    }
}
