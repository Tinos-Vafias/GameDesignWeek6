using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int combo = 0;
    public bool isGameOver = false;
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

    public void AddCombo()
    {
        Debug.Log("Adding Combo");
        combo += 1;
        FireProjectile.Instance.Combo();
        ComboDisplayer.Instance.ScaleUp();
        CameraShake.Instance.StartShake();
		ParrySound.Instance.PlaySound();
    }
    public void ResetCombo()
    {
        Debug.Log("Resetting Combo");
        combo = 0;
        FireProjectile.Instance.ResetCombo();
        ComboDisplayer.Instance.ResetScale();
        CameraShake.Instance.ResetCamera();
		ParrySound.Instance.ResetSemitone();
    }


    //All toggles
    public void ToggleCombo()
    {
        Debug.Log("Toggle Combo");
        ComboDisplayer.Instance.Toggle();
    }
    public void ToggleShake()
    {
        CameraShake.Instance.Toggle();
    }
    public void ToggleSounds()
    {
        ParrySound.Instance.Toggle();
    }
}
