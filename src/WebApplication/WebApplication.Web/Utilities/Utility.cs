using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Web.Utilities
{
    public static class Utility
    {

        #region Get App Settings        
        /// <summary>
        /// Gets the application settings.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public static string GetAppSettings(string keyName)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            // Add "appsettings.json" to bootstrap EF config.
            .AddJsonFile("appsettings.json")
            // Add the EF configuration provider, which will override any
            // config made with the JSON provider.
            .Build();
            var returnvalues = config[string.Format("{0}:{1}", "KeySettings", keyName)];
            return returnvalues;
        }
        #endregion

        #region Convert to bool
        public static bool GetBool(object value)
        {
            bool result = false;
            if (value != null)
            {
                bool.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Get Nullable bool
        public static bool? GetNullablebool(object value)
        {
            bool? nullableResult = null;

            bool result;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                nullableResult = bool.TryParse(value.ToString(), out result) ? result : (bool?)null;
            }

            return nullableResult;
        }
        #endregion

        #region Convert to Long
        public static long GetLong(this object value)
        {
            long result = 0;
            if (value != null)
            {
                long.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Convert to Int
        public static int GetInt(object value)
        {
            int result = 0;
            if (value != null)
            {
                int.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Convert to Byte
        public static byte GetByte(object value)
        {
            byte result = 0;
            if (value != null)
            {
                byte.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Convert To Guid
        public static Guid ConvertToGuid(object p)
        {
            Guid _retValue = Guid.Empty;
            if (p != null)
            {
                Guid.TryParse(p.ToString(), out _retValue);
            }
            return _retValue;
        }
        #endregion

        #region Convert to Short
        public static short GetShort(object value)
        {
            short result = 0;
            if (value != null)
            {
                short.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Convert to DateTime
        /// <summary>
        /// Convert to double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(object value)
        {
            DateTime result = new DateTime();
            if (value != null)
            {
                DateTime.TryParse(value.ToString(), out result);
            }
            return result;
        }
        #endregion

        #region Create Salt
        /// <summary>
        /// Creates the salt.
        /// </summary>
        /// <param name="saltSize">Size of the salt.</param>
        /// <returns></returns>
        public static string CreateSalt(int saltSize)
        {
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[saltSize];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        #endregion

        #region EncryptPassword
        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="pPassword">The password.</param>
        /// <param name="pSalt">The salt.</param>
        /// <returns></returns>
        public static string EncryptPassword(string pPassword, string pSalt)
        {
            return string.Join("", SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Concat(pPassword, pSalt))).Select(x => x.ToString("X2"))).ToLower();
        }
        #endregion

        #region Get Content Type by Extension
        /// <summary>
        /// Returns the extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns></returns>
        public static string GetContentTypeByExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case "htm":
                case "html":
                case "log":
                    return "text/HTML";
                case "txt":
                    return "text/plain";
                case "docx":
                case "doc":
                    return "application/ms-word";
                case "tiff":
                case "tif":
                    return "image/tiff";
                case "asf":
                    return "video/x-ms-asf";
                case "avi":
                    return "video/avi";
                case "zip":
                    return "application/zip";
                case "xlsx":
                case "xls":
                    return "application/xls";
                case "csv":
                    return "application/vnd.ms-excel";
                case "gif":
                    return "image/gif";
                case "jpg":
                    return "image/jpg";
                case "jpeg":
                    return "image/jpeg";
                case "bmp":
                    return "image/bmp";
                case "png":
                    return "image/png";
                case "pjpeg":
                    return "image/pjpeg";
                case "wav":
                    return "audio/wav";
                case "mp3":
                    return "audio/mpeg3";
                case "mpg":
                case "mpeg":
                    return "video/mpeg";
                case "rtf":
                    return "application/rtf";
                case "asp":
                    return "text/asp";
                case "pdf":
                    return "application/pdf";
                case "fdf":
                    return "application/vnd.fdf";
                case "pps":
                case "pptx":
                case "ppt":
                    return "application/mspowerpoint";
                case "dwg":
                    return "image/vnd.dwg";
                case "msg":
                    return "application/msoutlook";
                case "xml":
                case "sdxl":
                    return "application/xml";
                case "xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        #endregion

        #region Convert to decimal 2 Digits
        public static decimal GetDecimal2Digits(object Value)
        {
            decimal result = decimal.MinValue;
            if (Value != null)
            {
                decimal.TryParse(Value.ToString(), out result);
                result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                decimal.TryParse(result.ToString("#.00"), out result);
            }
            return result;
        }
        #endregion

        #region Convert to decimal 3 Digits
        public static decimal GetDecimal3Digits(object Value)
        {
            decimal result = decimal.MinValue;
            if (Value != null)
            {
                decimal.TryParse(Value.ToString(), out result);
                result = Math.Round(result, 3, MidpointRounding.AwayFromZero);
                decimal.TryParse(result.ToString("#.000"), out result);
            }
            return result;
        }
        #endregion

        #region Convert Time Zone
        public static DateTime ConvertTimeZone(DateTime value, string timezone)
        {
            TimeZoneInfo _estTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            DateTime _timeTobeConverted = DateTime.SpecifyKind(value, DateTimeKind.Unspecified);
            DateTime _time = TimeZoneInfo.ConvertTime(_timeTobeConverted, _estTimeZone);
            return _time;
        }
        #endregion

        #region Get Is Checked
        /// <summary>
        /// Get Is Checked
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool GetIsChecked(object value)
        {
            bool result = false;

            if (value != null)
            {
                result = value.ToString().Contains("true");
            }

            return result;
        }
        #endregion

        #region Remove special Characters from string
        public static string RemoveSpecialCharactersForTitle(string stringName)
        {
            if (!string.IsNullOrEmpty(stringName))
            {
                stringName = stringName.Replace("#", "");
                stringName = stringName.Replace("@", "");
                stringName = stringName.Replace("$", "");
                stringName = stringName.Replace("/", "");
                stringName = stringName.Replace(",", "");
                stringName = stringName.Replace("(", "");
                stringName = stringName.Replace(")", "");
                stringName = stringName.Replace(".", "");
                stringName = stringName.Replace("'", "");
                stringName = stringName.Replace("’", "");
                stringName = stringName.Replace("-", "");
                stringName = stringName.Replace("*", "");
                stringName = stringName.Replace("+", "");
                stringName = stringName.Replace("[", "");
                stringName = stringName.Replace("]", "");
                stringName = stringName.Replace("\\", "");
                stringName = stringName.Replace("\"", "");
                stringName = stringName.Replace("!", "");
                stringName = stringName.Replace("|", "");
                stringName = stringName.Replace("^", "");
                stringName = stringName.Replace("&", "");
                stringName = stringName.Replace("_", "");
                stringName = stringName.Replace("=", "");
                stringName = stringName.Replace("?", "");
                stringName = stringName.Replace("~", "");
                stringName = stringName.Replace("`", "");
                stringName = stringName.Replace(";", "");
                stringName = stringName.Replace(":", "");
            }
            return stringName;
        }
        #endregion

        #region Get Tax Year value for DropDown
        /// <summary>
        /// Get Tax Year value for DropDown
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetTaxYearsForDropDown()
        {
            var currentTaxyear = GetInt("2016");
            var dropdownitems = new List<SelectListItem>();
            for (int year = currentTaxyear; year >= currentTaxyear - 1; year--)
            {
                dropdownitems.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString(), Selected = (2016 == year) });
            }
            return dropdownitems;
        }
        #endregion

        #region Create Random Number
        /// <summary>
        /// Creating the Random Number
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            var random = new Random();
            //returns the generated Number
            return random.Next(min, max);
        }
        #endregion

        #region Remove Hiphen And Brackets
        /// <summary>
        /// Removes the hiphen.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string RemoveSpecialChars(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace("-", "");
                value = value.Replace("(", "");
                value = value.Replace(")", "");
                value = value.Replace(" ", "");
            }
            return value;
        }
        #endregion

        #region Get Full Name
        public static string GetFullName(string FirstName, string MiddleIntial, string LastName, string Suffix)
        {
            string fullName = string.Empty;

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                fullName = FirstName.Trim();
            }
            if (!string.IsNullOrWhiteSpace(MiddleIntial))
            {
                fullName += (" " + MiddleIntial.Trim());
            }
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                fullName += (" " + LastName.Trim());
            }
            if (!string.IsNullOrWhiteSpace(Suffix))
            {
                fullName += (" " + Suffix.Trim());
            }

            return !string.IsNullOrWhiteSpace(fullName) ? fullName.Trim() : string.Empty;
        }
        #endregion

        #region To Trim and Lower
        public static string ToLowerTrim(this string str)
        {
            if (str != null)
            {
                return str.Trim().ToLower();
            }
            return string.Empty;
        }
        #endregion

        #region Remove special Characters from string
        /// <summary>
        ///  Remove special Characters from string
        /// </summary>
        /// <param name="stringName"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharactersAndTrim(string stringName)
        {
            if (!string.IsNullOrEmpty(stringName))
            {
                stringName = stringName.Replace("#", "");
                stringName = stringName.Replace("@", "");
                stringName = stringName.Replace("$", "");
                stringName = stringName.Replace("/", "");
                stringName = stringName.Replace(",", "");
                stringName = stringName.Replace("(", "");
                stringName = stringName.Replace(")", "");
                stringName = stringName.Replace(".", "");
                stringName = stringName.Replace("'", "");
                stringName = stringName.Replace("’", "");
                stringName = stringName.Replace("-", "");
                stringName = stringName.Replace("*", "");
                stringName = stringName.Replace("+", "");
                stringName = stringName.Replace("[", "");
                stringName = stringName.Replace("]", "");
                stringName = stringName.Replace("\\", "");
                stringName = stringName.Replace("\"", "");
                stringName = stringName.Replace("!", "");
                stringName = stringName.Replace("|", "");
                stringName = stringName.Replace("^", "");
                stringName = stringName.Replace("&", "");
                stringName = stringName.Replace("_", "");
                stringName = stringName.Replace("=", "");
                stringName = stringName.Replace("?", "");
                stringName = stringName.Replace("~", "");
                stringName = stringName.Replace("`", "");
                stringName = stringName.Replace("%", "");
                stringName = stringName.Replace("{", "");
                stringName = stringName.Replace("}", "");
                stringName = stringName.Replace(":", "");
                stringName = stringName.Replace("<", "");
                stringName = stringName.Replace(">", "");
                stringName = stringName.Trim();
            }
            return stringName;
        }
        #endregion

        #region Get FullAddress With State
        /// <summary>
        /// Get FullAddress With State
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="statecode"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public static string GetFullAddressWithState(string address1, string address2, string city, string statecode, string zipcode)
        {
            string Fulladdress = string.Empty;
            if (!string.IsNullOrWhiteSpace(address1))
            {
                Fulladdress = address1;
            }
            if (!string.IsNullOrWhiteSpace(address2))
            {
                Fulladdress += ", " + address2;

            }
            string citystatezip = string.Empty;
            if (!string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(statecode) && !string.IsNullOrWhiteSpace(zipcode))
            {

                citystatezip = city + ", " + statecode + " " + zipcode;
            }
            if (!string.IsNullOrEmpty(Fulladdress) && !string.IsNullOrEmpty(citystatezip))
                Fulladdress = Fulladdress + ", " + citystatezip;
            return Fulladdress;
        }
        #endregion

        #region Check Empty String
        /// <summary>
        /// Compare string for empty value
        /// </summary>
        /// <param name="value">string to check empty</param>
        /// <returns>bool status</returns>
        public static bool IsStringEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }
        #endregion

        #region Stream to Byte
        /// <summary>
        ///  Stream to Byte
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static byte[] GetByteFormStream(Stream st)
        {
            var app = new byte[0];
            if (st != null)
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = st.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    app = ms.ToArray();
                }
            }
            return app;
        }
        #endregion

        #region Convert to EIN Format
        public static string GetEINFormattedString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = RemoveSpecialChars(value);
                if (value.Length == 9)
                {
                    string _string1 = value.Substring(0, 2);
                    string _string2 = value.Substring(2, 7);
                    value = _string1 + "-" + _string2;
                }
                else
                {
                    return value;
                }
            }
            return value;
        }
        #endregion

        #region Convert to SSN Format
        public static string GetSSNFormattedString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = RemoveSpecialChars(value);

                string _string1 = value.Substring(0, 3);
                string _string2 = value.Substring(3, 2);
                string _string3 = value.Substring(5, 4);
                value = _string1 + "-" + _string2 + "-" + _string3;
            }
            return value;
        }
        #endregion

        #region Convert to Phone Format
        public static string GetPhoneorFaxFormattedString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = RemoveSpecialChars(value);
                if (value.Length == 10)
                {
                    string _string1 = value.Substring(0, 3);
                    string _string2 = value.Substring(3, 3);
                    string _string3 = value.Substring(6, 4);
                    value = "(" + _string1 + ") " + _string2 + "-" + _string3;
                }
                else
                {
                    return value;
                }
            }
            return value;
        }
        #endregion

        #region Name Separation
        /// <summary>
        ///  Name Separation
        /// </summary>
        /// <param name="FullName"></param>
        /// <returns></returns>
        public static string[] NameSeparation(string FullName)
        {
            var names = new string[4];
            if (!string.IsNullOrWhiteSpace(FullName))
            {
                string[] employeeName = FullName.Split(' ');

                if (employeeName != null && employeeName.Length > 0)
                {
                    switch (employeeName.Length)
                    {
                        case 1:
                            names[2] = employeeName[0];
                            break;
                        case 2:
                            names[0] = employeeName[0];
                            names[2] = employeeName[1];
                            break;
                        case 3:
                            names[0] = employeeName[0];
                            string suffix = employeeName[2] != null ? employeeName[2].ToLower().Trim() : string.Empty;

                            if (suffix == "jr" || suffix == "sr" || suffix == "ii" || suffix == "iii"
                               || suffix == "iv" || suffix == "v" || suffix == "vi" || suffix == "vii")
                            {
                                names[3] = suffix.ToUpper();
                                names[2] = employeeName[1];
                            }
                            else
                            {
                                names[1] = employeeName[1];
                                names[2] = employeeName[2];
                            }
                            break;
                        case 4:
                            names[0] = employeeName[0];
                            names[1] = employeeName[1];
                            names[2] = employeeName[2];
                            string suffix4 = employeeName[3].ToLower().Trim().Replace(".", "").Replace(",", "");
                            if (suffix4 == "jr" || suffix4 == "sr" || suffix4 == "ii" || suffix4 == "iii"
                               || suffix4 == "iv" || suffix4 == "v" || suffix4 == "vi" || suffix4 == "vii")
                            {
                                names[3] = suffix4.ToUpper();
                            }
                            else
                            {
                                names[2] += " " + suffix4;
                            }
                            break;
                        default:
                            names[0] = employeeName[0];
                            names[1] = employeeName[1];
                            names[2] = employeeName[2];
                            string suffixD = employeeName[3].ToLower().Trim().Replace(".", "").Replace(",", "");
                            if (suffixD == "jr" || suffixD == "sr" || suffixD == "ii" || suffixD == "iii"
                               || suffixD == "iv" || suffixD == "v" || suffixD == "vi" || suffixD == "vii")
                            {
                                names[3] = suffixD.ToUpper();
                            }
                            else
                            {
                                names[2] += " " + suffixD;
                            }
                            break;
                    }
                }
            }
            return names;
        }
        #endregion

        #region Get Client IP Address
        /// <summary>
        /// Get Client IP Address
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetClientIPAddress(HttpContext context)
        {
            string ipAddress = string.Empty;

            if (context.Connection.RemoteIpAddress != null)
            {
                ipAddress = context.Connection.RemoteIpAddress.ToString();
            }
            //map IP client address
            ipAddress = context.Request.Headers["X-Forwarded-For"].ToString();

            return ipAddress;
        }
        #endregion

        #region Get String
        /// <summary>
        /// Get String
        /// </summary>
        /// <param name="value"></param>
        public static string GetString(object value)
        {
            var result = string.Empty;
            if (value != null)
            {
                result = value.ToString();
            }
            return result;
        }
        #endregion

    }
}
