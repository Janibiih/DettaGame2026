using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private PlayerInput playerInput;
    private InputAction pauseAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
    }

    void OnEnable()
    {
        pauseAction.performed += OnPause;
    }

    void OnDisable()
    {
        pauseAction.performed -= OnPause;
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (GameIsPaused)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
   
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
