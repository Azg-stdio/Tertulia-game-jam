using UnityEngine;
using UnityEngine.UI;

public class XTweenText : XTweener {
    public string[] values;

    [HideInInspector]
    public string type;

    [HideInInspector]
    public int stringIndex;

    [HideInInspector]
    public string value;

    [HideInInspector]
    public float markValue;
    /// <summary>
    /// Sets the value that will be changed, when the from hasn't been set it will change to the starting value
    /// </summary>

    public override void SetValue() {
        value = this.GetComponent<Text>().text;
        markValue = 0;
        stringIndex = 0;
    }

    /// <summary>
    /// Changes value every frame
    /// </summary>

    public override void ChangeValue(float factor) {
        if(factor > markValue + 1.0f / values.Length) {
            stringIndex++;
            markValue = (1.0f / values.Length) * stringIndex;
            ObjectType();
        } else if(factor < markValue - 1.0f / values.Length) {
            stringIndex--;
            markValue = (1.0f / values.Length) * stringIndex;
            ObjectType();
        }
        
        
    }

    /// <summary>
    /// Changes the real value
    /// </summary>

    public override void ObjectType() {
        if(stringIndex < values.Length) {
            this.GetComponent<Text>().text = values[stringIndex];
        }
    }

    /// <summary>
    /// Sets starting value to current value
    /// </summary>

    public override void SetStartValue() {
        stringIndex = 0;
    }

    /// <summary>
    /// Sets end value to current value
    /// </summary>

    public override void SetEndValue() {
        stringIndex = values.Length - 1;
    }
}

