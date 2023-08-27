using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 45.0f; // Adjust this to control the rotation speed

    private float currentRotation = 0.0f;
    private bool isRotatingClockwise = true;

    // Update is called once per frame
    void Update()
    {
        // Update the rotation angle based on the rotation speed and direction
        if (isRotatingClockwise)
        {
            currentRotation += rotationSpeed * Time.deltaTime;
            if (currentRotation >= 30.0f)
            {
                currentRotation = 30.0f;
                isRotatingClockwise = false;
            }
        }
        else
        {
            currentRotation -= rotationSpeed * Time.deltaTime;
            if (currentRotation <= -30.0f)
            {
                currentRotation = -30.0f;
                isRotatingClockwise = true;
            }
        }

        // Apply the rotation to the object's z-axis
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}