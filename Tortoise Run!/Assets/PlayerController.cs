using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HitScript hit;
    public BarScript barScript;
    public float resetTime = 3;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit != null)
            {
                if (hit.OnTarget)
                {
                    Debug.Log("+1");
                    
                    StartCoroutine(ResetSpeed());
                } 
                else if (!hit.OnTarget) 
                {
                    Debug.Log("reset");
                }
            }
        }
    }
    IEnumerator ResetSpeed()
    {
		barScript.moveSpeedSet = 0;
		yield return new WaitForSecondsRealtime(resetTime);
		barScript.moveSpeedSet = 2;
	}
}
