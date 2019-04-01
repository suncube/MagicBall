using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AlphaMeshrenderController : MonoBehaviour
{
    [Range(0, 1)]
    public float Alpha = 1;
    public MeshRenderer[] MeshObjects;
    private MeshRenderer[] ChildColors;
    private Color[] OriginColors;

    // Use this for initialization
    void Start()
    {
        if (MeshObjects.Length == 0)
        {
            ChildColors = gameObject.GetComponentsInChildren<MeshRenderer>();
            OriginColors =
                ChildColors.Select(meshRenderer => meshRenderer.material.color)
                    .Select(color => new Color(color.r, color.g, color.b, color.a))
                    .ToArray();
        }
        else
        {
            OriginColors =
               MeshObjects.Select(meshRenderer => meshRenderer.material.color)
                    .Select(color => new Color(color.r, color.g, color.b, color.a))
                    .ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MeshObjects.Length == 0)
        {
            for (int index = 0; index < ChildColors.Length; index++)
            {
                var childColor = ChildColors[index];
                childColor.material.color = new Color(childColor.material.color.r, childColor.material.color.g,
                    childColor.material.color.b,
                    Mathf.Clamp(Alpha, 0, OriginColors[index].a));
            }
        }
        else
        {
            for (int index = 0; index < MeshObjects.Length; index++)
            {
                var childColor = MeshObjects[index];
                childColor.material.color = new Color(childColor.material.color.r, childColor.material.color.g,
                    childColor.material.color.b,
                    Mathf.Clamp(Alpha, 0, OriginColors[index].a));
            } 
        }
    }
}