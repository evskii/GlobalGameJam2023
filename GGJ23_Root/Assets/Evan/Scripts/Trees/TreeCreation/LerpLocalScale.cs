using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLocalScale : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 finalScale;
    private Vector3 targetScale;
    public float lerpSpeed;

    public bool lerping;

    private void Start() {
        LerpToFinal();
    }

    private void Update() {
        if (lerping) {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerpSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.localScale, targetScale) <= 0.1f) {
                transform.localScale = targetScale;
                lerping = false;
            }
        }
    }

    [ContextMenu("LerpToEnd")]
    public void LerpToFinal() {
        transform.localScale = startScale;
        targetScale = finalScale;
        lerping = true;
    }

    [ContextMenu("LerpToStart")]
    public void LerpToStart() {
        transform.localScale = finalScale;
        targetScale = startScale;
        lerping = true;
    }
}
