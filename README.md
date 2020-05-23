Solution using Asp.Net Core, CQRS and DDD
==================================================

## How to run
1. Dependencies - Visual Studio and SQL Server 
2. Build the solution
3. Update SQL Server instance name in "Ofx.Battleship.Api" project
4. Run update-database
5. Start api using "Ctrl + F5", or deploy to IIS

## Implementation details

The project has been implemented using Domain Driven Design and Command Query Separation.

The three API's are as below.
1. Create Board: This API will create the game object and will return game id and the two players id

	Request: POST https://{hostname}/api/Battleship/createBoard
	Example Body: {
			"boardX": 10,
			"boardY": 15
		}
	Example Response: {
    "id": "92d9d542-1bf2-4306-6720-08d7ff6ad0c8",
    "players": [
        {
            "id": "61ca179f-ade8-474d-e18a-08d7ff6ad0db"
        },
        {
            "id": "47bec546-4978-4c79-e18b-08d7ff6ad0db"
        }
    ]
    }
2. Add battleship: This api will require the player id, the postion of ship on board, and the size of the ship. Will return true if the ship was successfully added

    Request: POST https://{hostName}/api/Battleship
    Example body: {
        "playerId":"47bec546-4978-4c79-e18b-08d7ff6ad0db",

        "shipDimensionX": 2,
        "shipDimensionY": 1,
        "location": {"x": 2, "y":2}
        }
    Response type: boolean
3. Attack: This API will need the player id and the target location. Will return true if the target location of the opponents board had the ship.

    Request: POST https://{hostName}/api/Battleship/attack
    Example body: {
        "playerId":"47BEC546-4978-4C79-E18B-08D7FF6AD0DB",

        "location": {"x": 6, "y":3}
        }
     Response type: boolean
