using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateScript : MonoBehaviour
{
    //public GameObject SomethingElse;

    //public float speed;

    InputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        var inputDevices = new List<InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, inputDevices);

        if (inputDevices.Count == 0)
        {
            Debug.LogError("Right hand controller not found.");
        }

        controller = inputDevices[0];
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 0.4f, 0f));
        //transform.Translate(0, 0, speed * Time.deltaTime);
        //SomethingElse.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
