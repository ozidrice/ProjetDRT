using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bibliotheque : MonoBehaviour {

	public GameObject scrollview;
	public string pathToMaterials;
	private Component contentElement;

	// Use this for initialization
	void Start () {
		//Recherche de l'endroit où placer les elements sur l'UI
		foreach (Component go in this.GetComponentsInChildren<Component>()) {
			if (go.name == "Content") {
				this.contentElement = go;
				break;
			}
		}

		//Get l'arboressance du dossier
		FileTree mainTree = new FileTree (pathToMaterials.TrimStart(pathToMaterials.ToCharArray()), pathToMaterials);
		List<string> listTexturePath = mainTree.getPaths();
		for(int i = 0; i<listTexturePath.Count; i++) {
			if (!listTexturePath[i].EndsWith (".mat")) {
				listTexturePath.RemoveAt(i);
				i--;
			}
		}

		float y = -20;
		string[] CategorieTexture = {};
		int tab=0;

		foreach (string path in listTexturePath) {
			int j = 0;
			string[] newCat = path.TrimStart ((pathToMaterials + "\\").ToCharArray ()).Split ("\\".ToCharArray(),200);
			try{
				//Tant que la catégorie est la meme que celle de l'elem d'avant
				while(CategorieTexture[j] == newCat[j]){
				j++;
				}
			}catch(System.IndexOutOfRangeException){}

			CategorieTexture = newCat;
			for (int i = j ; i < CategorieTexture.Length - 1; i++) {
				tab = i * 20 + 20; //px 
				//Creation des élément de categorie
				Text typeElem = creerText ("categorie",
					                CategorieTexture [i],
					                new Vector3 (tab, y, 0),
					                new Vector2 (290, 20),
					                contentElement,
					                FontStyle.BoldAndItalic);
				y -= typeElem.rectTransform.sizeDelta.y;
			}

			//creation des element de texture
			Text textElem = creerText("texture",
				newCat[newCat.Length-1].TrimEnd(".mat".ToCharArray()),
				new Vector3 (tab+20, y, 0),
				new Vector2 (290, 20),
				contentElement,
				FontStyle.Normal);
			y -= textElem.rectTransform.sizeDelta.y;
			textElem.gameObject.AddComponent (typeof(ChangementTexture));
			textElem.GetComponent<ChangementTexture> ().textureFolderPath = pathToMaterials;
			//Creation du clickable 
			textElem.gameObject.AddComponent(typeof(Button));
			textElem.GetComponent<Button>().onClick.AddListener(delegate{
				textElem.GetComponent<ChangementTexture>().setTypeChangementTexture(new ChangementTextureSelectionne(path));
				textElem.GetComponent<ChangementTexture>().appliquerTexture();
			});
	
		}
	
	}

	Text creerText(string nom, string text, Vector3 pos,  Vector2 size, Component parent, FontStyle fontStyle ){
		GameObject go = new GameObject ();
		Text UIText = go.AddComponent<Text> ();
		UIText.name=nom;

		//Text
		UIText.text = text;
		UIText.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		UIText.fontStyle = fontStyle;
		//Parent
		UIText.transform.SetParent (parent.gameObject.transform);

		//Position
		UIText.transform.localPosition = pos;
		UIText.rectTransform.sizeDelta = size;
		return UIText;
	}
			
	static bool comparer(string[] s1, string[] s2){
		if (s1.Length != s2.Length)
			return false;
		for (int i = 0; i < s1.Length-1; i++) {
			if (s1 [i] != s2 [i])
				return false;
		}
		return true;
	}

	static string afficherContenu(string[] list){
		string ret = "{";
		foreach(string st in list){
			ret += st+",";
		}
		return ret + "}";
	}
}
