# Simple Baking Manager for lightmapping in Unity3D
A tool that allows you to bake multiple scenes easily 

### Why?

Global Illumination plays an important role if you're developing a 3D game with indirect illumination. In Unity3D, lighting settings can be modified in Lighting window (`Window > Lighting > Settings` since Unity 5.6). This window allows you to change parameters and adjust the values for your needs in the scene.

If your project only consists of few scenes, then it is not a big problem to tweak the values one by one when needed. However, if your scenes share same settings and if you have more than 50 scenes in your project, then it can really become a problem. Not only there is a lack of editor tool to override lighting settings of all your scenes in the project, but you also have to write a script to iterate through all your scenes and bake them, unless you want to do that manually. This is not a very big problem if you have a technical person in your team, but otherwise there is no artist friendly solution to deal with this. 

Thus, this tool can be used to facilitate the workflow with baking multiple scenes and applying lighting presets globally in Unity3D.

![](https://github.com/kemalakay/bakemanager/blob/master/Images/BakeManager.jpg)

### Baking Manager

The setup for using the tool is straight forward. To use it, you can simply:

1. Drag `BakeManager.unitypackage` to your project
OR
Open the example project provided in the repository
2. Open `Tools > Lightmaps > Simple Baking Manager`
3. Assign your scenes to Scenes list (alternatively, you can fetch the scene list from Build Settings) 
4. Optionally, you can assign a `Lighting Preset` and enable `Override Lighting Settings`
5. Press Generate Lighting and wait until the process is done

#### Other useful features in Baking Manager: 
* **Bake Option** - There are two options: Individual and Group. Either you can bake your scenes individually, one by one, or you can choose `Group` option and additively load all the scenes in the list in order to bake them together (lighting settings of active scene is used to generate lighting).

* **Print timing** - When this option is enabled, it prints the baking times of your scenes to a text and CSV file. In production, this can prove useful if it takes a lot of time to generate the lighting. Then, you can see how long it takes with your current setup and adjust your settings if needed. Since lighting setup can be different per every scene, this can allow you to take more informed decisions.

* **Log Debug Values** - This option can be enabled if you want to see what's going on behind the scenes. The action taken in every step is printed to console log.

### Lighting Configuration

Lighting configuration can be used as a global preset to override lighting settings in Baking Manager's scene list. You can create a new configuration by simply right clicking in Project tab and clicking on `Create > Lighting Configuration`. It is enough to assign this asset to Lighting Preset parameter in Baking Manager and enable it.

![](https://github.com/kemalakay/bakemanager/blob/master/Images/LightingConfigurationPreset.jpg)

You will find out that many parameters from Lighting window are mirrored to this asset. In the example project, there are three lighting configuration assets provided. High Quality (HQ), Preview Quality and a draft. All of them can be changed and you can create new lighting configurations to save previous presets. In addition, there is a Lighting Preset tool that you can use to mirror and save the lighting setup of your current scenes instead of typing in the values from scratch. You can find this tool in `Tools > Lightmaps > Lighting Preset`. Once you open it, you can see that you can either load a lighting configuration from a directory path, or you can create a new lighting configuration asset by copying lighting settings of your current scene.

![](https://github.com/kemalakay/bakemanager/blob/master/Images/LightingConfigurationAsset.jpg)

### Example project

In the example project, there are three example lighting configuration assets and three scenes to test the feature. Additionally, these scenes are prepared for additive scene loading. Thus, you can gain an insight about loading your scenes additively at runtime unless you're already familiar with it.

![](https://github.com/kemalakay/bakemanager/blob/master/Images/AdditiveLoading.gif)

#### Updates: 
* 21/01/2018 - Initial commit