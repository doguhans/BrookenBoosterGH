using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualizeMaterials : MonoBehaviour
{
    public Material targetMaterial; // The material to assign to children
    
    private void Start()
    {
        // Iterate through all child objects
        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Assign the target material to the child's renderer
                renderer.material = targetMaterial;
            }
        }
    }
}