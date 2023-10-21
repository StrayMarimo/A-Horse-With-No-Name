using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode to the desired key
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}