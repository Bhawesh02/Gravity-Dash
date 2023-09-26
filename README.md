# Gravity Dash Game


Welcome to the repository for the Gravity Dash game! This 2D platformer project features dynamic player mechanics, diverse pickups, and an engaging level progression system.

## Project Overview

The Gravity Dash game is a 2D platformer developed in Unity. The project includes various gameplay mechanics, UI elements, and level design features that enhance the overall player experience.

## Key Features

- **Player Mechanics:** Responsive movement, gravity switching, and collision interactions.
- **Level Progression:** Dynamic unlocking of levels based on player progress.
- **Interactive UI:** Elements for level completion, player death, and level selection.
- **Diverse Pickups:** Unique effects such as extra lives, checkpoints, and mass increase.
- **Code Structure:** Modular scripting, scene transitions, and data persistence.
- **Gameplay Enhancement:** Engaging mechanics, level design, and interactive elements.

## Coding Architecture

### MVC (Model-View-Controller) Architecture

The project follows the MVC architectural pattern, which separates the application into three interconnected components:

- **Model**: Represents the game's data and business logic. Includes classes for the player, pickups, and game state.

- **View**: Handles the visual aspects of the game, such as UI elements, player animations, and rendering. The `PlayerView` script, for example, manages the player's visual components.

- **Controller**: Controls the game's behaviour and user input. The `PlayerController` script, for instance, manages the player's actions and interactions.

### Singleton Pattern

Several components in the project, such as the `GameManager`, `EventService`, and `UIService`, implement the Singleton pattern:

- **GameManager**: Manages game state, scene transitions, and game elements such as platforms and pickups.

- **EventService**: Handles game events like player death, pickup collection, and level completion using events and delegates.

- **UIService**: Manages user interface elements and their interactions, including restart buttons, lobby buttons, and level completion UI.

### Observer Pattern

The Observer pattern is utilized through the EventService. It allows decoupled components to subscribe to and respond to events triggered by other parts of the game. For instance:

- Subscribing to the `PlayerDied` event displays the player death UI.
- Subscribing to the `PickupCollected` event updates UI elements and triggers game effects.
- Subscribing to the `LevelCompleted` event displays level completion UI.

### Scriptable Object

Scriptable Objects are used to store and manage game data and configurations:

- **PlayerScriptableObject**: Contains player-related configuration data such as speed, mass change, and increased mass duration. This allows for easy tuning and balancing of player mechanics.

## GamePlay

[Video](https://www.loom.com/share/e7169c94b1c049009b688c6eddc358ef)

### Screen Shots



---


