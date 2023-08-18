using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    public float targetSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        GetSpawnPoint();
        transform.localPosition = new Vector2(targetSpawnPos,transform.localPosition.y);
    }

    public void GetSpawnPoint()
    {
		targetSpawnPos = Random.Range(-50, 50);
		Debug.Log("Spawning at " + targetSpawnPos);
	}
}
