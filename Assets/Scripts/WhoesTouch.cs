using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoesTouch
{
    private static int touches;
    private static int rightTouch;
    private static int leftTouch;

    public int RightTouch { get { return rightTouch; } }
    public int LeftTouch { get { return leftTouch; } }

    public void Update()
    {
        touches = Input.touchCount;
        rightTouch = -1;
        leftTouch = -1;
        for(int i = 0; i < touches; i++)
        {
            if(Input.GetTouch(i).position.x > Screen.width / 2)
            {
                rightTouch = i;
            }
            else
            {
                leftTouch = i;
            }
        }
    }
}
