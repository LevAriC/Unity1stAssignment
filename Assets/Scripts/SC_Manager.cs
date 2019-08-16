using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Manager : MonoBehaviour
{
    public GameObject cube;
    public GameObject light;
    private GameObject curCube;
    private SC_Cube cubeScript;
    private Text timeText;
    private int lightRotation = 0;

    void Awake()
    {
        curCube = (GameObject)Instantiate(cube);
        cubeScript = curCube.gameObject.GetComponent<SC_Cube>();
        timeText = GameObject.Find("timeText").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
            getTimeSinceBeginning(true);
        if (Input.GetKeyDown(KeyCode.T))
            cubeScript.ChangeCubeState();
        if (Input.GetKeyDown(KeyCode.Q))
            cubeScript.ChangeCubeColor();

        light.transform.eulerAngles = new Vector3(-20, lightRotation, 0);
        lightRotation += 3;

        timeText.text = getTimeSinceBeginning().ToString();
    }

    int getTimeSinceBeginning(bool loop = false)
    {
        if(loop)
        {
            for(short i = 0; i < 10; i++)
                Debug.Log("Created Time " + Time.time);
        }

        return (int)Time.time;
    }
}