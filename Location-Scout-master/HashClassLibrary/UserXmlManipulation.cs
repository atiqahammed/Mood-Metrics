using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Web;

namespace HashClassLibrary
{
    public class UserXmlManipulation
    {
        private const string location = @"C:\Users\Siddharth\Dropbox\$Study\Fall 2015\CSE 598 DSOD\Assignments\Assignment 5\Assignment 5 Studio Workspace\LocationScoutApp\LocationScoutApp\App_Data\";
        private const string fileName = "Member.xml";
       
        public Boolean addUserCredential(String userName, String passWord)
        {
   //       string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\account.xml");
            bool userCreated = false;
            string fLocation = Path.Combine(location + fileName);
            if (!userExists(userName))
            {
                if (File.Exists(fLocation))
                {
                    FileStream fStream = null;
                    try
                    {
                        fStream = new FileStream(fLocation, FileMode.Open, FileAccess.ReadWrite);
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fStream);
                        XmlNode root = doc.SelectSingleNode("credentials");
                        XmlNode userNode = doc.CreateNode(XmlNodeType.Element, "user", null);
                        XmlNode usernameNode = doc.CreateNode(XmlNodeType.Element, "username", null);
                        XmlNode passwordNode = doc.CreateNode(XmlNodeType.Element, "password", null);
                        usernameNode.InnerText = userName;
                        passwordNode.InnerText = new SecretHash().getHashValue(passWord);
                        userNode.AppendChild(usernameNode);
                        userNode.AppendChild(passwordNode);
                        root.AppendChild(userNode);
                        fStream.Position = 0;
                        doc.Save(fStream);
                        fStream.Close();
                        userCreated = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    FileStream fStream = null;
                    try
                    {
                        fStream = new FileStream(fLocation, FileMode.CreateNew, FileAccess.ReadWrite);
                        XmlTextWriter writer = new XmlTextWriter(fStream, System.Text.Encoding.Unicode);
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement("credentials");
                        writer.WriteStartElement("user");
                        writer.WriteElementString("username", userName);
                        writer.WriteElementString("password", passWord);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        userCreated = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        fStream.Close();
                    }
                }
            }
            return userCreated;
        }
        public Boolean AuthenticateUserCredential(String userName, String passWord)
        {
            bool authenticate = false;
            string fLocation = Path.Combine(location + fileName);
            if (System.IO.File.Exists(fLocation) && userExists(userName))
            {
                SecretHash hash = new SecretHash();
                String passwordHash = hash.getHashValue(passWord);
                FileStream fStream = new FileStream(fLocation, FileMode.Open);
                XmlDocument doc = new XmlDocument();
                doc.Load(fStream);
                fStream.Close();
                XmlNodeList nodeList = doc.SelectNodes("/credentials/user/username");
                foreach (XmlNode node in nodeList)
                {
                    if (node.InnerText.Equals(userName) && node.NextSibling.InnerText.Equals(passwordHash))
                        authenticate = true;
                }
            }
            return authenticate;
        }
        private static bool userExists(String userName)
        {
            bool userExists = false;
            string fLocation = Path.Combine(location + fileName);
            if (File.Exists(fLocation))
            {
                try
                {
                    FileStream fStream = new FileStream(fLocation, FileMode.Open);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fStream);
                    fStream.Close();
                    XmlNodeList nodeList = doc.SelectNodes("/credentials/user/username");
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.InnerText.Equals(userName))
                            userExists = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                userExists = true;
            }
            return userExists;
        }
    }
}
