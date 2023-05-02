using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    //method must be PUBLIC to call in inspector - like buttons
    public void Break()
    {
        //TODO add crumble particles 
        //TO DO add screenshake
        Debug.Log("Breaking the wall");
        gameObject.SetActive(false);
    }
}
