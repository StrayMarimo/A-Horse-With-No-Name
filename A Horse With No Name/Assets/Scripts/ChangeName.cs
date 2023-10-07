using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeName : MonoBehaviour
{
    void Start()
    {
        GameObject input = GameObject.FindGameObjectWithTag("NameInput");
        input.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("PlayerName");
    }
    public void SavePlayer()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMenu>().playClickSFX();
        GameObject input = GameObject.FindGameObjectWithTag("NameInput");
        if (input.GetComponent<TMP_InputField>().text != "")
        {
            PlayerPrefs.SetString("PlayerName", input.GetComponent<TMP_InputField>().text);
            PlayerPrefs.Save();
            print(PlayerPrefs.GetString("PlayerName"));
            SceneManager.LoadSceneAsync("Main");
        } else 
        {
            input.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red; 
            input.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Please enter a name";
        }
    }

}
