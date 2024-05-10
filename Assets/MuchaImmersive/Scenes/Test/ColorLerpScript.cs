using System.Collections;
using UnityEngine;

public class ColorLerpScript : MonoBehaviour
{
    public GameObject[] objectsForKeyQ;
    public Color[] targetColorsForKeyQ;

    public GameObject[] objectsForKeyW;
    public Color[] targetColorsForKeyW;

    public GameObject[] objectsForKeyE;
    public Color[] targetColorsForKeyE;

    public GameObject[] objectsForKeyR;
    public Color[] targetColorsForKeyR;

    public float colorChangeSpeed = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ChangeColors(objectsForKeyQ, targetColorsForKeyQ));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(ChangeColors(objectsForKeyW, targetColorsForKeyW));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ChangeColors(objectsForKeyE, targetColorsForKeyE));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ChangeColors(objectsForKeyR, targetColorsForKeyR));
        }
    }

    private IEnumerator ChangeColors(GameObject[] objects, Color[] targetColors)
    {
        float[] progress = new float[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            progress[i] = 0f;
        }

        bool allColorsReached = false;

        while (!allColorsReached)
        {
            allColorsReached = true;

            for (int i = 0; i < objects.Length; i++)
            {
                SpriteRenderer spriteRenderer = objects[i].GetComponent<SpriteRenderer>();
                Color startColor = spriteRenderer.color;
                Color targetColor = targetColors[i];

                progress[i] += Time.deltaTime / colorChangeSpeed;

                // Linear color change for each object
                spriteRenderer.color = Color.LerpUnclamped(startColor, targetColor, progress[i]);

                // Check if the current color has reached the target color
                if (progress[i] < 1f)
                {
                    allColorsReached = false;
                }
            }

            yield return null;
        }
    }
}
