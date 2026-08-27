[![Watch Gameplay Video](<img width="1101" height="636" alt="Ekran görüntüsü 2026-08-01 114922" src="https://github.com/user-attachments/assets/b78436e5-346e-437f-9404-16eb310da889" />
)](https://www.linkedin.com/feed/update/urn:li:activity:7498756495124275200/)

## 🚀 2D Space Shooter - Core Game Mechanics & OOP Architecture

## 📌 About the Project
This project is the first foundational game I have fully completed from start to finish. It represents my grasp of game engine dynamics, **C#** Object-Oriented Programming (OOP), and memory management. 
While it may look like a classic arcade game on the surface, it features Singleton design patterns, asynchronous Coroutine loops, and a modular UI/Audio architecture under the hood. The coding discipline for my advanced Full-Stack and Multiplayer projects was established right here.

## ⚙️ Core Features & Gameplay Dynamics
* **Wave and Level System:** A centralized `GameManager` tracks the number of enemies in the scene. Once all enemies are cleared, the game automatically progresses to the next difficulty level (3 Levels in total).
* **AI (Patrol Routes):** Enemy ships are not stationary; they smoothly patrol along predefined routes (Waypoints) using `Vector3.MoveTowards` math and fire via asynchronous loops.
* **Infinite Space Illusion:** Using the `BackgroundReply` system, the background image seamlessly loops back to the top once it exits the camera view (Scrolling Background), creating an uninterrupted sense of deep space.
* **Centralized UI Management:** Pause, Level Transition, Game Over, and Finish panels are deeply integrated with the engine's time scale (`Time.timeScale`).

## 🛠️ Technical Details & Software Architecture
The source code is written in 14 different modular scripts, adhering to sustainable and Clean Code principles.
* **Singleton Design Pattern:** Core systems like `GameManager`, `UIManager`, `SoundManager`, and `PlayerHealth` use the Singleton architecture, creating a memory-friendly structure easily accessible from anywhere.
* **Memory Optimization:** To prevent performance drops from accumulating bullets and constantly spawned objects, out-of-bounds items are destroyed using the `OnBecameInvisible` method and timed `Destroy` functions, preventing memory leaks.
* **Asynchronous Programming:** Enemy bullet generation and background object spawning are handled asynchronously using `IEnumerator (Coroutines)` to avoid straining the main `Update` loop.
* **Safe Value Clamping:** `Mathf.Clamp` is used to prevent the player's health from dropping below zero and to keep the spaceship within the screen boundaries.

## 🎮 Controls
* **Movement:** `W, A, S, D` or `Arrow Keys`
* **Shoot:** `Left Mouse Click`
* **Pause:** `ESC`

## 👨‍💻 Developer Note
This project is the first foundational game I have fully completed from start to finish in my coding journey. It taught me not just how to write code, but how to make a complete system (UI, audio, physics, scene transitions) communicate flawlessly. 
To see my advanced **ASP.NET Core Web API** and **Unity Netcode (Multiplayer)** architectures built upon this foundation, please check out the other repositories on my profile.
