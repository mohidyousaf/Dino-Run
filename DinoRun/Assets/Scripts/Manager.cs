using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int currentbuildIndex;
    public GameObject TryAgainMenu;
    [SerializeField]  public GameObject NextMenu;
    public GameObject HelpMenu;
    public GameObject MainMenu;
    [SerializeField] public GameObject EndScreen;
    // Start is called before the first frame update

            //screens
        //[SerializeField] public GameObject next;
        //[SerializeField] public GameObject end;
        [SerializeField] public GameObject eventSystem;
    
    void Start()
    {
        currentbuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(currentbuildIndex + 1);
    }


    public void TryAgain()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
        SceneManager.LoadScene(currentbuildIndex) ;
    }

    public void Next()
    {
        Debug.Log("Next clicked");
        NextMenu.SetActive(false);
        SceneManager.LoadScene(currentbuildIndex  + 1);
        //SetActive(false);
        
    }

    public void Help()
    {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void HelpBack()
    {
        HelpMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
}
