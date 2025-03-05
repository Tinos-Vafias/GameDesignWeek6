using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ToGame : MonoBehaviour
{
    public string sceneToLoad;
    public Button myButton; 
    
    public void LoadScene()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.health = 100f;
        SceneManager.LoadScene(sceneToLoad); 
    }
}
