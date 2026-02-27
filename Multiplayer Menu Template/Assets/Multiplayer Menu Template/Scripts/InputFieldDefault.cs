using TMPro;
using UnityEngine;

public class InputFieldDefault : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldIPAdress;
    [SerializeField] private TMP_InputField inputFieldPortAdress;

    [SerializeField] private string defaultIPAdress = "127.0.0.1";
    [SerializeField] private string defaultPortAdress = "7777";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(inputFieldIPAdress != null)
            inputFieldIPAdress.text = defaultIPAdress;

        if (inputFieldPortAdress != null)
            inputFieldPortAdress.text = defaultPortAdress;
    }
}
