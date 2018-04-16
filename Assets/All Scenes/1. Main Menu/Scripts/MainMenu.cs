﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static float lastInput;
    public GameObject startScreen;
    EventSystem currentEventSystem;

    public bool gameCompleted;

    void Start ()
    {
        currentEventSystem = EventSystem.current;
        lastInput = 0.0f;
        gameCompleted = true;
	}

    void OnEnable()
    {
        transform.Find("Fade").SetAsLastSibling();
        StartCoroutine(fadeIn());
    }

    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            currentEventSystem.SetSelectedGameObject(null);
            transform.Find("Fade").SetAsLastSibling();
            StartCoroutine(fadeOut());
        }

        if (Input.GetButtonDown("Submit"))
        {
            lastInput = Time.time;
        }

        if (gameCompleted == true)
        {
            transform.Find("LevelSelectButton/LockedText").gameObject.SetActive(false);
            transform.Find("LevelSelectButton/LockedButton").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("LevelSelectButton/LockedText").gameObject.SetActive(true);
            transform.Find("LevelSelectButton/LockedButton").gameObject.SetActive(true);
        }
    }

    IEnumerator fadeOut()
    {
        for (float t = 0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        transform.Find("PlayGameButton").SetAsLastSibling();
        transform.Find("LevelSelectButton").SetAsFirstSibling();
        transform.Find("SettingsButton").SetAsFirstSibling();
        startScreen.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    IEnumerator fadeIn()
    {
        for (float t = 0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("LevelSelectButton").SetAsFirstSibling();
        transform.Find("SettingsButton").SetAsFirstSibling();
        currentEventSystem.SetSelectedGameObject(transform.Find("PlayGameButton").gameObject);
    }
}
