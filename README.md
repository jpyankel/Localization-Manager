# Changes from initial fork
  After downloading, I noticed this example project is just straight up broken. I intend to fix it.
  
# Localization-Manager
JSON localization string manager for Unity3D

## The Demo
Open ExampleScene. You will see a scene with two buttons (with text) and a title text. Upon starting up the scene, all text changes to display the current language. This language can be switched by pressing the language button to the right.

## How to Use
Simply copy/paste or drag/drop LocalizationManager.cs into your project. This script should ideally be attached to a game controller or manager type of object (or at least something that will persist through scenes).
You then need to create a Resources folder in the Assets directory of your project. Put as many .txt files as there are languages and rename them according to this pattern: 
```
Locale_<language here>.txt
``` 
E.g. `Local_English.txt`. These files must be filled with JSON data that follows this structure: 
```
{"stringid":"mytranslatedstringhere", "anotherstringid":"anothertranslatedstringhere"}
```
View the example project's Resources folder for a more practical example.
Any text object that needs to be modfified at runtime needs to get a reference to the LocalizationManager component you attached earlier and call `getText("MyIDHere")` to receive the text for the current language. You can set the current language by calling `setLanguage("MyLanguageHere")` on your referenced LocalizationManager. LocalizationManager will automatically load a default language which can be modified by viewing the component in the inspector and retyping the DEFAULT_LANGUAGE variable.

## Extras
I made a utility script to be attached to any UI text objects. This script can be found in Assets/LocaleText.cs. It assumes the object it is attached to has a Text component, and that a GameObject tagged with the "GameController" default tag exists in the scene and holds a LocalizationManager. If set to, LocalText will automatically update the text it manages for the current language and will update each time the language changes. You can also force set the text to not auto-update, as well as force the text to update with a function call. All you need to do to configure it is make sure that the "TextID" parameter in the inspector matches that of the string resource you want fetched from your language file in resources.

Another thing: You can add languages to the example by adding a new language .txt file to the resource and then updating the ExampleImplementation.cs component attached to the scene's canvas. Make sure that when you add the name to the list, you add the text of the file's name as it appears after "Locale_" and before ".txt". So, for example, if you named the resource file "Locale_Spanish.txt", you add to ExampleImplementation's list "Spanish".

## Credits:
I used the lite version of a forked Newtonsoft Json.net plugin to load the JSON and parse it into a dictionary: https://github.com/SaladLab/Json.Net.Unity3D
