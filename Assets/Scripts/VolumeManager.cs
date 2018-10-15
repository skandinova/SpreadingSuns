using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour {
    public Slider volumeSlider;

    private void Start() {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }

    private void Update() {}

    public void SetVolume() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
    }
}
