using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XTweenColor : XTweener {
    public Color from = Color.white;
    public Color startColor = Color.white;
    public Color to = Color.white;
    public Color endColor = Color.white;
    public bool includeChildren = false;

    [HideInInspector]
    public string type;

    [HideInInspector]
    public Color value;

    /// <summary>
    /// Sets the value that will be changed, when the from hasn't been set it will change to the starting value
    /// </summary>

    public override void SetValue() {
        if (this.GetComponent<Image>() != null) { value = this.GetComponent<Image>().color; type = "Image"; } 
        else if (this.GetComponent<RawImage>() != null) { value = this.GetComponent<RawImage>().color; type = "RawImage"; } 
        else if (this.GetComponent<Text>() != null) { value = this.GetComponent<Text>().color; type = "Text"; } 
        else if (this.GetComponent<TextMeshPro>() != null) { value = this.GetComponent<TextMeshPro>().color; type = "TextMeshPro"; } 
        else if (this.GetComponent<TextMeshProUGUI>() != null) { value = this.GetComponent<TextMeshProUGUI>().color; type = "TextMeshProUGUI"; } 
        else if (this.GetComponent<MeshRenderer>() != null) { value = this.GetComponent<MeshRenderer>().material.color; type = "MeshRenderer"; } 
        else value = Color.white;

        startColor = from;
        endColor = to;
    }

    /// <summary>
    /// Changes value every frame
    /// </summary>

    public override void ChangeValue(float factor) {
        float R = Mathf.Lerp(startColor.r, endColor.r, factor);
        float G = Mathf.Lerp(startColor.g, endColor.g, factor);
        float B = Mathf.Lerp(startColor.b, endColor.b, factor);
        value.r = R;
        value.g = G;
        value.b = B;

        ObjectType();
    }

    /// <summary>
    /// Changes the real value
    /// </summary>

    public override void ObjectType() {
        Color tempColor = new Color(0, 0, 0);
        switch (type) {
            case "Text":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<Text>().color.a);
                this.GetComponent<Text>().color = tempColor;
                break;
            case "Image":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<Image>().color.a);
                this.GetComponent<Image>().color = tempColor;
                break;
            case "RawImage":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<RawImage>().color.a);
                this.GetComponent<RawImage>().color = tempColor;
                break;
            case "TextMeshPro":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<TextMeshPro>().color.a);
                this.GetComponent<TextMeshPro>().color = tempColor;
                break;
            case "TextMeshProUGUI":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<TextMeshProUGUI>().color.a);
                this.GetComponent<TextMeshProUGUI>().color = tempColor;
                break;    
            case "MeshRenderer":
                tempColor = new Color(value.r, value.g, value.b, this.GetComponent<MeshRenderer>().material.color.a);
                this.GetComponent<MeshRenderer>().material.color = tempColor;
                break;
        }
        if (includeChildren) {
            foreach (Image img in this.GetComponentsInChildren<Image>()) img.color = value;
            foreach (RawImage rimg in this.GetComponentsInChildren<RawImage>()) rimg.color = value;
            foreach (Text txt in this.GetComponentsInChildren<Text>()) txt.color = value;
            foreach (TextMeshPro txt in this.GetComponentsInChildren<TextMeshPro>()) txt.color = value;
            foreach (TextMeshProUGUI txt in this.GetComponentsInChildren<TextMeshProUGUI>()) txt.color = value;
            foreach (MeshRenderer txt in this.GetComponentsInChildren<MeshRenderer>()) txt.material.color = value;
        }
    }

    /// <summary>
    /// Sets starting value to current value
    /// </summary>

    public override void SetStartValue() {
        startColor = value;
        endColor = to;
    }

    /// <summary>
    /// Sets end value to current value
    /// </summary>

    public override void SetEndValue() {
        startColor = from;
        endColor = value;
    }
}
