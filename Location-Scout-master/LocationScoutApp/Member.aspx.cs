using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using LocationScoutApp.LocationServiceRef;
using LocationScoutApp.QuakeServiceRef;
using LocationScoutApp.NewsServiceRef;
using LocationScoutApp.CrimeServiceRef;
using LocationScoutApp.WeatherServiceRef;

namespace LocationScoutApp
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the code that only needs to run once goes here
            if (!IsPostBack)
            {
                // checking if the user is in active session, if not redirecting to login page
                if (Session["MemberAccount"] != null)
                {
                    GeneralUserClass member = (GeneralUserClass)Session["MemberAccount"];
                    LabelUsername.Text = member.username;
                }
                else
                    Response.Redirect("~/MemberLogin.aspx");
            }
        }

        protected void ButtonStoreAddress_Click(object sender, EventArgs e)
        {
            LabelErrorStoreName.Visible = false;
            string zipcode = validateAndReturnZipCode();
            string storeName = TextBoxStoreName.Text;
            string nearestStoreAddress = null;
            if (zipcode != null && !storeName.Equals(""))
            {
                LabelStoreAddress.Visible = true;
                LocationServicesClient client = new LocationServicesClient();
                nearestStoreAddress = client.findNearestStore(zipcode, storeName);
                if (nearestStoreAddress.Equals("") || nearestStoreAddress == null)
                    LabelStoreAddress.Text = "Sorry..No store found in the neighborhood with the given name";
                else
                    LabelStoreAddress.Text = nearestStoreAddress;
            }
            else
            {
                LabelErrorStoreName.Visible = true;
                LabelErrorStoreName.Text = "Please enter a store name";
            }
        }

        protected void ButtonSolarIndex_Click(object sender, EventArgs e)
        {
            string zipcode = validateAndReturnZipCode();
            if (zipcode != null)
            {
                LabelSolarIndex.Visible = true;
                decimal solarIndex = 0;

                string latlon = getLatLonByZipCode(zipcode);

                string[] latLonArray = latlon.Split(',');
                decimal latitude = Convert.ToDecimal(latLonArray[0]);
                decimal longitude = Convert.ToDecimal(latLonArray[1]);

                LocationServicesClient client = new LocationServicesClient();
                solarIndex = client.getSolarIntensity(latitude, longitude);

                if (solarIndex != 0 && solarIndex > 7)
                {
                    LabelSolarIndex.Text = "High";
                }
                else if (solarIndex != 0 && solarIndex > 4 && solarIndex <= 7)
                {
                    LabelSolarIndex.Text = "Medium";
                }
                else if (solarIndex != 0)
                {
                    LabelSolarIndex.Text = "Low";
                }
                else
                {
                    LabelSolarIndex.Text = "Something went wrong in backend";
                }
            }
        }

        protected void ButtonWindIndex_Click(object sender, EventArgs e)
        {
            string zipcode = validateAndReturnZipCode();
            if (zipcode != null)
            {

                LabelWindIndex.Visible = true;
                decimal windIndex = 0;

                string latlon = getLatLonByZipCode(zipcode);

                string[] latLonArray = latlon.Split(',');
                decimal latitude = Convert.ToDecimal(latLonArray[0]);
                decimal longitude = Convert.ToDecimal(latLonArray[1]);

                LocationServicesClient client = new LocationServicesClient();
                windIndex = client.getWindIntensity(latitude, longitude);

                if (windIndex != 0 && windIndex > 7)
                {
                    LabelWindIndex.Text = "High";
                }
                else if (windIndex != 0 && windIndex > 4 && windIndex <= 7)
                {
                    LabelWindIndex.Text = "Medium";
                }
                else if (windIndex != 0)
                {
                    LabelWindIndex.Text = "Low";
                }
                else
                {
                    LabelWindIndex.Text = "Something went wrong in backend";
                }
            }
        }

        protected void ButtonQuakeIndex_Click(object sender, EventArgs e)
        {
            string zipcode = validateAndReturnZipCode();
            if (zipcode != null)
            {
                LabelQuakeIndex.Visible = true;
                decimal quakeIndex = 0;

                string latlon = getLatLonByZipCode(zipcode);

                string[] latLonArray = latlon.Split(',');
                decimal latitude = Convert.ToDecimal(latLonArray[0]);
                decimal longitude = Convert.ToDecimal(latLonArray[1]);

                QuakeServiceClient client = new QuakeServiceClient();
                quakeIndex = client.getQuakeIndex(latitude, longitude);

                if (quakeIndex != 0 && quakeIndex > 5)
                {
                    LabelQuakeIndex.Text = "High";
                }
                else if (quakeIndex != 0 && quakeIndex > 3 && quakeIndex <= 5)
                {
                    LabelQuakeIndex.Text = "Medium";
                }
                else if (quakeIndex != 0)
                {
                    LabelQuakeIndex.Text = "Low";
                }
                else
                {
                    LabelQuakeIndex.Text = "Something went wrong in backend";
                }
            }
        }

        protected void ButtonWeatherData_Click(object sender, EventArgs e)
        {
            ListBoxWeatherData.Items.Clear();
            WeatherServiceClient client = new WeatherServiceClient();
            string zipcode = validateAndReturnZipCode();
            if (zipcode != null)
            {
                ListBoxWeatherData.Items.Add("Max_Temp   |    Min_Temp");
                try
                {
                    String[] maxTemp = client.get_maxTempData(zipcode).Split(':');
                    String[] minTemp = client.get_minTempData(zipcode).Split(':');
                    for (int i = 0; i < maxTemp.Length; i++)
                    {
                        if (maxTemp[i].Equals("-273"))
                            maxTemp[i] = "NA";
                        if (minTemp[i].Equals("-273"))
                            minTemp[i] = "NA";
                        ListBoxWeatherData.Items.Add(maxTemp[i] + "------------------------" + minTemp[i]);
                    }
                }
                catch (Exception ex)
                {
                    String output = ex.Message;
                    ListBoxWeatherData.Items.Add(output);
                }
            }
        }

        protected void ButtonNewsFocus_Click(object sender, EventArgs e)
        {
            ListBoxNewsData.Items.Clear();
            LabelNewsError.Visible = false;
            String topic = TextBoxNewsTopic.Text;
            if (topic != null && topic != "")
            {
                NewsDataServiceClient client = new NewsDataServiceClient();
                String query = topic;
                News[] output = client.getNewsDataXML(query);
                foreach (News news in output)
                {
                    ListBoxNewsData.Items.Add(news.news_URL);
                }
            }
            else
            {
                LabelNewsError.Visible = true;
                LabelNewsError.Text = "Please enter a topic";
            }
        }

        // calling a service that returns latitude,longtitude against an input zipcode 
        private string getLatLonByZipCode(string zipcode)
        {
            string latlon = "";
            LocationServicesClient client = new LocationServicesClient();
            latlon = client.getLatLonByZipCode(zipcode);
            return latlon;
        }

        // validates the zipcode and returns its value
        private string validateAndReturnZipCode()
        {
            // regular expression to check valid USA zipcodes
            Regex regex = new Regex(@"^[1-9]\d{4}$");

            string localZipCode = TextBoxZipcode.Text;
            Match match = regex.Match(localZipCode);
            if (match.Success)
            {
                LabelErrorZipcode.Visible = false;
                return localZipCode;
            }
            else
            {
                LabelErrorZipcode.Visible = true;
                LabelErrorZipcode.Text = "Invalid zip code..please enter a valid zipcode";
                localZipCode = null;
            }
            return localZipCode;
        }

        // if user logs out of the session, removing his/her information and setting the isLoggedIn flag as false
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("MemberAccount");
            Response.Redirect("~/MemberLogin.aspx");
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}