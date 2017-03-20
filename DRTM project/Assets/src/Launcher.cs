using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void launch1_SelectionnerUnFichier2(){
		SceneManager.LoadScene ("2.Confirmation du modèle", LoadSceneMode.Single);
	}

	public void launchScene2_boutonPrecedent_Scene1(){
		SceneManager.LoadScene ("1.Sélection du modèle", LoadSceneMode.Single);
	}

	public void launchScene2_boutonAppliquerTexture_Scene3(){
		SceneManager.LoadScene ("3.Texture Appliquée", LoadSceneMode.Single);
	}

	public void launch2_AppliquerToutAlaFois_5(){
		SceneManager.LoadScene ("5.Modèle BD", LoadSceneMode.Single);
	}

	public void launch3_Precedent_2(){
		SceneManager.LoadScene ("2.Confirmation du modèle", LoadSceneMode.Single);
	}

	public void launch3_Deformation_4(){
		SceneManager.LoadScene ("4.Déformation appliquée", LoadSceneMode.Single);
	}

	public void launch3_DL(){
		SceneManager.LoadScene ("3.Texture Appliquée", LoadSceneMode.Single);
	}

	public void launch4_Precedent_3(){
		SceneManager.LoadScene ("3.Texture Appliquée", LoadSceneMode.Single);
	}

	public void launch4_DeLa3DVersLa2D_5(){
		SceneManager.LoadScene ("5.Modèle BD", LoadSceneMode.Single);
	}

	public void launch4_DL(){
		SceneManager.LoadScene ("4.Déformation appliquée", LoadSceneMode.Single);
	}
	public void launch5_RetournerAlAccueil_1(){
		SceneManager.LoadScene ("1.Sélection du modèle", LoadSceneMode.Single);
	}

	public void launch5_DL(){
		SceneManager.LoadScene ("5.Modèle BD", LoadSceneMode.Single);
	}
}
