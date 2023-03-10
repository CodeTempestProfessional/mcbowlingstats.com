using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using McBowlingstatsCore;
using Microsoft.AspNetCore.Mvc;

namespace api.mcbowlingstats.com.V1
{
    public static class Endpoints
    {
        const string ENDPOINT_VERSION_NUMBER = "V1";
        const string FIRESTORE_PROJECT_ID = "mcbowlingstats";
        static FirestoreDb? firestoreDb;

        public static WebApplication RegisterV1Endpoints(this WebApplication application)
        {
            application.MapGet($"/{ENDPOINT_VERSION_NUMBER}/Tick", () => { return "Tock"; });
            application.MapPost($"/{ENDPOINT_VERSION_NUMBER}/CreateGame", async ([FromBody] BowlingGame gameData) => { await AddGame(gameData); });
            application.MapGet($"/{ENDPOINT_VERSION_NUMBER}/GetAllGames", async () => { return await GetAllGames(); });
            return application;
        }

        public static void CheckDatabaseObject()
        {
            if(firestoreDb == null) 
            {
                firestoreDb = new FirestoreDbBuilder
                {
                    ProjectId = FIRESTORE_PROJECT_ID,
                    EmulatorDetection = Google.Api.Gax.EmulatorDetection.EmulatorOnly
                }.Build();
            }
        }

        private static async Task AddGame(BowlingGame bowlingGame)
        {
            CheckDatabaseObject();
            CollectionReference collection = firestoreDb.Collection("Games");
            DocumentReference document = await collection.AddAsync(bowlingGame);
        }

        private static async Task<BowlingGame[]> GetAllGames()
        {
            CheckDatabaseObject();
            CollectionReference collection = firestoreDb.Collection("Games");
            Query query = collection.Limit(256);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            return querySnapshot
                .Select(x => x.ConvertTo<BowlingGame>())
                .ToArray(); ;
        }

        /// <summary>
        /// Creates a sample bowling game from data captured August 26 2022 6:06 PM, only data missing was Player D's last frame
        /// </summary>
        /// <returns></returns>
        private static BowlingGame GetSampleBowlingGame()
        {
            return new BowlingGame()
            {
                BowlingAlleyName = "Sunset",
                DateTime = new DateTime(2022,8,26,18,6,0).ToUniversalTime(),
                Frames = new()
                {
#region Frames
                    new Frame()
                    {
                        SubFrames = new List<int>
                        { 
                            7, 
                            0 
                        },
                        FrameNumber= 1,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        { 
                            7, 
                            0 
                        },
                        FrameNumber= 1,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            5,
                            5
                        },
                        FrameNumber= 1,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            0,
                            7
                        },
                        FrameNumber= 1,
                        UserID = "Player D"
                    },
                    //Seperator 2
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            0,
                            9
                        },
                        FrameNumber= 2,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            5,
                            0
                        },
                        FrameNumber= 2,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            4,
                            5
                        },
                        FrameNumber= 2,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            0
                        },
                        FrameNumber= 2,
                        UserID = "Player D"
                    },
                    //Seperator 3
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            9,
                            0
                        },
                        FrameNumber= 3,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            7,
                            0
                        },
                        FrameNumber= 3,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            0,
                            10
                        },
                        FrameNumber= 3,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            0,
                            8
                        },
                        FrameNumber= 3,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            5,
                            2
                        },
                        FrameNumber= 4,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            0,
                            5
                        },
                        FrameNumber= 4,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            6,
                            3
                        },
                        FrameNumber= 4,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            10,
                        },
                        FrameNumber= 4,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            2
                        },
                        FrameNumber= 5,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            0
                        },
                        FrameNumber= 5,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            4,
                            4
                        },
                        FrameNumber= 5,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            10,
                            0
                        },
                        FrameNumber= 5,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            1,
                            5
                        },
                        FrameNumber= 6,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            7,
                            0
                        },
                        FrameNumber= 6,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            7,
                            2
                        },
                        FrameNumber= 6,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            7,
                            2
                        },
                        FrameNumber= 6,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            3,
                            6
                        },
                        FrameNumber= 7,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            3,
                            0
                        },
                        FrameNumber= 7,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            5,
                            2
                        },
                        FrameNumber= 7,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            2
                        },
                        FrameNumber= 7,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            3,
                            0
                        },
                        FrameNumber= 8,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            1
                        },
                        FrameNumber= 8,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            0
                        },
                        FrameNumber= 8,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            2
                        },
                        FrameNumber= 8,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            0
                        },
                        FrameNumber= 9,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            7,
                            2
                        },
                        FrameNumber= 9,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            10,
                        },
                        FrameNumber= 9,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            2
                        },
                        FrameNumber= 9,
                        UserID = "Player D"
                    },
                    //Seperator
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            3,
                            0
                        },
                        FrameNumber= 10,
                        UserID = "Player A"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            0
                        },
                        FrameNumber= 10,
                        UserID = "Player B"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            2,
                            8
                        },
                        FrameNumber= 10,
                        UserID = "Player C"
                    },
                    new Frame()
                    {
                        SubFrames = new List<int>
                        {
                            8,
                            1
                        },
                        FrameNumber= 10,
                        UserID = "Player D"
                    },
#endregion
                },
                PayeeUserID = "Demo User"
            };
        }
    }
}
