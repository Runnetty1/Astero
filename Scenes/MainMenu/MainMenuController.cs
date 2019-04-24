using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public GameObject[] Windows;
    public AudioMixer audioMixer;
    public Slider[] sliders;
    public string currentSlider;
    public void loadLevel(string s)
    {
        Application.LoadLevel(s);
    }

    public void showWindow(int id)
    {
        Windows[id].GetComponent<Animator>().SetBool("Show",true);
    }

    public void hideWindow(int id)
    {
        Windows[id].GetComponent<Animator>().SetBool("Show", false);
    }

    public void setCurrentSlider(string name)
    {
        this.currentSlider = name;
    }

    public void setVolume(int id)
    {
        float s = sliders[id].GetComponent<Slider>().value;
        audioMixer.SetFloat(currentSlider, s);
    }

}
