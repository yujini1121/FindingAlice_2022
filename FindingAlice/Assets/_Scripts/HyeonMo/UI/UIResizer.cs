using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResizer : MonoBehaviour
{
    public float baseWidth = 1920f;
    public float baseHeight = 1080f;
    public bool keepAspectRatio = true;

    void Start()
    {
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;
        float targetAspectRatio = baseWidth / baseHeight;

        if (keepAspectRatio)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            if (currentAspectRatio > targetAspectRatio)
            {
                // The screen is wider than the reference resolution.
                // We need to stretch the canvas vertically.
                float differenceInSize = targetAspectRatio / currentAspectRatio;
                rectTransform.localScale = new Vector3(1f, differenceInSize, 1f);
            }
            else
            {
                // The screen is taller than the reference resolution.
                // We need to stretch the canvas horizontally.
                float differenceInSize = currentAspectRatio / targetAspectRatio;
                rectTransform.localScale = new Vector3(differenceInSize, 1f, 1f);
            }
        }
        else
        {
            // We are not keeping the aspect ratio, so we just stretch the canvas to fit the screen.
            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
            canvasScaler.matchWidthOrHeight = (currentAspectRatio > targetAspectRatio) ? 0f : 1f;
        }
    }
}