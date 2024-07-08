using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("firstScene");
    }
}
