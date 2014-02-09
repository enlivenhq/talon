using System;
using Talon.Data.Helpers;

namespace Talon.Web
{
    public partial class SampleData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PopulateSampleData(object sender, EventArgs e)
        {
            new SampleDataPopulation().InsertAllSampleData();
        }
    }
}