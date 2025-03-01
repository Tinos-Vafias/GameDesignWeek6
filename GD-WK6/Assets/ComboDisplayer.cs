using TMPro;
using UnityEngine;

public class ComboDisplayer : MonoBehaviour
{

    public static ComboDisplayer Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isOn = true;
    public TextMeshProUGUI text;
    public int originalSize = 36;
    public Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow }; //change this as needed to fit

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
        text.color = colors[Mathf.Min((Mathf.FloorToInt(GameManager.Instance.combo /10)), colors.Length-1)];
        if (isOn)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }

    public void ScaleUp()
    {
        text.fontSize += 6;
    }
    public void ResetScale()
    {
        text.fontSize = originalSize;
    }
}
