using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHp : MonoBehaviour {

    public GameObject barPrefab;
    public GameObject hpPrefab;
    public float size;
    public float offset;

    Vector2 startSize;
    GameObject bar;
    GameObject hp;
    float startWidth;
    float startHeight;

    private void Start()
    {
        bar = Instantiate(barPrefab);
        hp = Instantiate(hpPrefab);

        bar.transform.SetParent(gameObject.transform);
        hp.transform.SetParent(gameObject.transform);

        bar.transform.localScale = new Vector3(bar.transform.localScale.x * size, bar.transform.localScale.y * size, 1);
        hp.transform.localScale = new Vector3(hp.transform.localScale.x * size, hp.transform.localScale.y * size, 1);

        startWidth = hp.transform.localScale.x;
        startHeight = hp.transform.localScale.y;
    }

    public void Set(Vector2 pos, float hpp)
    {
        if (bar != null)
        {
            bar.transform.position = new Vector2(pos.x, pos.y + offset);
            hp.transform.position = new Vector2(pos.x, pos.y + offset);

            if (hpp < 0) hpp = 0;
            hp.transform.localScale = new Vector2(startWidth * hpp, startHeight);
        }
    }

    private void OnDestroy()
    {
        Destroy(bar);
        Destroy(hp);
    }

}
