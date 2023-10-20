using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler // required interface when using the OnPointerEnter method.
{

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject click = GameObject.FindGameObjectWithTag("Hover");
        DontDestroyOnLoad(click.transform.gameObject);
        click.GetComponent<AudioSource>().Play();
    }
}