using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab;

    float startTime;
    float nextLaunch;

    void MakeSword()
    {
        float randAngle = Random.Range(-Mathf.PI, Mathf.PI);
        //float randAngle = Mathf.PI / 6;
        float rad = 2f;

        float z = rad * Mathf.Cos(randAngle);
        float x = rad * Mathf.Sin(randAngle);

        var sword = Instantiate<GameObject>(prefab, transform);
        sword.transform.localPosition = new Vector3(x, 1.5f, z);
        sword.transform.Rotate(0, 0, randAngle * Mathf.Rad2Deg, Space.Self);

        // Difficulty.
        var swordScript = sword.GetComponent<MagicSwordScript>();
        swordScript.Accel = Mathf.Min(180f + (Time.time - startTime) * 6f, 540f);
        swordScript.PauseTime = Mathf.Max(3f - (Time.time - startTime) / 30f, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        nextLaunch = startTime + 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunch)
        {
            MakeSword();
            float meanDeltaTime = Mathf.Max(2f, 8f - (Time.time - startTime) / 20f);
            nextLaunch = Time.time + Random.Range(meanDeltaTime * 0.8f, meanDeltaTime * 1.15f);
        }
    }
}
