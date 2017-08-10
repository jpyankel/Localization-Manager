using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
/// <summary>
/// Provides the ability to manipulate the sibling Text component at runtime to match the current Locale.
/// </summary>
public class LocaleText : MonoBehaviour {

    [SerializeField]
    private string textID; // The ID of the string resource we want to grab.
    [SerializeField]
    private bool autoUpdate = true; // Does this UI text automatically apply changes to locale?
    private Text textComponent;
    private LocalizationManager localeManager;

    private void Awake () {
        // Cache references:
        textComponent = GetComponent<Text>();
        localeManager = GameObject.FindWithTag("GameController").GetComponent<LocalizationManager>();
        // Bind event if we autoUpdate:
        if (autoUpdate == true) {
            localeManager.languageChanged += updateLocale;
        }
    }

    /// <summary>
    /// Attempts to fetch the associated string resource from the LocalizationManager.
    /// Will update the sibling Text component's text attribute if successful.
    /// </summary>
    public void updateLocale () {
        try {
            string response = localeManager.getText(textID);
            if (response != null) {
                textComponent.text = response;
            }
        }
        catch (NullReferenceException e) {
            Debug.Log(e);
        }
    }
}
