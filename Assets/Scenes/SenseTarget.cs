using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseTarget : MonoBehaviour
{

    public float radius = 1f;
    public bool isDrawGizmoz;
    public float speed = 1.0f;
    private GameObject book;
    private bool setBookPosition = false;
    public Transform target;
    void Start()
    {
        
    }

    void Update()
    {
        //RaycastHit hit;
        //if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, 10))
        //{
        //    if (hit.collider.gameObject.GetComponent<MoveByTouch>())
        //    {
        //        book = hit.collider.gameObject;
        //        book.GetComponent<Rigidbody>().useGravity = false;
        //        book.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //        setBookPosition = true;
        //    }
        //    Debug.Log(hit.collider.gameObject.name);
        //}

        if (setBookPosition)
        {
            float step = speed * Time.deltaTime;
            book.transform.position = Vector3.MoveTowards(book.transform.position, target.position, step);
            if (book.transform.position == target.position)
            {
                book.GetComponent<MoveByTouch>().isThrown = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        book = other.gameObject;
        book.GetComponent<Rigidbody>().useGravity = false;
        book.GetComponent<Rigidbody>().velocity = Vector3.zero;
        setBookPosition = true;
    }

    private void OnDrawGizmos()
    {
        if (isDrawGizmoz)
        {
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}
