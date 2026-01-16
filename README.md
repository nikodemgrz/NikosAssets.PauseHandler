## About

Provides ingame pause states and events you can subscribe to, as well as a few optional helper scripts that freeze the time during a pause and handle player inputs to toggle the pause state. 
Note that this package uses the new inputsystem from unity as a dependency.

Checkout the [Features](#features) section below for more information about the specific use cases and available helper scripts.

## Support

Since I am developing and maintaining this asset package in my spare time, feel free to support me [via paypal](https://paypal.me/NikosProjects), [buy me a coffee](https://ko-fi.com/nikocreatestech) or check out my [games](https://store.steampowered.com/curator/44541812) or other [published assets](https://assetstore.unity.com/publishers/52812).

## Documentation

See the API doc [TBA]

## Setup

### Unity Package Dependency

The current dependency is a fork with performance improvements ([https://github.com/nikodemgrz/NaughtyAttributes](https://github.com/nikodemgrz/NaughtyAttributes)) of the original open-source project NaughtyAttributes by dbrizov: [https://github.com/dbrizov/NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes).

Note, that the original NaughtyAttributes package is also compatible with this package, in case you already have it installed!

Add the following git urls to the Unity PackageManager:
```
"https://github.com/nikodemgrz/Unity3DHelperTools.git#upm"
"https://github.com/nikodemgrz/NikosAssets.PauseHandler.git"
```

For my NaughtyAttributes performance improvements fork:
```
"https://github.com/nikodemgrz/NaughtyAttributes.git#upm"
```

The original branch:
```
"https://github.com/dbrizov/NaughtyAttributes.git#upm"
```

You can also choose specific releases and tags after the "#" instead of "upm".

## Features

- Add the ```BasePauseManager``` component and optionally (for global access) the ```PauseManagerProvider``` component to your scene, referencing your ```BasePauseManager```.
- You can pause or unpause the game by calling the ```Pause()```, ```UnPause()``` or ```TogglePause()``` functions located in the ```BasePauseManager``` class.
- If you want to toggle the pause by player input ("Esc" for PC and "Options" for gamepads) add the ```TogglPauseByInput``` component in the same scene and reference the ```BasePauseManager``` component, as well as the input actions (available in the settings folder).
- If you want to change the timescale (for example freeze the time during pause), add the ```ChangeTimeScalePauseListener``` component in the same scene and reference the ```BasePauseManager``` component.

