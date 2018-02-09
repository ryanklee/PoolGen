# PoolGen
---
Barebones API for generating tournament pools. Generates pools using either snake seeding or sequential seeding.

Issue `GET` requests to `http://poolgen.azurewebsites.net` in the following format:

*  **URL**
`api/pools/seq/:pools/:teams/:rounds` for snake seeded pools
`api/pools/snake/:pools/:teams/:rounds` for sequentially seeded pools

* **Method**
`GET`

* **Required URL Params**
  `pools=[integer]`
  `teams=[integer]`
  `rounds=[integer]`

* **Sample Call**:
  `poolgen.azurewebsites.net/api/pools/seq/2/5/1`

* **(Prettified) Sample JSON Response**:
~~~~
{
    "pools": [
        {
            "name": "Pool A",
            "teams": [
                {
                    "name": "Team 1"
                },
                {
                    "name": "Team 3"
                },
                {
                    "name": "Team 5"
                }
            ],
            "games": [
                {
                    "id": 0,
                    "teams": [
                        {
                            "name": "Team 1"
                        },
                        {
                            "name": "Team 3"
                        }
                    ]
                },
                {
                    "id": 1,
                    "teams": [
                        {
                            "name": "Team 1"
                        },
                        {
                            "name": "Team 5"
                        }
                    ]
                },
                {
                    "id": 2,
                    "teams": [
                        {
                            "name": "Team 3"
                        },
                        {
                            "name": "Team 5"
                        }
                    ]
                }
            ]
        },
        {
            "name": "Pool B",
            "teams": [
                {
                    "name": "Team 2"
                },
                {
                    "name": "Team 4"
                }
            ],
            "games": [
                {
                    "id": 3,
                    "teams": [
                        {
                            "name": "Team 2"
                        },
                        {
                            "name": "Team 4"
                        }
                    ]
                }
            ]
        }
    ]
}
~~~~
