# Dev-test-sunway

Welcome to the Dev-test-sunway repository. This project is a full-stack web application for managing hotel bookings, featuring a React front-end and a .NET Core back-end.

## Repository Structure

- **hotel-frontend**: Contains the user interface developed in React.
- **HotelApi**: Contains the back-end API developed in .NET Core.

### Frontend Structure (`hotel-frontend`)

- **src**:
  - **components**: Contains React components like `HotelList.js`, `HotelDetail.js`, and `Navbar.js`.
  - **api.js**: Handles API requests to the back-end.
  - **App.js**: Root component that includes routing logic.

### Backend Structure (`HotelApi`)

- **Controllers**: Contains `HotelsController.cs` which handles API requests.
- **Data**: Contains `hotels.json` which is used to store data temporarily.
- **Models**: Contains `Hotel.cs` which defines the hotel data model.

## Technologies Used

- **Frontend**: React, CSS, React Router
- **Backend**: .NET Core, C#

## Getting Started

Follow these instructions to set up the project locally.

### Prerequisites

Make sure you have the following installed:
- [Node.js and npm](https://nodejs.org/en/download/)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Installation

### Frontend Setup

Navigate to the frontend directory and install dependencies:

cd hotel-frontend
npm install
npm start

-This will start the front-end on http://localhost:3000.

### Backend Setup

Navigate to the backend directory:

cd HotelApi
dotnet restore
dotnet run


Usage
Access the frontend by navigating to http://localhost:3000 in your web browser.

### How will it work 

- once project is cloned

  - if not , please put both frontend and bakend in one single folder
  - we need to have .net installed for the backend
  - install the frontend dependenicies
  - firstly , we need to run the backend , for that we have to simply type " dotnet build " and " dotnet run" command and backend will start
  I have tried to push all files , so that cloner dont have to download anything , if needed still install whatever asked.
  - use the same terminal in visual studio and open new terminal to navigate to the frontend folder and simply start by " npm start"
    

  
