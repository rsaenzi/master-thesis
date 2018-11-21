using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour {

    void Awake() {

        // Initialize list of all available skyboxes
        List<string> skyboxNames = new List<string> {
            "Amethyst",
            "BrightSun",
            "CloudySea",
            "GreenSea",
            "GrimmNightLarge",
            "InterstellarLarge",
            "MiramarLarge",
            "SkyboxSun5Deg",
            "SkyboxSun5Deg2",
            "SkyboxSun25DegTest",
            "SkyboxSun45Deg",
            "SkyboxSun45Deg",
            "ViolentDaysLarge",
            "WinterSea"
        };

        // Randomly selects a skybox name
        int selectedSkyboxId = Random.Range(0, skyboxNames.Count);
        string selectedSkyboxName = "Skyboxes/Materials/" + skyboxNames[selectedSkyboxId];

        // Loads the material
        Material skyboxToLoad = Resources.Load(selectedSkyboxName) as Material;

        // Sets the material into global Render Settings
        RenderSettings.skybox = skyboxToLoad;
        DynamicGI.UpdateEnvironment();
    }
}