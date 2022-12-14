using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
    public Slider slider;
    public GameObject controls;
    [SerializeField]
    private float rotationSpeed = 10f;
    private float rotZ = 90;
    [SerializeField]
    private float speed = 5f;
    private float currentSpeed = 0f;

    private void Update()
    {
        rotZ -= Time.deltaTime * rotationSpeed * slider.value;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        controls.transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
        currentSpeed = speed;
        float translation = currentSpeed;
        float t = Time.deltaTime;
        translation *= t;

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