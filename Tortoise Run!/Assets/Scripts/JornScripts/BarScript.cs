using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [Header("References")]
    public PlayerController controller;
    public Slider slider;

    public float moveSpeed;
    public bool toggle = false;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void FixedUpdate()
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
            moveSpeed = controller.moveSpeedSet;
        }
        else if (toggle)
        {
            moveSpeed = -controller.moveSpeedSet;
        }
    }
}
