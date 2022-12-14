using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragKnob : MonoBehaviour
{
    public float velocityMagnitude = 0f;
    public float velocityAngle = 0f;
    public Vector3 clampedDistance;
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


    }

    void OnMouseDrag()
    {
        if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

            Vector3 parentPosition = transform.parent.position;

            Vector3 distance = curPosition - parentPosition;

            clampedDistance = Vector3.ClampMagnitude(distance, 1f);
            velocityMagnitude = clampedDistance.magnitude;
            velocityAngle = Vector3.Angle(clampedDistance, new Vector3(1f, 0f, 0f));
            transform.position = clampedDistance + parentPosition;
        }
        else
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

            Vector3 parentPosition = transform.parent.position;

            Vector3 distance = curPosition - parentPosition;

            Vector3 accelerationRay = transform.position - parentPosition;

            if (Mathf.Max(Vector3.Dot(accelerationRay, distance), 0) != 0)
            {

                accelerationRay = accelerationRay * Mathf.Max(Vector3.Dot(accelerationRay, distance), 0) / (accelerationRay.magnitude * accelerationRay.magnitude);

                clampedDistance = Vector3.ClampMagnitude(accelerationRay, 1f);

                velocityMagnitude = clampedDistance.magnitude;
                velocityAngle = Vector3.Angle(clampedDistance, new Vector3(1f, 0f, 0f));

                // Debug.Log(clampedDistance.magnitude);
                transform.position = clampedDistance + parentPosition;
            }
        }
    }

}