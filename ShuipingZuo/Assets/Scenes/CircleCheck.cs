using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCheck : MonoBehaviour
{
   
    private bool[] clickCount = new bool[4];
    Vector2 m_screenPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4;  i++)
        {
            clickCount[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            if(Input.touches[0].phase.ToString() == TouchPhase.Moved.ToString())
            {
                
            }
        }
    }
}
