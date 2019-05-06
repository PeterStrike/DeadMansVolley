using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This class is used to display info when the player hovers the mouse over a button.
/// </summary>
public class HoverDisplayText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Public variables
    public GameObject hiddenText;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        hiddenText.SetActive(false);
    }

    /// <summary>
    /// Evaluate current state and transition to appropriate state.
    /// </summary>
    /// <param name="eventData"> The EventData usually sent by the EventSystem. </param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        hiddenText.SetActive(true);
    }

    /// <summary>
    /// Evaluate current state and transition to normal state.
    /// </summary>
    /// <param name="eventData"> The EventData usually sent by the EventSystem. </param>
    public void OnPointerExit(PointerEventData eventData)
    {
        hiddenText.SetActive(false);
    }
}
