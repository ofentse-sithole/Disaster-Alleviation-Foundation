# Disaster Alleviation Foundation

## Introduction
Disaster Alleviation Foundation is a web application designed to facilitate the management of disaster-related donations and aid. This platform enables authorized users to securely log in and perform various tasks related to capturing, managing, and allocating both monetary and goods donations.

## Features

### General Features
- Responsive web application with a color scheme of purple and orange.
- Secure user authentication for information editing.

### Monetary Donations
- Capture new monetary donations with mandatory date and amount.
- Option for donors to remain anonymous.

### Goods Donations
- Capture new goods donations with mandatory date, number of items, category, and item description.
- Option for donors to remain anonymous.
- Pre-configured categories: Clothes, Non-perishable foods.
- Ability for authorized users to define new categories of goods.

### Disaster Management
- Capture new disaster information, including start and end dates, location, and description.
- Specify required aid types for a disaster (e.g., water provision, clothing, food).

### Lists and Views
- View lists of:
  - All incoming monetary donations.
  - All incoming goods donations.
  - All disasters.

### Advanced Features 
- Allocate money and goods to an active disaster.
- Capture the purchase of goods using available money, updating inventory and allocation.

### Unit Tests
- Unit tests are implemented to ensure the correctness of logic within the program.
- Tests include checking that you cannot allocate more goods than are available.
- Frequent commits and pushes are encouraged during the development process.

### Public Access Page (Dashboard)
- Publicly accessible page displaying:
  - Total monetary donations received.
  - Total number of goods received.
  - Currently active disasters with allocated money and goods.
