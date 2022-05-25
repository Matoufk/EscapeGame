using UnityEngine;

public class ColorsAchieved : MonoBehaviour
{
    public GameObject cubeVert1;
    public GameObject cubeJaune1;
    public GameObject cubeViolet1;
    public GameObject cubeJaune2;
    public GameObject cubeRouge1;
    public GameObject cubeRouge2;
    public GameObject cubeRouge3;
    public GameObject cubeViolet2;
    public GameObject cubeVert2;
    public GameObject cubeBleu1;
    public GameObject cubeRouge4;
    public GameObject cubeVert3;

    public GameObject couvercle;
    private Animator CouvercleAnimator;
   
    public GameObject camera;
    public AudioSource gagné;
    // Start is called before the first frame update
    void Start()
    {
      CouvercleAnimator= couvercle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)camera.GetComponent<CameraScript>().enabled = true;
            
    }

    public bool Gagne()
    {
        if (cubeVert1.transform.GetComponent<coloursCode>().color +
                 cubeVert2.transform.GetComponent<coloursCode>().color +
                 cubeVert3.transform.GetComponent<coloursCode>().color +
                 cubeRouge1.transform.GetComponent<coloursCode>().color +
                 cubeRouge2.transform.GetComponent<coloursCode>().color +
                 cubeRouge3.transform.GetComponent<coloursCode>().color +
                 cubeRouge4.transform.GetComponent<coloursCode>().color +
                 cubeJaune1.transform.GetComponent<coloursCode>().color +
                 cubeJaune2.transform.GetComponent<coloursCode>().color +
                 cubeViolet1.transform.GetComponent<coloursCode>().color +
                 cubeViolet2.transform.GetComponent<coloursCode>().color +
                 cubeBleu1.transform.GetComponent<coloursCode>().color
                 == "greengreengreenredredredredyellowyellowpurplepurpleblue")
        {
            CouvercleAnimator.SetBool("isOpening", true);
            gagné.Play();
            camera.GetComponent<CameraScript>().enabled = false;
            camera.transform.LookAt(couvercle.transform.position);
            
            return true;
        }

        else return false;
    }

    public void Open()
    {
        print("gagné");
    }
}
