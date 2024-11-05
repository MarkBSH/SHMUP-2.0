using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonText : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        text.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        text.GetComponent<RectTransform>().rotation = transform.rotation;

    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void StartMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void Credits()
    {
        //crdits
    }

    void Controlls()
    {
        //controlls
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player Attack"))
        {
            Destroy(other.gameObject);

            if (gameObject.name == "Start Button")
            {
                StartGame();
            }
            else if (gameObject.name == "Quit Button")
            {
                QuitGame();
            }
            else if (gameObject.name == "StartMenu Button")
            {
                StartMenu();
            }
            else if (gameObject.name == "Credits Button")
            {
                Credits();
            }
            else if (gameObject.name == "Controlls Button")
            {
                Controlls();
            }
        }
    }
}
