using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePatternGenerator : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public int numRows = 5;
    public int numColumns = 5;
    public float spacing = 2.0f;

    void Start()
    {
        GeneratePattern();
        RotatePattern();
    }

    void GeneratePattern()
    {
        for (int col = 0; col < numRows; col++)
        {
            for (int row = 0; row < numColumns; row++)
            {
                Vector3 spawnPosition = new Vector3(col * spacing, 0, row * spacing);
                GameObject spawnedObject = Instantiate(objectToDuplicate, spawnPosition, Quaternion.identity);
                spawnedObject.transform.SetParent(transform); // Set the new object as a child of the generator object
            }
        }
    }

 void RotatePattern()
    {
        transform.Rotate(Vector3.right, -90.0f); // Rotate the entire pattern -90 degrees around the x-axis
    }
}
