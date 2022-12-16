using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMakerMultiPlayer : MonoBehaviour
{
    public GameObject PSControls;

    public int PSControlsVersion;
    public GameObject PlayerShip1;
    public GameObject PlayerShip2;
    public GameObject PlayerShip3;
    public GameObject canvas;
    PhotonView PV;

    void Start()
    {

        PV=GetComponent<PhotonView>();
        if(PV.IsMine)
        {
            FindCanvas();
            AttachControlls();
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

        Debug.Log("Hellorrrrrrr");
        GameObject PS1Controls = Instantiate(PSControls, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject PS2Controls = Instantiate(PSControls, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject PS3Controls = Instantiate(PSControls, new Vector3(0, 0, 0), Quaternion.identity);


        PS1Controls.name = "PS1Controls1";
        PS2Controls.name = "PS2Controls1";
        PS3Controls.name = "PS3Controls1";

        Color red = new Color(1f, 0f, 0f, 1f);
        // PS1Controls.GetComponentInChildren<Slider>().GetComponentInChildren<Image>().color = red;
        Image[] colors1 = PS1Controls.GetComponentsInChildren<Image>();
        for (int i = 0; i < colors1.Length; i++)
        {
            colors1[i].color = red;
        }

        Color blue = new Color(74f / 255f, 0f, 240f / 255f, 1f);
        // PS1Controls.GetComponentInChildren<Slider>().GetComponentInChildren<Image>().color = red;
        Image[] colors2 = PS2Controls.GetComponentsInChildren<Image>();
        for (int i = 0; i < colors2.Length; i++)
        {
            colors2[i].color = blue;
        }

        Color yellow = new Color(242f / 255f, 223f / 255f, 3f / 255f, 1f);
        // PS3Controls.GetComponentInChildren<Slider>().GetComponentInChildren<Image>().color = yellow;
        Image[] colors3 = PS3Controls.GetComponentsInChildren<Image>();
        for (int i = 0; i < colors3.Length; i++)
        {
            colors3[i].color = yellow;
        }


        Debug.Log("Helloss");
        switch (PSControlsVersion)
        {
            case 1:
                Debug.Log("Hello");
                PS1Controls.transform.SetParent(canvas.transform);
                PS2Controls.transform.SetParent(canvas.transform);
                PS3Controls.transform.SetParent(canvas.transform);
                PlayerController1 Player1Controller1 = PlayerShip1.GetComponent<PlayerController1>();
                Player1Controller1.controls = PS1Controls;
                PlayerController1 Player2Controller1 = PlayerShip2.GetComponent<PlayerController1>();
                Player2Controller1.controls = PS2Controls;
                PlayerController1 Player3Controller1 = PlayerShip3.GetComponent<PlayerController1>();
                Player3Controller1.controls = PS3Controls;
                RectTransform rt1 = PS1Controls.GetComponent<RectTransform>();
                RectTransform rt2 = PS2Controls.GetComponent<RectTransform>();
                RectTransform rt3 = PS3Controls.GetComponent<RectTransform>();
                // rt.anchoredPosition.Set(0, 1);
                // rt.anchorMin.Set(0, 1);
                // rt.anchorMax.Set(0, 1);
                // rt.pivot.Set(0, 0);
                rt1.transform.localPosition = new Vector3(800, 350, 0);
                rt2.transform.localPosition = new Vector3(800, 0, 0);
                rt3.transform.localPosition = new Vector3(800, -350, 0);
                Player1Controller1.slider = PS1Controls.GetComponentInChildren<Slider>();
                Player2Controller1.slider = PS2Controls.GetComponentInChildren<Slider>();
                Player3Controller1.slider = PS3Controls.GetComponentInChildren<Slider>();
                break;
            case 2:
                SpriteRenderer colors1Sprites = PS1Controls.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                colors1Sprites.color = red;
                SpriteRenderer colors2Sprites = PS2Controls.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                colors2Sprites.color = blue;
                SpriteRenderer colors3Sprites = PS3Controls.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                colors3Sprites.color = yellow;
                PS1Controls.transform.position = new Vector3(9.5f, 3.5f, 0f);
                PS2Controls.transform.position = new Vector3(9.5f, 0f, 0f);
                PS3Controls.transform.position = new Vector3(9.5f, -3.5f, 0f);
                PlayerController2 Player1Controller2 = PlayerShip1.GetComponent<PlayerController2>();
                Player1Controller2.controls = PS1Controls.transform.GetChild(0).gameObject;
                PlayerController2 Player2Controller2 = PlayerShip2.GetComponent<PlayerController2>();
                Player2Controller2.controls = PS2Controls.transform.GetChild(0).gameObject;
                PlayerController2 Player3Controller2 = PlayerShip3.GetComponent<PlayerController2>();
                Player3Controller2.controls = PS3Controls.transform.GetChild(0).gameObject;
                break;
            default:
                Debug.Log("Please set PSControls version properly :)");
                break;
        }
    }
}
