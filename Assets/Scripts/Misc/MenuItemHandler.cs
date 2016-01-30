﻿using UnityEngine;
using System.Collections;

public class MenuItemHandler : MonoBehaviour {
    //TODO: Tsekkaa tämä oikeaksi
    public GameObject menu;
    public GameObject about;

    public void MainMenu() {
        Application.LoadLevel("MainMenu");
    }

    public void StartGameSkipIntro() {
        Application.LoadLevel("Game");
    }

    public void StartGame() {
        Application.LoadLevel("MainMenu");
    }
    
    public void ShowAbout() {
        menu.SetActive(false);
        about.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ExitAbout() {
        about.SetActive(false);
        menu.SetActive(true);
    }
}
