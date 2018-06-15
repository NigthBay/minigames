using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {

    [Header("Variables")]
    public GameObject camera;
    private Vector3 offset;
    float xvel, zvel;
    private Vector3 RotationSnake;
    private Vector3 RotationCamera;
    private int coins;
    public Snake_raul game;
    
    public AudioSource coin;
    public AudioSource crash;

    // Use this for initialization
    void Start () {
        zvel = 0f;
        xvel = 0.03f;
        offset = new Vector3(0,12,0);
        camera.transform.eulerAngles = new Vector3(90, 0, 0);
        coins = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "coin")
        {
            Debug.Log("Has cogido una moneda");
            other.gameObject.SetActive(false);
            StartCoroutine (AddCoin());
            Debug.Log("tienes" + coins);
        }

        if (other.gameObject.name == "muerte")
        {
            StartCoroutine(Death());
            Debug.Log("You are dead");
            SceneManager.LoadScene("Menu_raul");
            //game.EndGame(false); Esto no lo hace para enseñar el game loop
        }
    }

    void Update () {
        if (coins >= 20)
        {
            Debug.Log("Win");
            SceneManager.LoadScene("Menu_raul");
            //game.EndGame(true); Esto no lo hace para enseñar el game loop
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

    IEnumerator AddCoin()
    {
        coin.Play();
        yield return new WaitForSeconds(0.1f);
        coins++;
    }


    IEnumerator Death()
    {
        crash.Play();
        yield return new WaitForSeconds(0);
    }

}


