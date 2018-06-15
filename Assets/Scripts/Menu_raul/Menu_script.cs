using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour {

    public Button Jugar;
    public Button Creditos;
    public Button Salir;

    // Use this for initialization
    void Start () {
        Button play = Jugar.GetComponent<Button>();
        play.onClick.AddListener(JugarClick);

        Button creditos = Creditos.GetComponent<Button>(); 
        creditos.onClick.AddListener(CreditsClick);

        Button salir = Salir.GetComponent<Button>();
        salir.onClick.AddListener(SalirClick);
    }

    public void JugarClick()
    {
        SceneManager.LoadScene("Snake_raul");
    }
        public void CreditsClick()
    {
        SceneManager.LoadScene("Creditos_raul");
    }

    public void SalirClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
