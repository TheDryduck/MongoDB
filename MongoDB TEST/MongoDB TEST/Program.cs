using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            //MongoDB
            MongoClient dbClient = new MongoClient("mongodb+srv://Ludvik:abc@cluster0.9tcog.mongodb.net/Animals?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("Animals_Database");
            var collection = database.GetCollection<BsonDocument>("Animals_Collection");
            //Start
            string animalAmount;
            Console.WriteLine("How many animals do you want to add?");
            animalAmount = Console.ReadLine();
            int intAnimalAmount = Convert.ToInt32(animalAmount);
            //Loop
            try
            {
                var animalId = collection.EstimatedDocumentCount();
                for (int i = 0; i < intAnimalAmount; i++)
                {
                    animalId++;
                    Console.WriteLine("What type is it?"); //Type
                    string type = Console.ReadLine(); //Temp

                    Console.WriteLine("What is the animals name?"); //Name
                    string name = Console.ReadLine();

                    Console.WriteLine("How old is it?"); //Age
                    string age = Console.ReadLine();

                    Console.WriteLine("Rate it's happiness from 0-100%"); //Happiness
                    string happiness = Console.ReadLine();
                    var document = new BsonDocument { { "animal_id", animalId }, {
                            "attributes",
                            new BsonArray {
                                new BsonDocument { { "type", "Type" }, { "Attribute", type } },
                                new BsonDocument { { "type", "Name" }, { "Attribute", name } },
                                new BsonDocument { { "type", "Age" }, { "Attribute", age } },
                                new BsonDocument { { "type", "Happiness" }, { "Attribute", happiness } }
                            }
                        }
                    };
                    collection.InsertOne(document);
                    Console.WriteLine("Animal Added");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
           


        }
    }
}
