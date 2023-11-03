# MallorcaTeslaRent

# .NET and React + TypeScript Application

This is a template repository for a web application built with .NET and React + TypeScript. It includes instructions for setting up the development environment, running the application using Docker, and managing database migrations with Entity Framework Core.

## Requirements

Before you begin, ensure you have the following software installed on your system:

- [.NET Core 8 SDK] 
- [Node.js]
- [Docker]

## Development Setup
1. Clone this repository:
   ```bash
   git clone https://github.com/jakubWojnowski/MallorcaTeslaRent.git

2. cd Client
    ```bash
    npm install

3. run docker
   ```bash
   docker-compose.yml
   
4. Create a database and apply migrations:
   ```bash
    dotnet ef database update

5. back end runs on: http://localhost:5193 and front end on: http://localhost:5173

6. logi in or registration
   here u have two accounts admin:
   {
  "email": "user1@example.com",
  "password": "Hashedpassword1!"
}
user:
{
  "email": "user2@example.com",
  "password": "Hashedpassword2!"
}
![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/e8b16322-0889-4524-9953-49f6d436bb78)

registration: 

![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/2faae036-938a-409c-8543-f1d4f8f395f6)

7. rent car
   first page contains locations for renting car
   
   ![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/5e10763e-7d09-41df-af42-85cbb2459ceb)

8. after clicking on one of locations second page contains cars
   
![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/f271dbcc-c7e0-4ad9-bbe2-c66e80c17bf9)

9. third page after clicking link "See Details" contains information about car and functionality to rent it for time range 

![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/a809de2c-9c7e-4f36-96bf-a7d2a82be196)




