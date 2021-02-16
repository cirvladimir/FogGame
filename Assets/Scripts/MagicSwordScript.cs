using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwordScript : MonoBehaviour
{
    public AudioClip[] KyaSound;
    public AudioClip ShingSound;
    float rotationLeft = 140f;
    float timeStart;
    float pauseTime = 3f;
    float accel = 180f;
    float curSpeed = 0f;
    float maxSpeed = 270f;
    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        AudioSource.PlayClipAtPoint(KyaSound[Random.Range(0, KyaSound.Length)], transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone)
        {
            return;
        }
        if (Time.time > timeStart + pauseTime)
        {
            curSpeed += Time.deltaTime * accel;
            curSpeed = Mathf.Min(curSpeed, maxSpeed);
            float rotation = curSpeed * Time.deltaTime;
            transform.Rotate(0f, rotation, 0f, Space.Self);
            rotationLeft -= rotation;
            if (rotationLeft < 0f)
            {
                isDone = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isDone = true;
        AudioSource.PlayClipAtPoint(ShingSound, transform.position);
        //Debug.Log("Trigger enterd.");
    }
}
