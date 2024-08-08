# RTSAgentsExample
Recruitment task / Unity Developer Test

## Objective
The task is to program functionalities for spawning, managing, and sending agents (characters in an RTS game).

## Expected Flow Upon Build Launch
### Scene Setup
Start with an empty scene without agents.

### User Interface (UI)
- Display the current number of agents.
- Button to add an agent.
- Button to remove a random agent.
- Button to clear all agents.
- Display the current game speed.
- Buttons to speed up, slow down, or pause the game.
- Area to display a message when an agent reaches its destination.

### Agent Behavior
- Upon spawning, the agent selects a point on the scene and moves towards it.
- Once the agent reaches the destination, it picks another point randomly.
- Every agent should have unique GUID
- When the agent reaches its destination, display a brief "Agent <GUID> arrivedˮ message on the UI.
- Use this agent model: Space Robot Kyle URP.
- Agents only need to follow the target and send a notification upon arrival.

## Architecture and Implementation
- Follow the provided architecture diagram closely.
- Ensure that the UI and agent systems are placed in separate Assembly Definitions.
- Core Assembly should contain classes for event handling and storing essential shared data (“servicesˮ).
- We are open to your interpretations, improvements, or enhancements.
- UI and Agents Assemblies should only depend on Core Assembly.

## Technical Details
- Use DOTween for moving agents.
- Optionally enhance the system with pathfinding and obstacle avoidance using the free version of A* Pathfinding Project.
  
## Used:
- Robot Kyle URP https://assetstore.unity.com/packages/3d/characters/robots/robot-kyle-urp-4696
- DOTween https://dotween.demigiant.com/index.php
- A* Pathfinding Project https://arongranberg.com/astar/download
