using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider slider;

    public float moveSpeed;
    public float moveSpeedSet;
    public bool toggle = false;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value += moveSpeed * Time.deltaTime;
        if (slider.value >= 1)
        {
            toggle = true;
        }
        if (slider.value <= 0)
        {
            toggle = false;
        }

        if (!toggle)
        {
            moveSpeed = moveSpeedSet;
        }
        else if (toggle)
        {
            moveSpeed = -moveSpeedSet;
        }
    }
}
