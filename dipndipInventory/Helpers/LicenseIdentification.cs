using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Management;
using System.Xml;
using System.Security.Cryptography;
using System.IO;

//namespace Licenser
using md5crypt;
using System.Windows;
namespace dipndipInventory.Helpers
{
    public class LicenseIdentification
    {
        /// <summary>
        /// Enumerates the type of the license file may hold one of the following values:
        /// Demo - A demonstration version. Computer ID is not checked
        /// NodeLocked - A license for specific node
        /// </summary>
        public enum LicenseType
        {
            Demo,
            NodeLocked
        } ;

        /// <summary>
        /// Holds information about a single feature:
        /// A feature is an application part that is licensed. for Example, A flight simulator
        /// without dogfights will be featured as "BASIC" while the dogfight capability will be 
        /// featured as "DOG-FIGHTS"
        /// featureName - The feature's name
        /// timeDepend - is the feature expires
        /// expiration - The feture expiration time
        /// </summary>
        public struct FeatureInfo
        {
            public string featureName;
            public bool timeDepend;
            //public DateTime expiration;
            public string expiration;
            public int maxCount; // Ignored - for future use
        };
        /// <summary>
        /// Information for the whole license
        /// </summary>
        public struct LicenseInfo
        {
            public LicenseType kind;
            public string computerID;
            public string passCode;
            public FeatureInfo[] features;
        };

