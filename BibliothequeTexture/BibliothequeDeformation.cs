using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BibliothequeDeformation : MonoBehaviour {

	public GameObject scrollview;
	public string pathToMaterials;
	public Deformation3D script;
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
		List<string> listScriptPath = mainTree.getPaths();
		for(int i = 0; i<listScriptPath.Count; i++) {
			if (!listScriptPath[i].EndsWith (".cs")) {
				listScriptPath.RemoveAt(i);
				i--;
			}
		}

		float y = -20;
		string[] CategorieTexture = {};
		int tab=0;

		foreach (string path in listScriptPath) {
			int j = 0;
			string[] newCat = path.TrimStart ((pathToMaterials + "\\").ToCharArray ()).Split ("\\".ToCharArray(),200);
			try{
				while(CategorieTexture[j] == newCat[j]){
				j++;
				}
			}catch(System.IndexOutOfRangeException){

			}
			CategorieTexture = newCat;
			for (int i = j ; i < CategorieTexture.Length - 1; i++) {
				tab = i * 20 + 20; //px 
				Text typeElem = creerText ("type",
					                CategorieTexture [i],
					                new Vector3 (tab, y, 0),
					                new Vector2 (290, 20),
					                contentElement,
					                FontStyle.BoldAndItalic);
				y -= typeElem.rectTransform.sizeDelta.y;


			}
			
			
			Text textElem = creerText("script",
				newCat[newCat.Length-1].TrimEnd(".cs".ToCharArray()),
				new Vector3 (tab+20, y, 0),
				new Vector2 (290, 20),
				contentElement,
				FontStyle.Normal);
			y -= textElem.rectTransform.sizeDelta.y;
			//Creation du clickable 
			textElem.gameObject.AddComponent(typeof(Button));
			textElem.GetComponent<Button>().onClick.AddListener(delegate{
				script.deformer();
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
