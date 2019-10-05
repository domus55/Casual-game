using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSetActive : MonoBehaviour {
	
	public void Active(bool active)
    {
        if(active)
        {
            GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else
        {
            Color color = new Color(1, 1, 1);
            color.a = 0.3f;
            GetComponent<Image>().color = color;
        }
    }
}
