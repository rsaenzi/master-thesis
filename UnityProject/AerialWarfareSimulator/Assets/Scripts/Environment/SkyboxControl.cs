using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxControl : MonoBehaviour {

    private List<string> skyboxNames;

    void Awake() {

        // Initialize the list of available skyboxes
        skyboxNames = new List<string>();
        skyboxNames.Add("Amethyst");
        skyboxNames.Add("BrightSun");
        skyboxNames.Add("CloudySea");
        skyboxNames.Add("GreenSea");
        skyboxNames.Add("GrimmNightLarge");
        skyboxNames.Add("InterstellarLarge");
        skyboxNames.Add("MiramarLarge");
        skyboxNames.Add("SkyboxSun5Deg");
        skyboxNames.Add("SkyboxSun5Deg2");
        skyboxNames.Add("SkyboxSun25DegTest");
        skyboxNames.Add("SkyboxSun45Deg");
        skyboxNames.Add("SkyboxSun45Deg");
        skyboxNames.Add("ViolentDaysLarge");
        skyboxNames.Add("WinterSea");

        // Randomly selects a skybox name
        int selectedSkyboxId = Random.Range(0, skyboxNames.Count);
        string selectedSkyboxName = "Skyboxes/Materials/" + skyboxNames[selectedSkyboxId];

        // Loads the Material
        Material skyboxToLoad = Resources.Load(selectedSkyboxName) as Material;
        print(skyboxToLoad);

        RenderSettings.skybox = skyboxToLoad;
        DynamicGI.UpdateEnvironment();
    }

    void Start () {
		
	}
}
