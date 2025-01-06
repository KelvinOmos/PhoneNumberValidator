# Phone Number Validator API - Implementation Using Onion Architecture

## Overview

This API is designed to validate phone numbers with a focus on clarity, scalability, and separation of concerns. The implementation follows **Onion Architecture**, ensuring distinct responsibilities across different layers of the application. 

### Architecture Layers

The implementation is structured in the following layers:

1. **Core Layer**: 
   - Defines domain models (e.g., `Country`, `CountryDetail`) and interfaces.
   
2. **Application Layer**:
   - Contains the service (`PhoneNumberService`) that implements business logic.
   
3. **Infrastructure Layer**:
   - Includes database context (`AppDbContext`) and seed data.
   
4. **API Layer**:
   - Provides the `PhoneNumberController` with necessary validation, exception handling, and logging using **Serilog**.

## Documentation

### Why Onion Architecture?

- **Separation of Concerns**: Ensures that each layer has a distinct responsibility, making the application easier to maintain.
- **Testability**: Business logic is decoupled from external dependencies, making unit testing more straightforward.
- **Scalability**: New features or services can be easily added without disrupting the existing structure.

### Validation

- Phone numbers are validated for:
  - Minimum length.
  - Correct format.
  
- Detailed error messages are returned for invalid inputs, guiding users on how to correct them.

### Logging

- **Serilog** is used for logging.
  - **Warnings** are logged for validation issues and not-found errors.
  - **Critical errors** are logged with stack traces for better debugging.

## Setup Instructions

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/PhoneNumberValidator.git
