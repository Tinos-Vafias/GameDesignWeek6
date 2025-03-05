using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ToGame : MonoBehaviour
{
    public string sceneToLoad;
    public Button myButton; 
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); 
    }
}
