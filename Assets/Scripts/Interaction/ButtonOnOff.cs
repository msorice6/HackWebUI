using UnityEngine;

public class ButtonOnOff : MonoBehaviour
{
    [SerializeField] private GameObject gameobject;
    private bool isToggled = false;

    public void OnButtonPress()
    {
        if (isToggled == false)
        {
            gameobject.SetActive(true);
            //Debug.Log("Button turned ON");
            isToggled = true;

        }
        else
        {
            gameobject.SetActive(false);
            //Debug.Log("Button turned OFF");
            isToggled = false;

        }
    }

}
