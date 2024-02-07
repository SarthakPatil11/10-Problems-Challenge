using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// Class used for XML realeted opretions.
    /// </summary>
    internal class XMLParser
    {
        #region Public Methods

        /// <summary>
        /// Method to read the XML file.
        /// </summary>
        /// <param name="strFilePath"> To take the XML file path. </param>
        public static List<Command> ReadXML(string strFilePath)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                using (StreamReader objXMLReader = new StreamReader(strFilePath))
                {
                    //To create the serializer object with devices type.
                    XmlSerializer objXMLSerializer = new XmlSerializer(typeof(Parameter));
                    Parameter objParameter = objXMLSerializer.Deserialize(objXMLReader) as Parameter;
                    objXMLReader.Close();

                    return objParameter.Command;
                }
            }
            catch (IOException objException) //To handle the IO realeted exceptions.
            {
                throw new CustomException(ErrorCodes.IOException, $"{objException.Message}{strMethodName}");
            }
            catch (UnauthorizedAccessException objException) //To handle the unauthorized access to file.
            {
                throw new CustomException(ErrorCodes.UnauthorizedAccessException, $"{objException.Message}{strMethodName}");
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
            catch (InvalidOperationException objException) //To handle the invalid opretion exception.
            {
                if (objException.InnerException is CustomException)
                {
                    CustomException objCustomException = objException.InnerException as CustomException;
                    throw new CustomException(objCustomException.ErrorCode, $"{objException.Message}{objCustomException.Message}{strMethodName}");
                }
                else
                {
                    throw new CustomException(ErrorCodes.InvalidOperationException, $"{objException.Message}{strMethodName}");
                }
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

        #endregion
    }
}