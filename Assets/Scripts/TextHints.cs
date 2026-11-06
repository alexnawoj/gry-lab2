using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHints : MonoBehaviour
{
    [SerializeField] private float displayTime = 4f;

    private TextMeshProUGUI hintText;
    private float timer;

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

        if (timer >= displayTime)
            hintText.enabled = false;
    }

    public void ShowHint(string message) {
        hintText.text = message;
        hintText.enabled = true;
        timer = 0f;    
    }
}
