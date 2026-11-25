using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] ico_picture;

    public void OnAppClickMail()
    {
        ico_picture[0].SetActive(true);
        ico_picture[0].transform.SetAsLastSibling();
    }

    public void OnAppClickHack()
    {
        ico_picture[1].SetActive(true);
        ico_picture[1].transform.SetAsLastSibling();
    }
    
    public void OnAppClickWeb()
    {
        ico_picture[2].SetActive(true);
        ico_picture[2].transform.SetAsLastSibling();
    }

    public void OnAppExitMail()
    {
        ico_picture[0].SetActive(false);
    }

    public void OnAppExitHack()
    {
        ico_picture[1].SetActive(false);
    }
    
    public void OnAppExitWeb()
    {
        ico_picture[2].SetActive(false);
    }


}