using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleImplementation : MonoBehaviour {

    private LocalizationManager localeManager;
    [SerializeField]
    private List<string> languages;
    private int index = 0;

    private void Awake () {
		localeManager = GameObject.FindWithTag("Localization Manager").GetComponent<LocalizationManager>();
    }

	public void onLanguageButtonPressed () {
        index++;
        if (index == languages.Count) { //and here I've been using .Length this whole time, like some sort of monster
            index = 0;
        }
        localeManager.setLocalization(languages[index]);
    }
}
