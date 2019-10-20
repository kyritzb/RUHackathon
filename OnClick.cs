using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField inputField;
    Button button;
    string letter;
    void Start() {
        button = this.GetComponent<Button>();
        letter = button.GetComponentInChildren<Text>().text;
        button.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick() {
        inputField.text += letter;
    }
}
