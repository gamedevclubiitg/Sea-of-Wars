using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public GameObject controls;
    private float rotationSpeed = 10f;
    private float rotZ = 90f;
    [SerializeField]
    private float speed = 0.5f;
    private float currentSpeed = 0f;
    // private float a = 1f;
    float nfmod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }
    private void Update()
    {
        float angleChange = Vector3.SignedAngle(transform.right, controls.GetComponent<DragKnob>().clampedDistance, new Vector3(0, 0, 1));
        if (Mathf.Abs(angleChange) != 0)
        {
            // Debug.Log(angleChange);
            if (angleChange >= 0)
            {
                rotZ += Time.deltaTime * rotationSpeed;
            }
            else
            {
                rotZ -= Time.deltaTime * rotationSpeed;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        // controls.transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
        float velocityMagnitude = controls.GetComponent<DragKnob>().velocityMagnitude;
        if (velocityMagnitude < 0.05)
        {
            velocityMagnitude = 0;
        }
        currentSpeed = speed * velocityMagnitude;
        float t = Time.deltaTime;
        float translation = currentSpeed * t;

        var newXPos = transform.position.x + translation * transform.right.x;
        var newYPos = transform.position.y + translation * transform.right.y;

        transform.position = new Vector2(newXPos, newYPos);
    }
}
//     // Start is called before the first frame update
//     private float Xmin;
//     private float Xmax;
//     private float Ymin;
//     private float Ymax;
//     private void Start()
//     {
//         FixPlayerMovement();
//     }
//     private void FixPlayerMovement()
//     {
//         Camera cam = Camera.main;
//         Xmin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
//         Xmax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
//         Ymin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
//         Ymax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
//     }


//     // Update is called once per frame
//     void Update()
//     {

//         var newYPos = Mathf.Clamp(transform.position.y + translation * transform.right.y, Ymin + 0.5f, Ymax - 0.5f);
//     }