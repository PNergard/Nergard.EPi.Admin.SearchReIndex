using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using System.Web.UI;
using EPiServer.Shell.WebForms;
using EPiServer.Data.Dynamic;
using EPiServer.Core;
using EPiServer;
using System.Linq;

namespace Nergard.EPi.Admin.SearchReIndex.Plugins
{
    [GuiPlugIn(DisplayName = "EPiServer Search Index", Description = "", Area = PlugInArea.AdminMenu, Url = "~/Plugins/ReIndexInformation.aspx")]
    public partial class ReIndexInformation : WebFormsBase
    {
        #region Overrides
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            MasterPageFile = UriSupport.ResolveUrlFromUIBySettings("MasterPages/EPiServerUI.master");
            SystemMessageContainer.Heading = "See below for the last time a complete reindex was performed.";
            SystemMessageContainer.Description = "";
        }

        protected override void OnLoad(EventArgs e)
        {
            rptReIndexInformation.DataSource = Store.LoadAll<IndexingInformation>().OrderByDescending(p => p.ExecutionDate).Take(20);
            rptReIndexInformation.DataBind();
            
        }

        #endregion

        #region Methods

        private DynamicDataStore Store
        {
            get
            {
                return (DynamicDataStoreFactory.Instance.GetStore(typeof(IndexingInformation)) ?? DynamicDataStoreFactory.Instance.CreateStore(typeof(IndexingInformation)));
            }
        }

        #endregion

        #region GetDataItems

        protected IndexingInformation IndexInformation
        {
            get
            {
                return Page.GetDataItem() as IndexingInformation;
            }
        }

        #endregion
    }
}