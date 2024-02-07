using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// Class used to store the command information.
    /// </summary>
    [Serializable()]
    [XmlRoot(ElementName = Constants.ATTRIBUTE_COMMAND)]
    public class Command
    {
        #region Private Data members

        /// <summary>
        /// Used to store the start range.
        /// </summary>
        private string m_strStartRange;

        /// <summary>
        /// Used to store the end range.
        /// </summary>
        private string m_strEndRange;

        /// <summary>
        /// Used to store the command name.
        /// </summary>
        private string m_strCommandName;

        /// <summary>
        /// Used to store the search string.
        /// </summary>
        private string m_strSearchString;

        /// <summary>
        /// Used to store the replace string.
        /// </summary>
        private string m_strReplaceString;

        #endregion

        #region Public Properties

        /// <summary>
        /// Public property for start range.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_START_RANGE)]
        public string StartRange
        {
            get { return m_strStartRange; }
            set
            {
                if (value == Constants.MSG_END_OF_FILE || value == string.Empty || value == Constants.MSG_END_OF_FILE_WITH_QUOTE) //To check the value is empty or end of file.
                {
                    m_strStartRange = value;
                }
                else //If value is not empty or end of file.
                {
                    string strRange = Regex.Match(value, Constants.DIGIT_REGEX).Value;

                    if (strRange != string.Empty) //If value contains digits.
                    {
                        m_strStartRange = strRange;
                    }
                    else //If value does not contains digits.
                    {
                        m_strStartRange = value;
                    }
                }
            }
        }

        /// <summary>
        /// Public property for end range.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_END_RANGE)]
        public string EndRange
        {
            get { return m_strEndRange; }
            set
            {
                if (value == string.Empty || value == Constants.MSG_END_OF_FILE || value == Constants.MSG_END_OF_FILE_WITH_QUOTE) //If value is empty.
                {
                    m_strEndRange = value;
                }
                else if (m_strStartRange != string.Empty) //To check start range is not empty.
                {
                    //To get digits the start and end range.
                    string strSRange = Regex.Match(m_strStartRange, Constants.DIGIT_REGEX).Value;
                    string strERange = Regex.Match(value, Constants.DIGIT_REGEX).Value;

                    if (strSRange == string.Empty)
                    {
                        strSRange = Constants.MSG_START_OF_FILE;
                    }

                    if (strERange != string.Empty) //If start and end range has digits.
                    {
                        int nSRange = int.Parse(strSRange);
                        int nERange = int.Parse(strERange);

                        if (nSRange <= nERange) //To check the start range is less than end range.
                        {
                            m_strEndRange = strERange;
                        }
                        else //If star range is greater than end range.
                        {
                            throw new CustomException(ErrorCodes.EndRangeNotCorrect, Constants.MSG_END_RANGE_GREATER);
                        }
                    }
                    else //If they does not contain digits.
                    {
                        m_strEndRange = value;
                    }
                }
                else // If start range is empty.
                {
                    throw new CustomException(ErrorCodes.EndRangeNotCorrect, Constants.MSG_PROPER_START_END_RANGE);
                }
            }
        }

        /// <summary>
        /// Public property for command name.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_COMMAND_NAME)]
        public string CommandName
        {
            get { return m_strCommandName; }
            set
            {
                object objOpretion = value;

                if (Enum.IsDefined(typeof(CommandNames), objOpretion)) //To check the command name is correct.
                {
                    m_strCommandName = value;
                }
                else //If commad name is not correct.
                {
                    throw new CustomException(ErrorCodes.CommandNameNotCorrect, Constants.MSG_INVALID_COMMAND_NAME);
                }
            }
        }

        /// <summary>
        /// Public property for search string.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_SEARCH_STRING)]
        public string SearchString
        {
            get { return m_strSearchString; }
            set { m_strSearchString = value; }
        }

        /// <summary>
        /// Public property for replace string.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_REPLACE_STRING)]
        public string ReplaceString
        {
            get { return m_strReplaceString; }
            set
            {
                if (m_strSearchString != string.Empty) //If search string is not empty.
                {
                    m_strReplaceString = value;
                }
                else if (value == string.Empty) // If replace string is empty.
                {
                    m_strReplaceString = string.Empty;
                }
                else // If search shring is empty.
                {
                    throw new CustomException(ErrorCodes.ReplaceStringNotCorrect, Constants.MSG_INVALID_SEARCH_REPLACE_STRING);
                }
            }
        }

        #endregion
    }
}