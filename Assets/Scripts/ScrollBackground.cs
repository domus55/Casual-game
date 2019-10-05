using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public Transform position1;
    public Transform position2;
    public Transform position3;
    public float distance;
    public float speed = 2.5f;
    public float offset = 0;

    float previewCameraPositionX = 0;
    float cameraPosY = 0;
    bool isTouching1 = false;
    bool isTouching2 = false;
    bool isTouching3 = false;
    Transform cameraa;


    void Start () {
        cameraa = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        cameraPosY = cameraa.position.y;

        position1.position = new Vector2(cameraa.position.x - distance * 0.999f, cameraPosY);
        position2.position = new Vector2(cameraa.position.x, cameraPosY);
        position3.position = new Vector2(cameraa.position.x + distance * 0.999f, cameraPosY);
    }

	void Update () {
        cameraPosY = cameraa.position.y + offset;
        isTouching1 = position1.gameObject.GetComponent<PlayerIsTouching>().isTouching;
        isTouching2 = position2.gameObject.GetComponent<PlayerIsTouching>().isTouching;
        isTouching3 = position3.gameObject.GetComponent<PlayerIsTouching>().isTouching;

        position1.position = new Vector2(position1.position.x + (cameraa.position.x - previewCameraPositionX) / speed, cameraPosY);
        position2.position = new Vector2(position2.position.x + (cameraa.position.x - previewCameraPositionX) / speed, cameraPosY);
        position3.position = new Vector2(position3.position.x + (cameraa.position.x - previewCameraPositionX) / speed, cameraPosY);

        if (!isTouching2)
        {
            if (isTouching1)
            {
                position1.position = new Vector2(position1.position.x - distance, cameraPosY);
                position2.position = new Vector2(position2.position.x - distance, cameraPosY);
                position3.position = new Vector2(position3.position.x - distance, cameraPosY);
            }
            else
            {
                if (isTouching3)
                {
                    position1.position = new Vector2(position1.position.x + distance, cameraPosY);
                    position2.position = new Vector2(position2.position.x + distance, cameraPosY);
                    position3.position = new Vector2(position3.position.x + distance, cameraPosY);
                }
                else
                {
                    
                    if ( Mathf.Abs(position2.position.x - cameraa.position.x) > distance * 1.2f)
                    {
                        position1.position = new Vector2(cameraa.position.x - distance * 0.999f, cameraPosY);
                        position2.position = new Vector2(cameraa.position.x, cameraPosY);
                        position3.position = new Vector2(cameraa.position.x + distance * 0.999f, cameraPosY);
                    }
                }
            }
        }

        position1.gameObject.GetComponent<PlayerIsTouching>().isTouching = false;
        position2.gameObject.GetComponent<PlayerIsTouching>().isTouching = false;
        position3.gameObject.GetComponent<PlayerIsTouching>().isTouching = false;

        previewCameraPositionX = cameraa.position.x;
    }
}
