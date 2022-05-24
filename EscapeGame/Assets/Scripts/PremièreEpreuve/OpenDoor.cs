using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;
    public AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsOpen", false);
    }

    public void openDoor()
    {
        animator.SetBool("IsOpen", true);
        isOpen = true;
        m_audio.Play();
    }
    public void closeDoor()
    {
        animator.SetBool("IsOpen", false);
        isOpen = false;
    }
}
