using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float InputHorizontal{
        get { return Input.GetAxis("Horizontal"); }
    }
    public float InputVertical
    {
        get { return Input.GetAxis("Vertical"); }
    }
    public bool JUMP {
        get { return Input.GetKeyDown(KeyCode.Space); }
    }

}
