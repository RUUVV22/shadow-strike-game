using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public Image ImageSettings,SelectCharacter,Sound,devinfo,tutorial,bestscore,pausescreen;
    public GameObject rigthleftBtn, jumpattackBtn;
    public int restartlevel;
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(2);
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    public void SettingBtn()
    {
        ImageSettings.gameObject.SetActive(true);
    }
    public void HomeBtn()
    {
        ImageSettings.gameObject.SetActive(false);
        //SceneManager.UnloadScene(1);
        //SelectCharacter.gameObject.SetActive(false);
    }
    public void SelectCharBtn()
    {
        SceneManager.LoadScene(8);
        //SelectCharacter.gameObject.SetActive(true);
    }
    public void ExitCharBtn()
    {
        SceneManager.LoadScene(1);
        //SelectCharacter.gameObject.SetActive(true);
    }
    public void SoundBtn()
    {
        Sound.gameObject.SetActive(true );
    }
    public void ExitSoundBtn()
    {
        Sound.gameObject.SetActive(false);
    }
    public void DevInfoBtn()
    {
        devinfo.gameObject.SetActive(true);
    }
    public void TutorialBtn()
    {
        tutorial.gameObject.SetActive(true);
    }
    public void BestScoreBtn()
    {
        bestscore.gameObject.SetActive(true);
    }
    public void ExitDevInfoBtn()
    {
        devinfo.gameObject.SetActive(false);
    }
    public void ExitTutorialBtn()
    {
        tutorial.gameObject.SetActive(false);
    }
    public void ExitBestScoreBtn()
    {
        bestscore.gameObject.SetActive(false);
    }
    public void RestartBtn()
    {
        playermanager.knifescount = 0;
        Player.hitcounter = 3;
        SceneManager.LoadSceneAsync(restartlevel);
    }
    public void MainmenuBtn()
    {
        playermanager.knifescount = 0;
        Player.hitcounter = 3;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }
    public void PauseBtn()
    {
        Time.timeScale = 0;
        pausescreen.gameObject.SetActive (true);
    }
    public void ExitPauseBtn()
    {
        Time.timeScale = 1;
        pausescreen.gameObject.SetActive(false);
    }
    public void showmobileBtn()
    {
        rigthleftBtn.gameObject.SetActive (true);
        jumpattackBtn.gameObject.SetActive (true);
    }
    public void ExitmobileBtn()
    {
        rigthleftBtn.gameObject.SetActive(false);
        jumpattackBtn.gameObject.SetActive(false);
    }
}
