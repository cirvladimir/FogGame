using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    enum SwingState
    {
        PREPING,
        SWINGING,
        BLOCKED
    }

    SwingState swingState = SwingState.SWINGING;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (swingState)
        {
            case SwingState.SWINGING:
                transform.Rotate(new Vector3(-90f * Time.deltaTime, 0f, 0f));
                break;
            case SwingState.BLOCKED:
                transform.Rotate(new Vector3(50f * Time.deltaTime, 0f, 0f));
                if (transform.localEulerAngles.x > 70f)
                {
                    swingState = SwingState.SWINGING;
                }
                break;
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision!");
    //}

    public void OnSwordBlocked()
    {
        Debug.Log("Collision!");
        swingState = SwingState.BLOCKED;
    }
}