        /// <summary>
        /// Returns the computer identification string
        /// </summary>
        /// <returns>Computer ID String</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public static string GetComputerId1()
        {
            String serial = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject mo in moc)
                {
                    serial = mo["SerialNumber"].ToString();
                }
                return serial;
            }
            catch (Exception) { return serial; }
        }

        public static string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {

                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }

            }
            return result;
        }
        public static string GetComputerId()
        {
            string _sysinfo = string.Empty;

            ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mob in mo.Get())
            {

                try
                {
                    _sysinfo += mob["ProcessorId"].ToString() + " ";
                }
                catch (Exception ex)
                {
                    // handle exception
                    _sysinfo = ex.Message;
                }

            }

            string modelNo = identifier("Win32_DiskDrive", "Model");
            string manufatureID = identifier("Win32_DiskDrive", "Manufacturer");
            string signature = identifier("Win32_DiskDrive", "Signature");
            string totalHeads = identifier("Win32_DiskDrive", "TotalHeads");
            //signature = identifier("Win32_BIOS", "IdentificationCode")
            //+ identifier("Win32_BIOS", "SerialNumber");
            //_sysinfo = "Processor ID: " + _sysinfo + ", HDD Model# " + modelNo + ", HDD Man ID: " + manufatureID + ", HDD Signature: " + signature + ", HDD Total Heads: " + totalHeads + ", MotherBoard ID: " + getMotherBoardID();

            _sysinfo = signature;


            //_sysinfo = String.Format("MotherBoard ID: {0}", getMotherBoardID());
            return _sysinfo;
        }

        public string GetSystemId()
        {
            string _sysinfo = string.Empty;

            ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mob in mo.Get())
            {

                try
                {
                    _sysinfo += mob["ProcessorId"].ToString() + " ";
                }
                catch (Exception ex)
                {
                    // handle exception
                    _sysinfo = ex.Message;
                }

            }

            string modelNo = identifier("Win32_DiskDrive", "Model");
            string manufatureID = identifier("Win32_DiskDrive", "Manufacturer");
            string signature = identifier("Win32_DiskDrive", "Signature");
            string totalHeads = identifier("Win32_DiskDrive", "TotalHeads");
            signature = identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber");
            //_sysinfo = "Processor ID: " + _sysinfo + ", HDD Model# " + modelNo + ", HDD Man ID: " + manufatureID + ", HDD Signature: " + signature + ", HDD Total Heads: " + totalHeads + ", MotherBoard ID: " + getMotherBoardID();

            _sysinfo = signature;


            //_sysinfo = String.Format("MotherBoard ID: {0}", getMotherBoardID());
            return _sysinfo;
        }

        public string GetSystemHDId()
        {
            string _sysinfo = string.Empty;

            ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mob in mo.Get())
            {

                try
                {
                    _sysinfo += mob["ProcessorId"].ToString() + " ";
                }
                catch (Exception ex)
                {
                    // handle exception
                    _sysinfo = ex.Message;
                }

            }

            string modelNo = identifier("Win32_DiskDrive", "Model");
            string manufatureID = identifier("Win32_DiskDrive", "Manufacturer");
            string signature = identifier("Win32_DiskDrive", "Signature");
            string totalHeads = identifier("Win32_DiskDrive", "TotalHeads");
            
            //_sysinfo = "Processor ID: " + _sysinfo + ", HDD Model# " + modelNo + ", HDD Man ID: " + manufatureID + ", HDD Signature: " + signature + ", HDD Total Heads: " + totalHeads + ", MotherBoard ID: " + getMotherBoardID();

            _sysinfo = signature;


            //_sysinfo = String.Format("MotherBoard ID: {0}", getMotherBoardID());
            return _sysinfo;
        }


        /// <summary>
        /// Checks if a feature license is valid
        /// </summary>
        /// <param name="licensePath">Full path to license file</param>
        /// <param name="featureName">Name of feature to check</param>
        /// <param name="passCode">Passcode - A token between the client and the server</param>
        /// <param name="bThrow">Throw exception in case of failure</param>
        /// <returns></returns>
        public bool IsValid(string licensePath, string featureName, string passCode, bool bThrow)
        {
            string licenseSignature;
            LicenseInfo licenseInformation = GetLicenseFromFile(licensePath, passCode, out licenseSignature);
            //licenseInformation.computerID = GetComputerId();
            licenseInformation.computerID = Crypto.DecryptStringAES(GetComputerId(), GlobalVariables.sharedSecret);
            licenseInformation.features[0].expiration = Crypto.DecryptStringAES(licenseInformation.features[0].expiration, GlobalVariables.sharedSecret);
            licenseInformation.features[0].featureName = Crypto.DecryptStringAES(licenseInformation.features[0].featureName, GlobalVariables.sharedSecret);
            
            string signature = CreateSignature(licenseInformation);
            if (signature != licenseSignature)
            {
                if (bThrow)
                {
                    throw (new LicenseException("License information does not match it's signature"));
                }
                return false;
            }

            if (licenseInformation.kind == LicenseType.NodeLocked)
            {
                if (licenseInformation.computerID != GetComputerId())
                {
                    if (bThrow)
                    {
                        throw (new LicenseException("License is customed to a different computer"));
                    }
                    return false;
                }
            }

            foreach (FeatureInfo feature in licenseInformation.features)
            {
                if (feature.featureName == featureName)
                {
                    if (feature.timeDepend)
                    {
                        //if (DateTime.Now > feature.expiration)
                        if (DateTime.Now > Convert.ToDateTime(feature.expiration))
                        {
                            if (bThrow)
                            {
                                throw (new LicenseException("Feature has been expired"));
                            }
                            return false;
                        }
                    }
                    return true;
                }
            }

            if (bThrow)
            {
                throw (new LicenseException("Feature not found"));
            }
            return false;
        }

        public string LicenseIsValid(string licensePath, string featureName, string passCode, bool bThrow)
        {
            string result = "false";
            string licenseSignature;
            LicenseInfo licenseInformation = GetLicenseFromFile(licensePath, passCode, out licenseSignature);
            licenseInformation.computerID = GetComputerId();
            //MessageBox.Show(licenseInformation.computerID.ToString());
            //if (licenseInformation.computerID == "D1N0BC27397905F")

            //if(!string.Equals(licenseInformation.computerID,"D1N0BC27397905F"))
            //{
            //    //MessageBox.Show(licenseInformation.computerID.ToString());
            //    return result;
            //}

            //licenseInformation.computerID = Crypto.DecryptStringAES(GetComputerId(), GlobalVariables.sharedSecret);
            //licenseInformation.features[0].expiration = Crypto.DecryptStringAES(licenseInformation.features[0].expiration, GlobalVariables.sharedSecret);
            //licenseInformation.features[0].expiration = licenseInformation.features[0].expiration;
            //licenseInformation.features[0].featureName = Crypto.DecryptStringAES(licenseInformation.features[0].featureName, GlobalVariables.sharedSecret);

            if (licenseInformation.passCode == string.Empty)
                return "false";

            string signature = CreateSignature(licenseInformation);
            if (signature != licenseSignature)
            {
                if (bThrow)
                {
                    //throw (new LicenseException("License information does not match it's signature"));
                    //return "License information does not match it's signature";
                    //MessageBox.Show("License information does not match it's signature");
                    //return "false";
                    return result;
                }
                //return false;
                //return "false";
                return result;
            }

            if (licenseInformation.kind == LicenseType.NodeLocked)
            {
                if (licenseInformation.computerID != GetComputerId())
                {
                    if (bThrow)
                    {
                        //throw (new LicenseException("License is customed to a different computer"));
                        //return "License is customed to a different computer";
                        //MessageBox.Show("License is customed to a different computer");
                        //return "false";
                        return result;
                    }
                    //return false;
                    //return "false";
                    return result;
                }
            }

            foreach (FeatureInfo feature in licenseInformation.features)
            {
                if (feature.featureName == featureName)
                {
                    if (feature.timeDepend)
                    {
                        //if (DateTime.Now > feature.expiration)
                        if (DateTime.Now > Convert.ToDateTime(feature.expiration))
                        {
                            if (bThrow)
                            {
                                //throw (new LicenseException("Feature has been expired"));
                                //return "Feature has been expired";
                                //MessageBox.Show("Feature has been expired");
                                //return "false";
                                return result;
                            }
                            //return false;
                            //return "false";
                            return result;
                        }
                    }
                    //return true;
                    //return "true";
                    result = "true";
                    return result;
                }
            }

            if (bThrow)
            {
                //throw (new LicenseException("Feature not found"));
                //return "Feature not found";
                //return "false";
                return result;
            }
            //return false;
            //return "false";
            return result;
        }

        LicenseInfo GetLicenseFromFile(string licensePath, string passCode, out string signature)
        {
            XmlDocument xdoc = new XmlDocument();

            LicenseInfo licenseInformation;

            if (File.Exists(licensePath))
            {
                xdoc.Load(licensePath);
                licenseInformation.kind =
                    (LicenseType)Enum.Parse(
                        typeof(LicenseType),
                        xdoc.DocumentElement["LicenseType"].InnerText,
                        true);
                //licenseInformation.computerID = xdoc.DocumentElement["ComputerId"].InnerText;
                licenseInformation.computerID = Crypto.DecryptStringAES(xdoc.DocumentElement["ComputerId"].InnerText, GlobalVariables.sharedSecret);
                licenseInformation.passCode = Crypto.DecryptStringAES(passCode, GlobalVariables.sharedSecret);
                int nFeatures = xdoc.DocumentElement["Features"].GetElementsByTagName("Feature").Count;
                licenseInformation.features = new FeatureInfo[nFeatures];
                XmlElement elem = (XmlElement)xdoc.DocumentElement["Features"].FirstChild;
                for (int i = 0; i < nFeatures; i++)
                {
                    licenseInformation.features[i].featureName =Crypto.DecryptStringAES(elem.Attributes["Name"].Value, GlobalVariables.sharedSecret);
                    licenseInformation.features[i].timeDepend =
                        XmlConvert.ToBoolean(elem.Attributes["IsTimeDepended"].Value);
                    if (licenseInformation.features[i].timeDepend)
                    {
                        //licenseInformation.features[i].expiration =
                        //    Convert.ToDateTime(
                        //    elem.Attributes["Expiration"].Value);
                        licenseInformation.features[i].expiration =
                            
                            Crypto.DecryptStringAES(elem.Attributes["Expiration"].Value, GlobalVariables.sharedSecret);
                    }
                    elem = (XmlElement)elem.NextSibling;
                }
                signature = xdoc.DocumentElement["Signature"].InnerText;
            }
            else
            {
                licenseInformation.kind =
                    (LicenseType)Enum.Parse(
                        typeof(LicenseType),
                        "1",
                        true);
                licenseInformation.computerID = null;
                licenseInformation.passCode = string.Empty;
                licenseInformation.features = new FeatureInfo[1];
                licenseInformation.features[0].featureName = string.Empty;
                licenseInformation.features[0].timeDepend = true;
                signature = string.Empty;
            }
            return licenseInformation;
        }

        public string CreateSignature(LicenseInfo licenseInformation)
        {
            SHA384Managed shaM = new SHA384Managed();
            byte[] data;

            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)licenseInformation.kind);
            if (licenseInformation.kind == LicenseType.NodeLocked)
            {
                bw.Write(licenseInformation.computerID);
            }
            bw.Write(licenseInformation.passCode);
            foreach (FeatureInfo feature in licenseInformation.features)
            {
                bw.Write(feature.featureName);
                bw.Write(feature.timeDepend);
                if (feature.timeDepend)
                {
                    bw.Write(feature.expiration.ToString());
                }
                bw.Write(feature.maxCount);
            }
            int nLen = (int)ms.Position + 1;
            bw.Close();
            ms.Close();
            data = ms.GetBuffer();

            data = shaM.ComputeHash(data, 0, nLen);

            string result = "";
            foreach (byte dbyte in data)
            {
                result += dbyte.ToString("X2");
            }
            return result;
        }

        public class LicenseException : System.Exception
        {
            public LicenseException(string message)
                : base(message)
            {
            }
        }
    }
}
