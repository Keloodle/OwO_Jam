using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public HitScript hit;
    public BarScript barScript;
    public TargetScript targetScript;

    [Header("Turtles")]
    public GameObject turtle1;
    public float turtle1MoveSpeed = 0.001f;
    public float turtle1MoveSpeedDefault = 0.001f;
    public float turtle1MoveSpeedIncrease = 0.01f;

    [Header("Player Stats")]
    public float combo = 0;

    [Header("Target")]
	public float moveSpeedSet = 1f;
    public float moveSpeedStart = 1f;
    public float moveSpeedIncrease = 0.5f;
	public float resetTime = 3f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit != null)
            {
                if (hit.OnTarget)
                {
                    Debug.Log("+1");
                    combo++;
                    StartCoroutine(PauseTime());
                    //turtle1.transform.position = new Vector3(turtle1.transform.position.x, turtle1.transform.position.y, turtle1.transform.position.z + (turtle1MoveSpeed*=combo));
                    turtle1MoveSpeed += turtle1MoveSpeedIncrease;

				} 
                else if (!hit.OnTarget) 
                {
                    combo = 0;
                    Debug.Log("reset");
					StartCoroutine(PauseTime());
					turtle1MoveSpeed = turtle1MoveSpeedDefault;
				}
            }
        }
    }
    IEnumerator PauseTime()
    {
        Time.timeScale = 0;
        DisableSlider();
		yield return new WaitForSecondsRealtime(resetTime);
		targetScript.RespawnTarget();
        EnableSlider();
		Time.timeScale = 1;
	}

    void DisableSlider()
    {
        targetScript.image.enabled = false;
        hit.image.enabled = false;
        barScript.slider.transform.GetChild(1).GetComponent<Image>().enabled = false;
    }

    void EnableSlider()
    {
		targetScript.image.enabled = true;
		hit.image.enabled = true;
		barScript.slider.transform.GetChild(1).GetComponent<Image>().enabled = true;
	}
}
