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
        if(this.GetComponent<Button>() != null)
        {
            button = this.GetComponent<Button>();
            letter = button.GetComponentInChildren<Text>().text;
            button.onClick.AddListener(TaskOnClick);
        }
    }
    public void TaskOnClick() {
        if (this.name == "xsqr") {
            inputField.text += "^2";
        } else if (this.name == "xcube") {
            inputField.text += "^3";
        } else if (this.name == "xtoy") {
            inputField.text += "^y";
        } else if (this.name == "etox") {
            inputField.text += "e^";
        } else if (this.name == "10powx") {
            inputField.text += "10^";
        } else if (this.name == "/x") {
            inputField.text += "/x";
        } else if (this.name == "sqrroot") {
            inputField.text += "sqrt(";
        } else if (this.name == "cuberoot") {
            inputField.text += "sqrt(";
        } else if (this.name == "ysqrrootx") {
            inputField.text += "ysqrt(x";
        } else if (this.name == "ln") {
            inputField.text += "ln(";
        } else if (this.name == "log") {
            inputField.text += "log(";
        } else if (this.name == "factorial") {
            inputField.text += "!";
        } else if (this.name == "sin") {
            inputField.text += "sin(";
        } else if (this.name == "cos") {
            inputField.text += "cos(";
        } else if (this.name == "tan") {
            inputField.text += "tan(";
        } else if (this.name == "e") {
            inputField.text += "e";
        } else if (this.name == "(") {
            inputField.text += "(";
        } else if (this.name == ")") {
            inputField.text += ")";
        } else if (this.name == "pi") {
            inputField.text += "pi";
        } else if (this.name == "x") {
            inputField.text += "x";
        } else if (this.name == "y") {
            inputField.text += "y";
        } else {
            if(inputField != null)
                inputField.text += letter;
        }
    }
}