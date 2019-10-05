using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHp : MonoBehaviour
{
    public GameObject barPrefab;
    [Range(0.1f, 10)]
    public float size;
    public float offset;
    [HideInInspector]
    public GameObject bar;

    private void Start()
    {
        bar = Instantiate(barPrefab);
        bar.GetComponent<SetHp>().size = size;
        bar.GetComponent<SetHp>().offset = offset;
    }

    void Update()
    {
        bar.GetComponent<SetHp>().Set(transform.position, gameObject.GetComponent<Hp>().hp / gameObject.GetComponent<Hp>().MaxHp);
    }

    private void OnDestroy()
    {
        Destroy(bar);
    }
}
