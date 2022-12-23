using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerMultiPlayer : MonoBehaviour
{
    public GameObject PSControls;
    public GameObject[] PlayerShips; 
    public GameObject canvas;
    private List<GameObject> _PSControls = new List<GameObject>();
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float currentSpeed = 0f;
    PhotonView PV;
    void Start()
    {
        FindCanvas();
        PV =GetComponent<PhotonView>();

        if(PV.IsMine)
        {
            AttachControlls();
        }
    }
    void Update()
    {
        if(PV.IsMine)
        {
            for (int i = 0; i < PlayerShips.Length; i++)
            {
                Movement(_PSControls[i], PlayerShips[i]);
            }
            ActivateShip();
        }

    }

    private void ActivateShip()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShootingAttach(1);
            Debug.Log("hello");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootingAttach(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShootingAttach(3);
        }
    }

    private void ShootingAttach(int num)
    {
        for (int i = 0; i <PlayerShips.Length; i++)
        {
            GameObject gunHolder = PlayerShips[i].transform.GetChild(1).gameObject;
            ShootingMultiPlayer childScript = gunHolder.GetComponentInChildren<ShootingMultiPlayer>();

            if (i + 1 == num)
            {
                childScript.enabled = true;
            }
            else
            {
                childScript.enabled = false;
            }
        }
    }

    private void Movement(GameObject controls, GameObject playerShip)
    {
        float rotZ = 0;
        if (controls.GetComponentInChildren<DragKnob>()!=null&&playerShip!=null)
        {
            float angleChange = Vector3.SignedAngle(playerShip.transform.right, controls.GetComponentInChildren<DragKnob>().clampedDistance, new Vector3(0, 0, 1));

            if (Mathf.Abs(angleChange) != 0)
            {
              
                if (angleChange >= 0)
                {
                    rotZ += Time.deltaTime * rotationSpeed;
                }
                else
                {
                    rotZ -= Time.deltaTime * rotationSpeed;
                }
            }
            playerShip.transform.Rotate(0,0,rotZ);
            float velocityMagnitude = controls.GetComponentInChildren<DragKnob>().velocityMagnitude;
            if (velocityMagnitude < 0.05)
            {
                velocityMagnitude = 0;
            }
            currentSpeed = speed * velocityMagnitude;
            float t = Time.deltaTime;
            float translation = currentSpeed * t;

            var newXPos = playerShip.transform.position.x + translation * playerShip.transform.right.x;
            var newYPos = playerShip.transform.position.y + translation * playerShip.transform.right.y;

            playerShip.transform.position = new Vector2(newXPos, newYPos);
        }
        else
        {
            Debug.Log("hleopop");
        }
    }

    void FindCanvas()
    {
        GameObject tempObject = GameObject.Find("Canvas");
        if(tempObject != null)
        {
            canvas = tempObject;
        }
        else
        {
            Debug.Log("hello");
        }
    }

    void AttachControlls()
    {
       //Populating list
        Color red = new Color(1f, 0f, 0f, 1f);
        Color blue = new Color(74f / 255f, 0f, 240f / 255f, 1f);
        Color yellow = new Color(242f / 255f, 223f / 255f, 3f / 255f, 1f);
        List<Color> colors = new List<Color>() {red,blue,yellow};
        //Populating positions
        Vector3[] positions = { new Vector3(9.5f, 3.5f, 0f), new Vector3(9.5f, 0f, 0f), new Vector3(9.5f, -3.5f, 0f) };
        for (int i = 0; i < PlayerShips.Length; i++)
        {
            GameObject _tempControls = Instantiate(PSControls, positions[i], Quaternion.identity);
            _PSControls.Add(_tempControls);
            _PSControls[i].name = "PSControls " + i;
            SpriteRenderer _tempSprite = _PSControls[i].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
            _tempSprite.color = colors[i];
        }
    }

}
