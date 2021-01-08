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
    bool ControlActivate = false;
    public GameObject[] Targets;
    // public Transform targetPosition;
    int targetindex;

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
            transform.Rotate(0f, 0f, 10f);
         //   return;
        }


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
            Debug.LogError(angle);
            if(angle>20&&angle<70)
            {
                targetindex = 0;
            }
            else if(angle>70 && angle<110)
            {
                targetindex = 1;
            }
            else if(angle>110 &&angle<130)
            {
                targetindex = 2;
            }
            //this.gameObject.GetComponent<Rigidbody>().AddForce(throwDir * (startPos - endPos).sqrMagnitude);
            //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            isThrown = true;
          LeanTween.move(gameObject, Targets[targetindex].transform.position, 1f).setOnComplete(stopRotation);
        }
    }

    private void stopRotation()
    {
        isThrown = false;
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
