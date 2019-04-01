using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AlphaController : MonoBehaviour
{
    [Range(0, 1)]
    public float Alpha = 1;
    private Text[] ChildColors;
	// Use this for initialization
	void Start ()
	{
        ChildColors = gameObject.GetComponentsInChildren<Text>();
	}

    // Update is called once per frame
	void Update () {
        foreach (var childColor in ChildColors)
        {
            childColor.color = new Color(childColor.color.r, childColor.color.g, childColor.color.b, Alpha);
        }
	}
}