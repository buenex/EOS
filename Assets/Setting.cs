using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{   

    
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public GameObject GraficsUI;
    public GameObject AudioUI;
    public GameObject GeneralUI;
    public Button GraficsButton;
    public Button AudioButton;
    public Button GeneralButton;
	public GameObject Maps;

    private void Start()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(false);
        GraficsUI.SetActive(false);
        AudioUI.SetActive(false);
        GeneralUI.SetActive(false);
		Maps.SetActive(true);
    }

    private void Update()

    {

		if (Input.GetKeyDown (KeyCode.DoubleQuote) && Maps.activeInHierarchy == true) 
		{
			Maps.SetActive (false);
		}
		else if (Input.GetKeyDown (KeyCode.DoubleQuote) && Maps.activeInHierarchy == false) 
		{
			Maps.SetActive (true);
		}
        if (Input.GetKeyDown("escape"))
        {
            if (PauseUI.activeInHierarchy)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;


            }
           else if (!PauseUI.activeInHierarchy)
            {
                PauseUI.SetActive(true);
                SettingsUI.SetActive(false);
                GraficsUI.SetActive(false);
                AudioUI.SetActive(false);
                GeneralUI.SetActive(false);

                Time.timeScale = 0;
            }

        }
    }
    public void Options()
    {

        if (PauseUI.activeInHierarchy)
        {
            PauseUI.SetActive(false);
            SettingsUI.SetActive(true);
        }
    }
        public void LoadGame()
        {

        }

        public void MainMenu()
        {
        SceneManager.LoadScene(0);
        }
        public void Resume()
        {
        if (PauseUI.activeInHierarchy)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Grafics()
    {
        if (SettingsUI.activeInHierarchy)
        {
            GraficsUI.SetActive(true);
            AudioUI.SetActive(false);
            GeneralUI.SetActive(false);
            GraficsButton.interactable = false;
            AudioButton.interactable = true;
            GeneralButton.interactable = true;
        }

    }
    public void Audio()
    {

        if (SettingsUI.activeInHierarchy)
        {

            Debug.Log("entro");
            GraficsUI.SetActive(false);
            AudioUI.SetActive(true);
            GeneralUI.SetActive(false);
            GraficsButton.interactable = true;
            AudioButton.interactable = false;
            GeneralButton.interactable = true;

        }
    }
    public void General()
    {
        if (SettingsUI.activeInHierarchy)
        {

            GraficsUI.SetActive(false);
            AudioUI.SetActive(false);
            GeneralUI.SetActive(true);
            GraficsButton.interactable = true;
            AudioButton.interactable = true;
            GeneralButton.interactable = false;



        }
    }
    public void Back()
    {
        if (SettingsUI.activeInHierarchy || PauseUI.activeInHierarchy == false)
        {
            PauseUI.SetActive(true);
            SettingsUI.SetActive(false);
        }
    }
    public void Default()
    {


    }
    public void SetTexture(int textureIndex)
    {
        QualitySettings.SetQualityLevel(textureIndex);
    }
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Vsync(bool isvsync)
    {
        if (!isvsync)
        { 
        QualitySettings.vSyncCount = 0;
        }
        else if(isvsync)
        {
            QualitySettings.vSyncCount = 2;
        }
    }
    public void ShadowsQuality(int ShadowsIndex)
    {
        if (ShadowsIndex == 0)
        { 
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.shadowResolution = ShadowResolution.Low;
        }
        if (ShadowsIndex == 2)
        {
            QualitySettings.shadows = ShadowQuality.All;
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
        }
        if (ShadowsIndex == 1)
        {
            QualitySettings.shadows = ShadowQuality.HardOnly;
            QualitySettings.shadowResolution = ShadowResolution.Medium;
            

        }
    }
}