using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {

    public GameObject camera;
    private Vector3 offset;
    float xvel, zvel;
    enum Direcciones { delante, izquierda, derecha, detras };
    private Direcciones direcciones;
    private Vector3 RotationSnake;
    private Vector3 RotationCamera;
    private int coins;
    public Snake_raul game;


    // Use this for initialization
    void Start () {
        zvel = 0f;
        xvel = 0.03f;
        offset = new Vector3(0,12,0);
        camera.transform.eulerAngles = new Vector3(90, 0, 0);
        direcciones = Direcciones.delante;
        coins = 18;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "coin")
        {
            Debug.Log("Has cogido una moneda");
            Debug.Log("tienes"+ coins);
            other.gameObject.SetActive(false);
            coins++;
        }

        if (other.gameObject.name == "muerte")
        {
            Debug.Log("You are dead");

            game.EndGame(false);
        }
    }

    void Update () {

        if (coins >= 20)
        {
            Debug.Log("Win");
            StartCoroutine(Wait());
            SceneManager.LoadScene("Menu_raul");
            game.EndGame(true);
        }
        transform.Translate(zvel, 0f, xvel);

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Debug.Log("izq");
                RotationSnake = new Vector3(0, -90, 0);
                transform.Rotate(RotationSnake);
    }

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                Debug.Log("der");
                RotationSnake = new Vector3(0, 90, 0);
                transform.Rotate(RotationSnake);
        }
    }

    void LateUpdate()
    {
        camera.transform.position = this.transform.position + offset;
    }

    IEnumerator Wait()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5000);
        Debug.Log(Time.time);
    }

}


