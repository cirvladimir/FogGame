using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwordScript : MonoBehaviour
{
    public AudioClip[] KyaSound;
    public AudioClip ShingSound;
    float rotationLeft = 140f;
    float timeStart;
    public float PauseTime = 3f;
    public float Accel = 180f;
    float curSpeed = 0f;
    float maxSpeed = 270f;
    public bool IsDone = false;
    public float DoneTime;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        AudioSource.PlayClipAtPoint(KyaSound[Random.Range(0, KyaSound.Length)], transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDone)
        {
            if (Time.time > DoneTime + 2f)
            {
                Destroy(gameObject);
            }
            return;
        }
        if (Time.time > timeStart + PauseTime)
        {
            curSpeed += Time.deltaTime * Accel;
            curSpeed = Mathf.Min(curSpeed, maxSpeed);
            float rotation = curSpeed * Time.deltaTime;
            transform.Rotate(0f, rotation, 0f, Space.Self);
            rotationLeft -= rotation;
            if (rotationLeft < 0f)
            {
                IsDone = true;
                DoneTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsDone)
        { 
            IsDone = true;
            DoneTime = Time.time;
            AudioSource.PlayClipAtPoint(ShingSound, transform.position);
            //Debug.Log("Trigger enterd.");
        }
    }
}
