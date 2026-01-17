using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{

  public void LoadScene(int _sceneNumber)
  {
    
    SceneManager.LoadScene(_sceneNumber);

  }


  public void TerminateApplication()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
  
  }
}