# Real-Time Stealth-Tactics RPG

![Unity 6000.3.20f1](https://img.shields.io/badge/unity-6000.3.20f1-blue)
![License: MIT](https://img.shields.io/badge/license-MIT-lightgrey)
[![Play on itch.io](https://img.shields.io/badge/Play%20on-itch.io-red)](https://deltaforcer1.itch.io/portfolio-game-1)
[![View on GitHub](https://img.shields.io/badge/View%20on-GitHub-black?logo=github)](https://github.com/OliverReuss/portfolio-game-1)

A technical prototype of a real-time stealth-tactics RPG. The primary focus of this project is clean software architecture, scalable AI systems, and decoupled logic.

> **About this project:** Developed as a portfolio piece for my master's degree application. The project serves as a technical showcase for my C# programming and architecture skills. Built for WebGL and hosted on itch.io.

---

## Under the Hood

Instead of relying on tightly coupled scripts, this project is built on an **Event-Driven Architecture** using the Observer pattern. This keeps the core systems (UI, gameplay, AI) separated and easy to scale. Both the player controller and the enemy AI are driven by custom **Finite State Machines (FSM)**.

---

## Features

* **Event-Driven Architecture:** Decoupled codebase utilizing the Observer pattern for efficient communication between game systems.
* **State-Driven AI:** Enemies use FSMs to handle different states (e.g., patrol, investigate, chase) and react dynamically to the player.
* **Pathfinding & Navigation:** Integrated Unity NavMesh for reliable agent movement and obstacle avoidance.
* **Camera System:** Dynamic camera tracking and framing handled via Unity Cinemachine.
* **Centralized Management:** A robust central manager handling game states and data flow.

---

## Play the Game

* **Browser (WebGL):** Play directly on itch.io
* **PC Standalone:** Clone the repository and build locally for Windows, Linux, or macOS.

---

## Controls

| Action | Input |
| :--- | :--- |
| **Move / Interact** | Left Mouse Button (Click to Move) |
| **Pan Camera** | `W`, `A`, `S`, `D` |
| **Pause / Menu** | `Esc` |

---

## Screenshots

<div align="center">
  <img src="docs/screenshot_1.png" width="600" alt="Gameplay Showcase 1">
</div>

<div align="center">
  <img src="docs/screenshot_2.png" width="600" alt="Gameplay Showcase 2">
</div>

---

## License

MIT

---

## Credits

* **Author:** Oliver Reuß
* **Developer:** Oliver Reuß
