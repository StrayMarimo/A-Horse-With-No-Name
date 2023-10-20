// This script is used to change the player's name
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeName : MonoBehaviour
{
    // The input field for the player's name.
    [SerializeField]
    private TMP_InputField nameInput;
    // The placeholder object for the input field.
    private TextMeshProUGUI placeholder;
    void Start()
    {
        // Set previous name as default
        nameInput.text = PlayerPrefs.GetString("PlayerName");
        // Get the placeholder object
        placeholder = nameInput.placeholder.GetComponent<TextMeshProUGUI>();
    }
    public void SavePlayer()
    {
        // Play click sound effect
        GameObject.FindGameObjectWithTag("Click")
            .GetComponent<AudioSource>().Play();
    
        // If the player entered a name, save it and load the main scene.
        if (nameInput.text != "")
        {
            PlayerPrefs.SetString("PlayerName", nameInput.text.ToString());
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync("Main");
        } 
        // Otherwise, display an error message.
        else 
        {
            placeholder.color = Color.red; 
            placeholder.text = "Please enter a name";
        }
    }

    public void GoToMenu()
    {
        // Play click sound effect
        GameObject.FindGameObjectWithTag("Click")
            .GetComponent<AudioSource>().Play();
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
