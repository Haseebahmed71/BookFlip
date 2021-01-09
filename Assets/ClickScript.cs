using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
