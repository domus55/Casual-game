using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShoot : MonoBehaviour {

    public GameObject shoot;
    public float deltaTime = 2;

    float time = 0;
    Vector3 angle;

    private void Start()
    {
        angle = transform.rotation.eulerAngles;

    }

    void Update () {

        time += Time.deltaTime;

        if (time >= deltaTime)
        {
            Instantiate(shoot, transform.position, Quaternion.Euler(angle));
            time = 0;
        }
    }
}
