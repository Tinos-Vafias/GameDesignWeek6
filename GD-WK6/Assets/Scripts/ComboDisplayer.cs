using TMPro;
using UnityEngine;
using System.Collections;

public class ComboDisplayer : MonoBehaviour
{

    public static ComboDisplayer Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isOn;
    public TextMeshProUGUI text;
    public TextMeshProUGUI points;
    public static int originalSize = 36;
    public Color[] colors = { Color.white, Color.yellow, Color.red, Color.black }; //change this as needed to fit

    private int currentSize = originalSize;
    private Coroutine fadeCoroutine;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it alive between scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }
    public void Toggle()
    {
        isOn = !isOn;
    }

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.Instance.combo.ToString();
        text.enabled = true;
        if (isOn)
        {
            text.color = colors[Mathf.Min((Mathf.FloorToInt(GameManager.Instance.combo / 20)), colors.Length - 1)];
            text.fontSize = currentSize;
        }
        else
        {
            points.enabled = false;
            text.color = Color.white;
            text.fontSize = originalSize;
        }
    }

    public void ScaleUp()
    {
        if (currentSize < 258)
        {
            currentSize = originalSize + 6 * GameManager.Instance.combo;
        }
        else
        {
            currentSize = 258;
        }
    }
    public void ResetScale()
    {
        currentSize = originalSize;
    }

    public void StartFade(float startAlpha, float endAlpha, float duration)
    {
        // Stop any existing fade coroutine before starting a new one
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
        if (isOn)
        {
            fadeCoroutine = StartCoroutine(FadeText(startAlpha, endAlpha, duration));
        }
        else
        {
            points.enabled = false;
        }
    }


    IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        // Ensure the text starts visible
        points.enabled = true;
        points.text = "+" + (1+GameManager.Instance.combo/20).ToString();
        Color color = points.color;
        color.a = startAlpha;
        points.color = color;

        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            points.color = color;
            yield return null;
        }

        color.a = endAlpha;
        points.color = color;

        // Disable the text only if it is fully faded out
        if (endAlpha == 0)
            points.enabled = false;
    }

}
