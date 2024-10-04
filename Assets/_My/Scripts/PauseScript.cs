using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    GameObject pauseCanvas;
    bool isPaused;

    void Awake()
    {
        pauseCanvas = GameObject.Find("PauseCanvas");
        pauseCanvas.SetActive(false);
    }

    void Start()
    {
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
            isPaused = true;
        }
    }

    public void UnpauseGame(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isPaused = false;
        }
    }
}
