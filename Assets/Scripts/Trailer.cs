using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale = 1;
    public float x = 1;
    public float y = 1;
    Transform tr;
    //float x = 7.25f;
    
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
        tr.position = new Vector3(x, y, -10);
    }


    private void FixedUpdate()
    {
        tr.position = new Vector3(x, y, -10);
        x += Time.fixedDeltaTime * scale;
    }
}
