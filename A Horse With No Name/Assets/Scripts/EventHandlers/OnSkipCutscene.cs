using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSkipCutscene : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey) // Change KeyCode to the desired key
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}