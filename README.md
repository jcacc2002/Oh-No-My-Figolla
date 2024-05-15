# Oh No! My Figolla

"Oh No! My Figolla" is an engaging game developed as part of a game programming assignment. The game involves a series of interactive challenges that the player must complete to achieve the highest score.

## Objectives
- Provide an entertaining and challenging gaming experience.
- Implement fundamental game programming concepts using Unity.

## Getting Started

### Prerequisites
- Unity 2020.3 or later
- TextMeshPro package (included in Unity)

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/jcacc2002/Oh-No-My-Figolla.git
    ```
2. Open the project in Unity:
    - Open Unity Hub.
    - Click on "Add" and select the project directory.
    - Open the project.
3. Ensure all necessary packages are installed:
    - TextMeshPro

## Usage

### How to Play
1. Start the game by pressing the play button in the Unity editor.
2. Follow the on-screen instructions to complete the tasks.
3. Achieve the highest score by performing actions correctly and timely.

### Controls
- **Mouse Click**: Interact with various game elements.
- **Dial**: Rotate to the specified position.
- **Switch**: Toggle on/off as instructed.
- **Button**: Press the button the specified number of times.

## Code Structure

### Project Structure
- `Assets/`: Contains all game assets including scripts, scenes, and prefabs.
- `Scripts/`: Contains the C# scripts used in the project.
- `Scenes/`: Contains the game scenes.

### Main Scripts
#### `BaseController.cs`
An abstract base class for all controllers. Provides a method to handle click events.

#### `ButtonController.cs`
Handles button click events, updating the game state and playing sounds.

#### `DialController.cs`
Handles the rotation of a dial, updating the game state based on the direction and degree of rotation.

#### `MouseRecorder.cs`
Records mouse clicks and notifies the relevant controllers.

#### `ShowHighscore.cs`
Displays the high score by reading from a persistent data file.

#### `StartGame.cs`
Handles starting the game when a specific UI element is clicked.

#### `SwitchController.cs`
Manages the state of a switch, updating the game state and playing sounds based on the toggle state.

#### `TextController.cs`
Manages the text instructions and player interactions, including updating scores and handling success or failure states.

#### `TimeController.cs`
Controls the countdown timer displayed on the screen.
