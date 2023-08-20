using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    [Header("References")]
    public PlayerController controller;
    public BoxCollider2D col;
    public RectTransform rectTransform;
    public Image image;

    [Header("Local Attributes")]
    public float targetSpawnPos;

    public Vector2 colDefaultSize;
    public Vector2 rectDefaultSize;

    public float sizeDecreaseIncrament = 5f;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();
        colDefaultSize = new Vector2 (col.size.x,col.size.y);
        rectDefaultSize = new Vector2 (rectTransform.sizeDelta.x,rectTransform.sizeDelta.y);

        image = GetComponent<Image>();
        RespawnTarget();

    }

    public void RespawnTarget()
    {
		targetSpawnPos = Random.Range(-50, 50);
		Debug.Log("Spawning at " + targetSpawnPos);
		transform.localPosition = new Vector2(targetSpawnPos, transform.localPosition.y);
        if (controller.combo > 0)
        {
            if (rectTransform.sizeDelta.x > 10)
            {
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x - sizeDecreaseIncrament, rectTransform.sizeDelta.y);
				col.size = new Vector2(col.size.x - sizeDecreaseIncrament, col.size.y);
			}
			controller.moveSpeedSet += controller.moveSpeedIncrease;

		}
        else 
        {
            rectTransform.sizeDelta = colDefaultSize;
            col.size = colDefaultSize;
            controller.moveSpeedSet = controller.moveSpeedStart;
		}
	}
}
