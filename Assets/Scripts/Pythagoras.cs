using System;
using UnityEngine;

public class Pythagoras : MonoBehaviour {

	public float distance(Vector2 a, Vector2 b)
    {
        return (float)Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }
}
