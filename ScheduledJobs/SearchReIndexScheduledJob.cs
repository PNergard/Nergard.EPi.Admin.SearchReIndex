using System;
using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.PlugIn;
using EPiServer.Search;
using EPiServer.ServiceLocation;
using System.Linq;

namespace Nergard.EPi.Admin.SearchReIndex.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "EPiServer Search Index")]
    public class SearchReIndexScheduledJob
    {
        static string OkMessage = "Reindex OK";
        static string NotOkMessage = "Error when indexing content";

        public SearchReIndexScheduledJob()
        {
        }

        /// <summary>
        /// Starts the job
        /// </summary>
        /// <returns>A status message that will be logged</returns>
        public static string Execute()
        {
            return ReIndex();
        }

        private static string ReIndex()
        {
            try
            {

                ServiceLocator.Current.GetInstance<ReIndexManager>().ReIndex();

                SaveIndexingInformation();

                return OkMessage;
            }
            catch (Exception exception)
            {
                return NotOkMessage;
            }
        }

        private static void SaveIndexingInformation()
        {
            IndexingInformation information = new IndexingInformation(); 

            information.ExecutionDate = DateTime.Now;
            information.ResetIndex = true;
            Store.Save(information);
        }

        private static DynamicDataStore Store
        {
            get
            {
                return (DynamicDataStoreFactory.Instance.GetStore(typeof(IndexingInformation)) ?? DynamicDataStoreFactory.Instance.CreateStore(typeof(IndexingInformation)));
            }
        }
 



    }
}
