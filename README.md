# Bus-tickets-search
To create the project, we used: Clean Architecture/EntityFramework/Mapper/MySQL 8.0.33/ASP.Net 7.0/Identity
https://imgur.com/V1gW8YJ # Bus tickets search (BTS) - free web-application for search tickets 
Database schema - ![Schema](https://i.imgur.com/V1gW8YJ.png)
  -----------------------------------------------------------------------------------------------------------------
The main functionality for the admin:

Role management:
- Сreating a new role
- Deleting a new role
- Role editing
- Assigning a specific role to a specific user
Route Management:
- Create a new route. ![Check](https://i.imgur.com/dApv4to.png)
- Route editing.
- Deleting a route. ![Check](https://i.imgur.com/2UylYzh.png)
- Search by id
- All routes ![Check](https://i.imgur.com/KwGiU2E.png)
Schedule Management:
- Adding a new schedule for a specific route.
- Editing schedule information.
- Deleting the schedule.
- Search by id.
- All schedules. ![Check](https://i.imgur.com/4Gpwdmv.png)
Driver Management:
- Adding a new driver.
- Editing information about the driver. ![Check](https://i.imgur.com/Rt5csX9.png)
- Delete driver. ![Check](https://i.imgur.com/D5GUh3L.png)
- Search by id
- All drivers ![Check](https://i.imgur.com/PkQlE0P.png)
Transport management:
- Adding a new transport (bus).
- Editing transport information.
- Delete transport.
- Search by id.
- All transport. ![Check](https://i.imgur.com/8wy3wWS.png)
Ticket and order management:
- View the list of orders and tickets of users.
- Cancellation of ticket bookings. ![Check](https://i.imgur.com/xl4Sdfs.png)
User Management:
- View the list of all registered users.
- Editing user profiles.
- Deleting users if necessary. ![Check](https://i.imgur.com/Y1epIFb.png)
- Search by id.
- All users. ![Check](https://i.imgur.com/lRlyFBZ.png)
  ---------------------------------------------------------------------------------------------------------------------
Definition of the main functionality for the user:

Registration and authentication:
- Create a user account.
- Login using credentials. ![Check](https://i.imgur.com/wXpuRLk.png)
Search and view routes and schedules:
- Search for available routes based on departure and arrival locations.
- View information about the schedule, including departure time, arrival time, ticket price and other details.
Booking and purchase of tickets:
- Selection of the route and schedule for booking or buying tickets.
- Making an order
Order management:
- View information about the current ticket
- View information about all tickets
- Ticket cancellation
View and edit your profile:
- View personal information and profile details.
- Editing of personal data, including contact details
