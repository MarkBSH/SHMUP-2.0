using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    GameObject pauseCanvas;
    bool isPaused;

    void Awake()
    {
        pauseCanvas = GameObject.Find("PausePanel");
        pauseCanvas.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseCanvas.SetActive(false);
        }
    }

    public void PauseGame(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }
    }

    public void CloseMenu()
    {
        isPaused = false;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
