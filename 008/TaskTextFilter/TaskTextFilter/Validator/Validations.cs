using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml;
using System.Xml.Schema;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;
using TaskTextFilter.Modal;

namespace TaskTextFilter.Validator
{
    /// <summary>
    /// Class used to perform validetions.
    /// </summary>
    internal class Validations
    {
        #region Private Methods

        /// <summary>
        /// Method used as callback to handle the validation event.
        /// </summary>
        /// <param name="objSender"> To take sender object. </param>
        /// <param name="objValidatoinEvent"> To take the validation event. </param>
        /// <exception cref="XmlSchemaValidationException"> To handle the xml schema validation exception. </exception>
        private static void ValidationEventHandler(object objSender, ValidationEventArgs objValidatoinEvent)
        {
            string strmassege = $"{Constants.MSG_LINE_NUM}{objValidatoinEvent.Exception.LineNumber}{Constants.MSG_COLON}{objValidatoinEvent.Message}";
            switch (objValidatoinEvent.Severity)
            {
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException(strmassege);

                case XmlSeverityType.Warning:
                    Display.ShowWarning(strmassege);
                    break;
            }
        }

        /// <summary>
        /// To check the file has spesific permision.
        /// </summary>
        /// <param name="strFilePath"> To take the file path. </param>
        /// <param name="objRight"> To take the specific right. </param>
        /// <returns></returns>
        private static bool HasPermissionToFile(string strFilePath, FileSystemRights objRight)
        {
            bool bWriteAllow = false;
            bool bWriteDeny = false;

            //To get all the access control list of a file.
            FileSecurity objAccessControlList = File.GetAccessControl(strFilePath);

            if (objAccessControlList == null) //If the access control list is null.
            {
                return false;
            }

            //To get teh access rules.
            AuthorizationRuleCollection objAccessRules = objAccessControlList.GetAccessRules(true, true, typeof(SecurityIdentifier));

            if (objAccessRules == null) //If the access rules is null.
            {
                return false;
            }

            //To go through the each file access rule.
            foreach (FileSystemAccessRule objRule in objAccessRules)
            {
                if (((objRule.FileSystemRights & objRight) != objRight) && objRule.AccessControlType == AccessControlType.Allow) //If spesific right is not given.
                {
                    continue;
                }

                if (objRule.AccessControlType == AccessControlType.Allow) //If the access control type is allow.
                {
                    bWriteAllow = true;
                }
                else if (objRule.AccessControlType == AccessControlType.Deny) //If the access control type is deny.
                {
                    bWriteDeny = true;
                }
            }

            bool bHasPermission = bWriteAllow && !bWriteDeny;

            return bHasPermission;
        }

