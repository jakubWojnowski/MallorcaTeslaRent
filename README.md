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

6. login or registration
 - admin:
   {
  "email": "user1@example.com",
  "password": "Hashedpassword1!"
}
- user:
{
  "email": "user2@example.com",
  "password": "Hashedpassword2!"

}
- login
  
 ![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/bec346d2-8540-4b97-b85c-6bde8d06a7f3)


- registration: 

![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/9bd7cc2b-919e-4b6e-a730-a52147331ab5)

 
7. first page contains locations for renting car
8. 
- locations list

![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/5e10763e-7d09-41df-af42-85cbb2459ceb)

7. second page have list of cars for rent

-cars list   
![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/f271dbcc-c7e0-4ad9-bbe2-c66e80c17bf9)

9. third page is for deploying details about selected car and below that there is functionality to select time range for how long user wants to rent a car

![image](https://github.com/jakubWojnowski/MallorcaTeslaRent/assets/83953649/a809de2c-9c7e-4f36-96bf-a7d2a82be196)




