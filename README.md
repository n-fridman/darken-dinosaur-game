<p align="center">
      <img src="https://i.ibb.co/nRzfbCB/Git-Hub-Logo.png" width="726">
</p>

<p align="center">
   <img src="https://img.shields.io/badge/Engine-Unity%202020.3.4%20-blueviolet" alt="Unity Version">
   <img src="https://img.shields.io/badge/Version-1.0%20(Alpha)-blue" alt="Game Version">
   <img src="https://img.shields.io/badge/License-MIT-brightgreen" alt="License">
</p>

## About Darken Dinosaur

**Darken Dinosaur** is a simple open source game created as part of a tutorial video.

## Documentation
Documentation for **Darken Dinosaur** project. Game build with event based architecture.

### Game Events (UnityEvent)
The main game events. All events are private. Handlers are added via the inspector.

#### Input System Events
`DarkenDinosaur.InputSystem.InputManager.gameStart` - The event is triggered when the player clicks on the start button of the game.

`DarkenDinosaur.InputSystem.InputManager.restartLevel` - The event is triggered when the player clicks the level reset button.

`DarkenDinosaur.InputSystem.InputManager.jumpButtonDown` - The event is triggered when the jump button is clicked.

`DarkenDinosaur.InputSystem.InputManager.crouchRunButtonDown` - The event is triggered when you click on the run crouching button.crouching down

`DarkenDinosaur.InputSystem.InputManager.crouchRunButtonUp` - The event is triggered when the player releases the run button while crouching.

#### Character Events
`DarkenDinosaur.Player.Character.jump` -The event is triggered when the character starts jumping.

`DarkenDinosaur.Player.Character.dead` - The event is triggered when the player loses.

`DarkenDinosaur.Player.Character.crouchRunStart` - The event is triggered when you start running while crouching.

`DarkenDinosaur.Player.Character.crouchRunEnd` - The event is triggered when you finish running in a crouch.

## License

The Tube Racing is open-sourced software licensed under the [MIT license](license.txt).
