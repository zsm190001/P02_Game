using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        //make camera always forward for healthbar
        transform.LookAt(transform.position + cam.forward);
    }
}
