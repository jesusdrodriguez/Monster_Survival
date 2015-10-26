using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

    EnemyHealth enemyHealth;
    public RectTransform canvasRectT;
    public RectTransform healthBar;
    public Transform objectToFollow;

    void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, objectToFollow.position);
        healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;
    }

}
