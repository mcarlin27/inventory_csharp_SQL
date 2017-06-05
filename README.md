# Inventory

#### A program that allows users to input items into an inventory using databases to store the information. 6/5/17

#### By **Marilyn Carlin and Anabel Ramirez**

## Description

A website created with C#, SQL, and HTML where a user can input data into an inventory database.


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **User can add items to an inventory database.** | add RedDrum scarf, year, description | RedDrum scarf, year, description, id |
| **User can delete an item listing.** | delete RedDrum scarf | delete RedDrum scarf |
| **User can query the inventory items list.** | list all scarves | list all scarves |
| **User can add multiple items to an inventory database.** | form add RedDrum scarf, year, description; add No Pity scarf, year, description | RedDrum scarf listing, No Pity listing |

## Setup/Installation Requirements

1. To run this program, you must have a C# compiler. I use [Mono](http://www.mono-project.com).
2. Install the [Nancy](http://nancyfx.org/) framework to use the view engine. Follow the link for installation instructions.
3. Clone this repository.
4. Open the command line--I use PowerShell--and navigate into the repository. Use the command "dnx kestrel" to start the server.
5. On your browser, navigate to "localhost:5004" and enjoy!

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
  * Nancy framework
  * Razor View Engine
  * ASP.NET Kestrel HTTP server
  * xUnit
  * SQL

* HTML

## Support and contact details

_Email no one with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Marilyn Carlin, Anabel Ramirez}_**
