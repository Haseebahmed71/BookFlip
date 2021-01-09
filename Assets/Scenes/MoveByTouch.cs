using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveByTouch : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 endPos;
    public float zDistance = 30.0f;
    [HideInInspector]
    public bool isThrown;
    public bool isCompleted;
    bool ControlActivate = false;
    public GameObject[] Rack1;
    public GameObject[] Rack2;
    // public Transform targetPosition;
    int targetindex;
    int targetRack;
    int i = 0;
    void Start()
    {
        isThrown = false;

    }

    void Update()
    {


        if (!ControlActivate) return;



        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (isThrown)
        {
            if (i < 72)
            {
                i++;
                transform.Rotate(0f, 0f, 10);
            }
            else
            {
                isThrown = false;
            }
        }
        if (isCompleted) return;

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Input.mousePosition * -1.0f;
            mousePos.z = zDistance;

            startPos = Camera.main.ScreenToWorldPoint(mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {

            Vector3 mousePos = Input.mousePosition * -1.0f;
            mousePos.z = zDistance;


            endPos = Camera.main.ScreenToWorldPoint(mousePos);
            endPos.z = Camera.main.nearClipPlane;

            Vector3 throwDir = (startPos - endPos).normalized;
            float angle = Vector2.Angle(Vector3.right, endPos - startPos);
            float angle2 = Vector2.Angle(Vector3.up, endPos - startPos);
            //Debug.LogError(angle);
            Debug.LogError(angle2);
            //Debug.LogError(angle - 30);

            if (angle2 < 162)
            {
                targetRack = 1;
            }
            else
            {
                targetRack = 0;
            }
            if (angle > 30 && angle < 120 && angle2 > 155)
            {
                targetindex = ((int)angle - 30) / 5;

                //targetindex
                //this.gameObject.GetComponent<Rigidbody>().AddForce(throwDir * (startPos - endPos).sqrMagnitude);
                //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                isThrown = true;
                if (targetRack == 0)
                {
                    LeanTween.move(gameObject, Rack1[targetindex].transform.position, 1f).setOnComplete(stopRotation);
                }
                if (targetRack == 1)
                {
                    LeanTween.move(gameObject, Rack2[targetindex].transform.position, 1f).setOnComplete(stopRotation);
                }
                isCompleted = true;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(throwDir * (startPos - endPos).sqrMagnitude);
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                isThrown = true;
            }
        }
    }

    private void stopRotation()
    {
        // isThrown = false;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnMouseDown()
    {
        ControlActivate = true;
    }


}
