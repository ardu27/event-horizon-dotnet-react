# Event Horizon

Hey, this is my project called Event Horizon. It's basically a conference and event management system that I put together. 

I split the project into two main parts: the backend is built with ASP.NET Core Web API, and the frontend is a React app using Vite. I also threw in some nice extras like Framer Motion for animations on the frontend, and used Entity Framework Core and Bogus for the database stuff to give it a realistic feel with mock data.

## What it does
It's supposed to handle event data and lets you manage schedules and conferences. I used the Repository pattern for the backend so the code is pretty clean, and AutoMapper to handle mapping my models to DTOs.

## How to run it

If you want to test it locally, here's what you need to do.

### Backend
1. Go into the `EventHorizon.API` folder.
2. Make sure you have the .NET 8 SDK installed.
3. Just run `dotnet run` to get the server up and running. The API will start listening on its assigned localhost port.

### Frontend
1. Open up the `event-horizon-client` directory.
2. Install the node packages by running `npm install`.
3. Start the dev server with `npm run dev`.

That's pretty much it. Let me know if you run into any weird bugs!
