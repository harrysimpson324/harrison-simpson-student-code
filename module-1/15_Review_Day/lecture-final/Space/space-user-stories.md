# Space Mission Simulator - A Voyage To Mars - User Stories

### User Story 1: Starting the Engine

**As a** spaceship pilot,  
**I want** to be able to start the engine of my spaceship,  
**So that** I can prepare for takeoff.

**Acceptance Criteria**:
1. The pilot should be able to initiate the engine start command.
2. On executing the command, the console should display a message confirming the engine has started.
3. The engine should only start if it's not already running.

**Assumptions**:
- The spaceship is equipped with a functioning engine.
- The engine control system is accessible and operational.

**Dependencies**:
- Requires the implementation of the `Engine` class and its `start` method.

<br><br>


### User Story 2: Engine Countdown and Takeoff

**As a** spaceship pilot,  
**I want** a countdown sequence when initiating takeoff,  
**So that** I have clear audible and visual signals for the launch sequence.

**Acceptance Criteria**:
1. When the takeoff command is executed, a 5-second countdown should begin.
2. Countdown should be displayed on the console.
3. At the end of the countdown, the spaceship should be in "takeoff" mode.

**Assumptions**:
- The control system supports a countdown sequence.
- The spaceship is not already in the air.

**Dependencies**:
- Integration of the `countDown` method within the takeoff procedure.

<br><br>


### User Story 3: Landing Sequence

**As a** spaceship pilot,  
**I want** to be able to land the spaceship,  
**So that** I can safely arrive at the destination.

**Acceptance Criteria**:
1. The pilot can execute a landing command.
2. Upon landing command execution, the spaceship should transition to a "landing" state.
3. A confirmation message should be displayed when the spaceship has landed.

**Assumptions**:
- The spaceship has a landing mechanism.
- The destination is suitable for landing.

**Dependencies**:
- Implementation of the `land` method in the `MarsSpaceship` class.

<br><br>


### User Story 4: Stopping the Engine

**As a** spaceship pilot,  
**I want** to be able to stop the engine,  
**So that** I conserve fuel and maintain safety when not in motion.

**Acceptance Criteria**:
1. Pilots can initiate an engine stop command.
2. On execution, the engine should transition to an "off" state.
3. The console should display a message confirming the engine has stopped.

**Assumptions**:
- The engine can be stopped and restarted multiple times.
- The spaceship is equipped with a fuel-conservation system.

**Dependencies**:
- The `Engine` class should have a `stop` method.

<br><br>


### User Story 5: Fuel Consumption

**As a** spaceship pilot,  
**I want** to be able to monitor fuel levels,  
**So that** I can manage my spaceship's fuel efficiently.

**Acceptance Criteria**:
1. The fuel level should decrease with engine use, particularly during takeoff and landing.
2. The console should display current fuel levels.
3. Pilots should receive a warning if fuel levels are critically low - less than 5 units.

**Assumptions**:
- The spaceship has a reliable fuel gauge.
- Fuel consumption rates are known for different operations.

**Dependencies**:
- Requires a functional `FuelTank` class with methods to track and display fuel levels.

---

