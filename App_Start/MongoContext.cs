using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MongoDB.Driver;

namespace CasinoDataMVC.App_Start
{
    public class MongoContext
    {
        private MongoClient mongoDBClient;
        //private MongoServer mongoDBServer;
        public IMongoDatabase mongoDB;

        public MongoContext()
        {
            //Web.config credentials read in
            var mongoDBName = WebConfigurationManager.AppSettings["MongoDBName"];
            var mongoUname = WebConfigurationManager.AppSettings["MongoUname"];
            var mongoPword = WebConfigurationManager.AppSettings["MongoPword"];
            var mongoPort = WebConfigurationManager.AppSettings["MongoPort"];
            var mongoHost = WebConfigurationManager.AppSettings["MongoHost"];
            
            //Credentials init
            var mongoDBCredential = MongoCredential.CreateMongoCRCredential(mongoDBName, mongoUname, mongoPword);
            
            //MongoClient settings init
            var mongoDBSettings = new MongoClientSettings
            {
                Credential = mongoDBCredential,
                Server = new MongoServerAddress(mongoHost, Convert.ToInt32(mongoPort))
            };
            mongoDBClient = new MongoClient(mongoDBSettings);
            mongoDB = mongoDBClient.GetDatabase(mongoDBName);
        }
    }
}