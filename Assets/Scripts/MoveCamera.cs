using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float smoothness = 1;
    public float offset = 0;
    public float up = 100;
    public float down = - 100;
    public float left = -100;
    public float right = 100;

    public float offsetX = 2;

    GameObject player;
    Vector3 pos;
    float startSmoothness;
    float force;
    float shakeTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startSmoothness = smoothness;

        // set camera on player
        transform.position = getDesiredPos();

        // snap to borders
        if (transform.position.x >= right) transform.position = new Vector2(right, transform.position.y);
        if (transform.position.x <= left) transform.position = new Vector2(left, transform.position.y);
        if (transform.position.y >= up) transform.position = new Vector2(transform.position.x, up);
        if (transform.position.y <= down) transform.position = new Vector2(transform.position.x, down);
    }

    private void Update()
    {
        if(Time.time <= shakeTime)
        {
            float forceX = Random.Range(-force, force);
            float forceY = Random.Range(-force, force);

            transform.position = new Vector3(transform.position.x + forceX * Time.deltaTime, transform.position.y + forceY * Time.deltaTime, transform.position.z);
        }
    }

    Vector3 getDesiredPos()
    {
        int dir = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;
        return new Vector3(player.transform.position.x + offsetX * dir, player.transform.position.y + offset, player.transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = getDesiredPos();
        Vector2 distance = desiredPos - transform.position;

        float edgeDistance = 0;
        if (right - transform.position.x < 3) edgeDistance = right - transform.position.x;
        if (transform.position.x - left < 3) edgeDistance = transform.position.x - left;

        if (edgeDistance != 0 && edgeDistance > 0)
        {
            smoothness = startSmoothness * 5 / edgeDistance;
            if (smoothness > 100) smoothness = 100;
        }
        else
        {
            if (edgeDistance < 0) smoothness = 100;
            else smoothness = startSmoothness;
        }

        if (Utils.distance(desiredPos, transform.position) < 10)
        {
            if (transform.position.x >= right && distance.x > 0) distance.x = 0;
            if(transform.position.x <= left && distance.x < 0) distance.x = 0;
            if (transform.position.y >= up && distance.y > 0) distance.y = 0;
            if(transform.position.y <= down && distance.y < 0) distance.y = 0;

            pos = new Vector3(transform.position.x + (distance.x / smoothness), transform.position.y + (distance.y / smoothness), -0.5f);
        }
        else
        {
            pos = new Vector3(desiredPos.x, desiredPos.y, -0.5f);
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    public void ShakeCamera(float forcee, float timee)
    {
        force = forcee * 1.5f;
        shakeTime = Time.time + timee;
    }
}