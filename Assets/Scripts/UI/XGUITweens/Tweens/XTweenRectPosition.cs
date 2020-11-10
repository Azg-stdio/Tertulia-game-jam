using UnityEngine;
using UnityEngine.UI;

public class XTweenRectPosition : XTweener {
	public Vector2 minFrom = new Vector2(0, 0);
	public Vector2 minStartValue = new Vector2(0, 0);	

	public Vector2 maxFrom = new Vector2(0, 0);
	public Vector2 maxStartValue = new Vector2(0, 0);	
	
	public Vector2 minTo = new Vector2(0, 0);
	public Vector2 minEndValue = new Vector2(0, 0);	
	
	public Vector2 maxTo = new Vector2(0, 0);
	public Vector2 maxEndValue = new Vector2(0, 0);

	[HideInInspector]
	public string type;

	[HideInInspector]
	public Vector2 valueMin;
	[HideInInspector]
	public Vector2 valueMax;
	/// <summary>
	/// Sets the value that will be changed, when the from hasn't been set it will change to the starting value
	/// </summary>

	public override void SetValue() {
		valueMin = this.GetComponent<RectTransform>().anchorMin;
		valueMax = this.GetComponent<RectTransform>().anchorMax;


		minStartValue = minFrom;
		maxStartValue = maxFrom;
		minEndValue = minTo;
		maxEndValue = maxTo;

	}

	/// <summary>
	/// Changes value every frame
	/// </summary>

	public override void ChangeValue(float factor) {
		valueMin = Vector2.Lerp(minStartValue, minEndValue, factor);
		valueMax = Vector2.Lerp(maxStartValue, maxEndValue, factor);
		ObjectType();
	}

	/// <summary>
	/// Changes the real value
	/// </summary>

	public override void ObjectType() {
		RectTransform rect = this.GetComponent<RectTransform>();

		rect.anchorMin = valueMin;
		rect.anchorMax = valueMax;

		rect.anchoredPosition = Vector2.zero;
		rect.offsetMax = Vector2.zero;
		rect.offsetMin = Vector2.zero;
	}

	/// <summary>
	/// Sets starting value to current value
	/// </summary>

	public override void SetStartValue() {
		minStartValue = valueMin;
		maxStartValue = valueMax;
		minEndValue = minTo;
		maxEndValue = maxTo;
	}

	/// <summary>
	/// Sets end value to current value
	/// </summary>

	public override void SetEndValue() {
		minStartValue = minFrom;
		maxStartValue = maxFrom;
		minEndValue = valueMin;
		maxEndValue = valueMax;
	}
}
