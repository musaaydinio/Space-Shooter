# 🚀 Meteor Rush - 2D Space Shooter (Unity & C#)

![Status](https://img.shields.io/badge/Status-LIVE_ON_ITCH.IO-brightgreen?style=for-the-badge)
![Unity](https://img.shields.io/badge/Unity-2D_Engine-000000?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-OOP-239120?style=for-the-badge&logo=c-sharp)
![itch.io](https://img.shields.io/badge/itch.io-Playable_Build-FA5C5C?style=for-the-badge&logo=itch.io)

> 🎮 **Playable Live Game (itch.io):** [Click Here to Play Meteor Rush](https://nimugame.itch.io/meteor-rush)
>
> 🎬 **Gameplay Showcase Video:** [Watch Gameplay on LinkedIn](https://www.linkedin.com/feed/update/urn:li:activity:7498756495124275200/)

---

[![Meteor Rush Gameplay Showcase](https://github.com/user-attachments/assets/b78436e5-346e-437f-9404-16eb310da889)](https://www.linkedin.com/feed/update/urn:li:activity:7498756495124275200/)

---

## 📌 About The Project
**Meteor Rush** marks the **first fully completed game project** in my software development journey. It represents my initial step into game engine architecture, **C# Object-Oriented Programming (OOP)**, engine physics, and runtime memory optimization.

While presenting a classic arcade space shooter experience on the surface, the codebase was built with sustainable design patterns—including Singleton Managers, asynchronous Coroutine loops, and decoupled UI/Audio systems. The coding discipline, architectural mindset, and performance awareness established in this project laid the foundation for my subsequent **Full-Stack ASP.NET Core Web API** and **Unity Netcode (Multiplayer)** projects.

---

## ⚙️ Core Gameplay & Engine Features

* **Wave & Level Progression System:** A centralized `GameManager` monitors active scene entities. Upon clearing all enemy ships in a wave, the system automatically advances the player through 3 distinct difficulty levels.
* **Waypoint Patrol AI:** Enemy ships utilize vector math (`Vector3.MoveTowards`) to patrol predefined paths continuously and trigger weapon fire routines via asynchronous loops.
* **Infinite Space Scrolling Background:** Built using a custom `BackgroundReply` offset controller, seamless background looping produces an uninterrupted illusion of traveling through deep space.
* **Engine Time-Scale UI Control:** Complete UI lifecycle management (Pause, Victory, Level Transitions, Game Over) synchronized with Unity's engine time scale (`Time.timeScale`).

---

## 🛠️ Software Architecture & Technical Highlights

Written in 14 modular C# scripts adhering to clean coding standards:

* **Singleton Design Pattern:** Core system managers (`GameManager`, `UIManager`, `SoundManager`, `PlayerHealth`) implement thread-safe Singleton patterns for global accessibility and minimal memory footprint.
* **Memory & Garbage Collection Optimization:** Out-of-bounds projectiles and destroyed entities are safely cleaned up using `OnBecameInvisible` hooks and timed `Destroy` triggers to prevent memory leaks during long play sessions.
* **Asynchronous Coroutine Routines:** Enemy projectile generation and environmental hazards operate asynchronously using `IEnumerator` coroutines, preserving main thread frame timing (`Update` loop efficiency).
* **Boundary Clamping & State Guarding:** `Mathf.Clamp` logic restricts player movement within strict screen bounds and prevents negative health state anomalies.

---

## 🎮 Controls

| Action | Control Key |
| :--- | :--- |
| **Movement** | `W, A, S, D` or `Arrow Keys` |
| **Fire Projectile** | `Left Mouse Click` |
| **Pause Game** | `ESC` |

---

## 👨‍💻 Developer Note
*This project is the milestone where my theoretical C# knowledge transformed into a fully operational, published game. It taught me how UI, audio channels, physics components, and scene management communicate as a unified system.*

*To explore how this foundation evolved into **Multiplayer Netcode Systems** and **Production REST APIs**, feel free to check out my other repositories!*
