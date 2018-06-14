//When triggered by a button, delete all playerprefs loaded and save.
function deleteAllPlayerPrefs(areyousure : boolean){
	if(areyousure == true){
		Debug.Log("Tried to call a function without knowing what it does!, (DeletePlayerPrefs.js)");
	}
	else{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}
}
//This is useful for finding problems with loading a preferred language.