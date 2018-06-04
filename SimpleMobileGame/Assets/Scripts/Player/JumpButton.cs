using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public static event Action shouldJump;

    public void TellPlayerToJump()
    {
        if(shouldJump != null)
        {
            shouldJump.Invoke();
        }
    }
}
