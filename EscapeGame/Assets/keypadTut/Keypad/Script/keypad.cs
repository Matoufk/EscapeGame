

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    // *** CAN DELETE THESE ** \\
    // Used to hide joystick and slider
  //  [Header("Objects to Hide/Show")]
  //  public GameObject objectToDisable;
   // public GameObject objectToDisable2;

    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;
    public GameObject player;
     public GameObject camera;


    // *** Breakdown of header(public) variables *** \\
    // curPassword : Pasword to set. Ive set the password in the project. Note it can be any length and letters or numbers or sysmbols
    // input: What is currently entered
    // displayText : Text area on keypad the password entered gets displayed too.
    // audioData : Play this sound when user enters in password incorrectly too many times

    [Header("Keypad Settings")]
    public string curPassword = "5364";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

   
    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
                // LOG message that password is correct
                Debug.Log("Correct Password!");
                input = ""; //Clear Password
                btnClicked = 0;

            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }
        keypadclick();

    }

    void keypadclick()
    {
        // Action for clicking keypad( GameObject ) on screen
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            float range = 10f;

            if( Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {
            objectToEnable.SetActive(true);
            player.GetComponent<CharacterScript>().enabled = false;
            camera.GetComponent<CameraScript>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
               
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                player.GetComponent<CharacterScript>().enabled = true;
                camera.GetComponent<CameraScript>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
