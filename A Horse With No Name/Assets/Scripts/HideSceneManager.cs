using UnityEngine;

public class HideSceneManager : MonoBehaviour
{
    public GameObject[] objectsToHide;

    public void HideObjects()
    {
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    public void ShowObjects()
    {
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(true);
        }
    }
}
