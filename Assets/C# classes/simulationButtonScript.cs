using UnityEngine;
using UnityEngine.SceneManagement;


public class simulationButtonScript : MonoBehaviour
{
    public string parentname;

    //public int ava;

    //public AudioClip audioClip;
    

    private void Start()
    {
        
    }
    public void OnButtonPress()
    {

        parentname = transform.gameObject.name;
        Debug.Log(parentname.ToString());
        if (parentname.Equals("Simulation Button"))
        {
            //AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //Debug.Log("Button " + parentname + " clicked " + ava + " times.");
            SceneManager.LoadScene("SimScene");
        }
        if (parentname.Equals("Settings Button"))
        {
            SceneManager.LoadScene("SettScene");
        }
        if (parentname.Equals("ToMain"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(parentname.Equals("Colour Map"))
        {
            
        }
    }



}

