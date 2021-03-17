using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Google.Cloud.Firestore;

namespace Services
{
    public class FirestoreDbService : Facades.IFirestoreDbService
    {
        private readonly Google.Cloud.Firestore.FirestoreDb db;

        public FirestoreDbService(Google.Cloud.Firestore.FirestoreDb dbInstance)
        {
            db = dbInstance;
        }

        public async IAsyncEnumerable<Team> GetTeams()
        {
            CollectionReference collection = db.Collection("Team");
            Query query = collection.WhereLessThan("Born", 1900);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
            {
                yield return new Team()
                {
                    Id = queryResult.Id,
                    Name = new TeamName()
                    {
                        First = queryResult.GetValue<string>("Name.First"),
                        Last = queryResult.GetValue<string>("Name.Last")
                    }
                };
            }
        }
    }
}