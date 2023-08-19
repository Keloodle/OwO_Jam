using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public HitScript hit;
    public BarScript barScript;
    public TargetScript targetScript;

    [Header("Player Stats")]
    public int combo = 0;

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
                } 
                else if (!hit.OnTarget) 
                {
                    combo = 0;
                    Debug.Log("reset");
					StartCoroutine(PauseTime());
				}
            }
        }
    }
    IEnumerator PauseTime()
    {
        Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(resetTime);
		targetScript.RespawnTarget();
        Time.timeScale = 1;
	}
}
