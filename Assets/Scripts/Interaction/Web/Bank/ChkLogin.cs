using TMPro;
using UnityEngine;

public class ChkLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputBoxEmail;
    [SerializeField] private TMP_InputField inputBoxPassword;

    public void OnLoginButtonPress()
    {
        Debug.Log("email: " + inputBoxEmail.text);
        Debug.Log("password: " + inputBoxPassword.text);
    }
}
