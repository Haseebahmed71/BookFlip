using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public AutoFlip _book;
    public float FlipDelay;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayBtnHandler()
    {
        Invoke("FlipPage", FlipDelay);
    }
    void FlipPage()
    {
        _book.FlipRightPage();
    }
}
