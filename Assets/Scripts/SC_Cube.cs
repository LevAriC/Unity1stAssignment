using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cube : MonoBehaviour
{
    public float speed;
    public Material red, blue;
    private bool isGoingUp = true;
    private bool isMoving = true;
    private bool isRed = false;
    private Renderer cubeColor;

    private void Awake()
    {
        cubeColor = GetComponent<MeshRenderer>();
        ChangeCubeColor();
    }

    void OnMouseDown()
    {
        ChangeCubeState();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (isGoingUp)
            {
                if (transform.position.y >= 10f)
                    isGoingUp = false;
                else
                    transform.Translate(0, speed, 0);
            }
            else
            {
                if (transform.position.y <= -10f)
                    isGoingUp = true;
                else
                    transform.Translate(0, -speed, 0);
            }
        }
    }

    public void ChangeCubeState()
    {
        if(isMoving)
            isMoving = false;
        else
            isMoving = true;
    }

    public void ChangeCubeColor()
    {
        if (isRed)
            cubeColor.material = blue;
        else
            cubeColor.material = red;
        isRed = !isRed;
    }
}