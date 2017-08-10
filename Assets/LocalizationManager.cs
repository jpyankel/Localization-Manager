using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

/// <summary>
/// Manages all text translations. Should be accessed by anything with text.
/// Is able to give the correct translation for any stored identifier.
/// Automatically loads the last used language, if any, using PlayerPrefs.
/// </summary>
public class LocalizationManager : MonoBehaviour {

    private Dictionary<string, string> texts;
    [SerializeField]
    private string DEFAULT_LANGUAGE = "English";
    private string currentLanguage;

    // Create delegate and events for use with LocalText.cs:
    public delegate void LanguageChangedEventHandler();
    public event LanguageChangedEventHandler languageChanged;

    private void Start () {
        // Load user preferences, if any:
        if (PlayerPrefs.HasKey("LAST_LANGUAGE")) {
            string newLang = PlayerPrefs.GetString("LAST_LANGUAGE");
            print(newLang);
            try {
                setLocalization(newLang);
            }
            catch (Exception e) {
                Debug.Log(e);
                Debug.Log("Trying Default Language: " + DEFAULT_LANGUAGE);
                setLocalization(DEFAULT_LANGUAGE);
            }
        }
        else {
            // If not, we use defaults.
            setLocalization(DEFAULT_LANGUAGE);
        }
    }

    /// <summary>
    /// Sets the current language used by getText() to the language specified.
    /// </summary>
    /// <param name="language">The language to change to.</param>
    public void setLocalization(string language) {
        TextAsset textAsset = Resources.Load<TextAsset>("Locale_" + language);
        if (textAsset != null) {
            texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
            currentLanguage = language;
            onLanguageChanged();
        }
        else {
            throw new Exception("Localization Error!: " + language + " does not have a .txt resource!");
        }
    }

    /// <summary>
    /// Get the text by the specified identifier.
    /// </summary>
    /// <param name="identifier">Identifier to search the current locale for.</param>
    /// <returns>The string associated with the identifier. If this doesn't exist, null.</returns>
    public string getText(string identifier) {
        if (!texts.ContainsKey(identifier)) {
            Debug.Log("Localization Error!: " + identifier + " does not have an associated string!");
            return null;
        }
        return texts[identifier];
    }

    private void OnApplicationQuit () {
        PlayerPrefs.SetString("LAST_LANGUAGE", currentLanguage);
    }

    protected virtual void onLanguageChanged () {
        if (languageChanged != null)
            languageChanged();
    }
}
