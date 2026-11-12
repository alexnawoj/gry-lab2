using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHints : MonoBehaviour
{
    [SerializeField] private float displayTime = 4f;

    private TextMeshProUGUI hintText;
    private float timer;
    private Coroutine fadeCoroutine;

    void Awake() {
        hintText = GetComponent<TextMeshProUGUI>();
        hintText.enabled = false;    
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!hintText.enabled)
            return;

        timer += Time.deltaTime;

        if (timer >= displayTime && fadeCoroutine == null)
            fadeCoroutine = StartCoroutine(FadeTextToZeroAlpha(1f, hintText));
    }

    public void ShowHint(string message) {
        hintText.text = message;
        hintText.alpha = 1f;
        hintText.enabled = true;
        timer = 0f;    
    }

    // needs to be moved to separate script
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        hintText.enabled = false;
        fadeCoroutine = null;
    }
}
