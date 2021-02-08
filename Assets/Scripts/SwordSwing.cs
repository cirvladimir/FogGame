using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    enum SwingState
    {
        PREPING,
        SWINGING,
        UPSWING
    }

    SwingState swingState;
    float prepStart;
    float startRotation = 0f;
    Rigidbody rb;
    HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        prepStart = Time.time;
        swingState = SwingState.PREPING;
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (swingState)
        {
            case SwingState.PREPING:
                if (Time.time - prepStart > 3f)
                {
                    swingState = SwingState.SWINGING;
                    hinge.useSpring = true;
                    hinge.useMotor = false;
                    rb.isKinematic = false;
                }
                break;
            case SwingState.SWINGING:
                if (hinge.angle < -140)
                {
                    Debug.Log("Upswing.");
                    swingState = SwingState.UPSWING;
                    hinge.useSpring = false;
                    hinge.useMotor = true;
                }
                break;
            case SwingState.UPSWING:
                if (hinge.angle > -2f)
                {
                    swingState = SwingState.PREPING;
                    rb.isKinematic = true;
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
        //swingState = SwingState.BLOCKED;
    }
}
