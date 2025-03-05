using TMPro;
using UnityEngine;

public class ComboDisplayer : MonoBehaviour
{

    public static ComboDisplayer Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isOn;
    public TextMeshProUGUI text;
    public static int originalSize = 36;
    public Color[] colors = { Color.white, Color.yellow, Color.red, Color.black }; //change this as needed to fit

    private int currentSize = originalSize;
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
}
