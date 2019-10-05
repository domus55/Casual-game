using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject RainPrefab;
    [Range(0.3f, 60)]
    public float spawnDelta = 0.3f;
    public float playerOffset = 5;
    public float minZ = 0.25f;
    public float maxZ = 1.5f;
    public float speedFar = 5f;
    public float speedClose = 3f;
    public float alphaFar = 0.7f;
    public float alphaClose = 1f;

    Transform playerPos;
    float time = 0;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= spawnDelta / 1000.0f)
        {
            float randX = Random.Range(-20f, 20f); // random range jest overloadowany więc jak dopiszesz f, to wynik będzie jako float a nie jako int
            float randY = Random.Range(0, 5f);
            float randZ = Random.Range(minZ, maxZ); // nie ma dużo wspólnego z 'Z' ale łatwiej skojarzyć I guess (w sumie większe jest bliżej gracza XD)
            float force = Utils.Map(randZ, minZ, maxZ, speedClose, speedFar) * 100;
            float size = randZ * 7.5f;
            float alpha = Utils.Map(randZ, minZ, maxZ, alphaClose, alphaFar);

            GameObject rain = Instantiate(RainPrefab, new Vector3(playerPos.position.x + randX, playerPos.position.y + playerOffset + randY, 1), Quaternion.identity);
            rain.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force));
            rain.GetComponent<Transform>().localScale = new Vector2(0.35f, size);
            rain.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

            time = 0;
        }
    }
}