        /// <summary>
        /// Method is used to check the file is empty.
        /// </summary>
        /// <param name="strFilePath"> To get the file path. </param>
        /// <returns> True is file is empty otherwise false. </returns>
        private static bool IsEmptyFile(string strFilePath)
        {
            long lSize = new FileInfo(strFilePath).Length;
            if (lSize <= Constants.MIN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method used to validate the XML file with schema.
        /// </summary>
        /// <param name="strFilePath"> To validate the File path. </param>
        /// <return> True if XML is valid. </return>
        /// <exception cref="CustomException"> To throw the cutom exception. </exception>
        private static bool ValidateXML(string strFilePath)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                //To get the XSD file path.
                Assembly objAssembly = Assembly.GetExecutingAssembly();
                using (Stream objSchemaStream = objAssembly.GetManifestResourceStream(Constants.MSG_SCHEMA_FILE))
                {
                    //For reading the schema.
                    using (XmlReader objSchemaReader = XmlReader.Create(objSchemaStream))
                    {
                        //For setting the XML reader settings.
                        XmlReaderSettings objXMLSettings = new XmlReaderSettings();

                        //Adding the scheam.
                        objXMLSettings.Schemas.Add(string.Empty, objSchemaReader);
                        objXMLSettings.ValidationType = ValidationType.Schema;
                        objXMLSettings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                        //For validating the XML as per schema.
                        using (XmlReader objReader = XmlReader.Create(strFilePath, objXMLSettings))
                        {
                            XmlDocument objDocument = new XmlDocument();
                            objDocument.Load(objReader);
                        }

                        return true;
                    }
                }
            }
            catch (IOException objException) //To handle the IO realeted exceptions.
            {
                throw new CustomException(ErrorCodes.IOException, $"{objException.Message}{strMethodName}");
            }
            catch (XmlSchemaValidationException objException) //To handle the xml schema validation exception.
            {
                throw new CustomException(ErrorCodes.XmlSchemaValidationException, $"{objException.Message}{strMethodName}");
            }
            catch (XmlSchemaException objException) //To handle the xml realeted exceptions.
            {
                throw new CustomException(ErrorCodes.XmlSchemaException, $"{objException.Message}{strMethodName}");
            }
            catch (XmlException objException) //To handle the xml realeted exceptions.
            {
                throw new CustomException(ErrorCodes.XmlException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentException objException) //To handle the argumnet exception.
            {
                throw new CustomException(ErrorCodes.ArgumentException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If thre is nay other exception occured.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}", objException);
            }
        }

        /// <summary>
        /// Method to check if file exist or not.
        /// </summary>
        /// <param name="strFilePath"> To take the file path. </param>
        /// <returns> True if exists else false. </returns>
        private static bool FileExists(string strFilePath)
        {
            bool bExist = File.Exists(strFilePath);
            return bExist;
        }

        /// <summary>
        /// Method to check if file has spesific extention.
        /// </summary>
        /// <param name="strFilePath"> To get ti file path. </param>
        /// <param name="strExtention"> To get the extention. </param>
        /// <returns> True if file has that edxtention else false. </returns>
        private static bool FileHasExtention(string strFilePath, string strExtention)
        {
            bool bHasExtention = Path.GetExtension(strFilePath).ToLower() == strExtention;
            return bHasExtention;
        }

        #endregion

        #region Puplic Methods

        /// <summary>
        /// Method used to perform validetions on file.
        /// </summary>
        /// <param name="strFilePath"> To take file path. </param>
        /// <param name="objRight"> To take permission to check. </param>
        /// <returns> Validation Result </returns>
        /// <exception cref="CustomException"> To throws the cutom exception. </exception>
        public static Result PerformValidationsOnFile(string strFilePath, FileSystemRights objRight, string strExtention)
        {
            if (!FileExists(strFilePath)) //If directory don't exist.
            {
                Result objResultFileExist = new Result(false, ErrorCodes.FileNotExist, Constants.MSG_CORRECT_PATH);
                return objResultFileExist;
            }

            if (!FileHasExtention(strFilePath, strExtention)) //If file is not xml file.
            {
                Result objResultFileNotCorrect = new Result(false, ErrorCodes.FileIsNotCorrect, Constants.MSG_FILE_NOT_CORRECT);
                return objResultFileNotCorrect;
            }

            if (!HasPermissionToFile(strFilePath, objRight)) //If directory has no permission.
            {
                Result objResultFileNotPermission = new Result(false, ErrorCodes.FileHasNotPermission, Constants.MSG_CORRECT_PATH);
                return objResultFileNotPermission;
            }

            if (IsEmptyFile(strFilePath)) //If file is empty.
            {
                Result objResultFileEmpty = new Result(false, ErrorCodes.FileIsEmpty, Constants.MSG_FILE_EMPTY);
                return objResultFileEmpty;
            }

            if (strExtention == Constants.MSG_XML_EXTENTION) //To run the XML schema validation on the XML file only.
            {
                ValidateXML(strFilePath);
            }

            Result objResult = new Result(true, Constants.MIN, string.Empty);
            return objResult;
        }

        #endregion
    }
}