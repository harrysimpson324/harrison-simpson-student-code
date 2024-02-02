
# Space Mission Simulator Application - A Voyage To Mars Class Model

## Overview
This document describes the class model for the Space (Mars) Mission Simulator application, focusing on the relationships and interactions between the classes.

## Class Diagram Overview

- `Spacecraft` (Abstract Class)
- `MarsSpaceship` (Extends `Spacecraft`, Implements `Controllable`)
- `Engine`
- `FuelTank`
- `Navigation`
- `Controllable` (Interface)

## Classes and Relationships

### Spacecraft (Abstract Class)
- **Attributes**:
  - `name`: String
- **Methods**:
  - `takeOff()`: void (abstract)
  - `land()`: void (abstract)
  - `getName()`: String

### MarsSpaceship (Extends `Spacecraft`, Implements `Controllable`)
- **Attributes**:
  - `engine`: Engine
  - `fuelTank`: FuelTank
  - `navigation`: Navigation
- **Methods**:
  - `startEngine()`: void
  - `stopEngine()`: void
  - `takeOff()`: void
  - `land()`: void
  - `countDown(int)`: void

### Engine
- **Attributes**:
  - `isRunning`: boolean
- **Methods**:
  - `start()`: void
  - `stop()`: void
  - `isRunning()`: boolean

### FuelTank
- **Attributes**:
  - `fuelLevel`: int
- **Methods**:
  - `consumeFuel(int)`: void
  - `getFuelLevel()`: int

### Navigation
- **Attributes**:
  - `currentLocation`: String
  - `destination`: String
- **Methods**:
  - `updateDestination(String)`: void
  - `getCurrentLocation()`: String
  - `getDestination()`: String

### Controllable (Interface)
- **Methods**:
  - `startEngine()`: void
  - `stopEngine()`: void

## Relationships

- `MarsSpaceship` **extends** `Spacecraft`
- `MarsSpaceship` **implements** `Controllable`
- `MarsSpaceship` has a **composition** relationship with `Engine`, `FuelTank`, and `Navigation`


