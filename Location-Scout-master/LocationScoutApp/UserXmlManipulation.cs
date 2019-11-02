using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using HashClassLibrary;

namespace LocationScoutApp
{
    public class UserXmlManipulation
    {
        private const string memberCredentialFile = "Member.xml";
        private const string staffCredentialFile = "Staff.xml";
        private const int MEMBER_XML = 1;

        public Boolean addUserCredential(String userName, String passWord, int groupFlag)
        {
            bool userCreated = false;
            string fLocation = null;
            if (groupFlag == MEMBER_XML)
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + memberCredentialFile);
            else
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + staffCredentialFile);
            if (!userExists(userName, groupFlag))
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
                        writer.WriteElementString("password", new SecretHash().getHashValue(passWord));
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
        public Boolean AuthenticateUserCredential(String userName, String passWord, int groupFlag)
        {
            bool authenticate = false;
            string fLocation = null;
            if (groupFlag == MEMBER_XML)
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + memberCredentialFile);
            else
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + staffCredentialFile);
            if (System.IO.File.Exists(fLocation) && userExists(userName, groupFlag))
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
        private static bool userExists(String userName, int groupFlag)
        {
            bool userExists = false;
            string fLocation = null;
            if (groupFlag == MEMBER_XML)
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + memberCredentialFile);
            else
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + staffCredentialFile);
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
            return userExists;
        }
    }
}
