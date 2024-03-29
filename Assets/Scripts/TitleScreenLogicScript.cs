using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenLogicScript : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}