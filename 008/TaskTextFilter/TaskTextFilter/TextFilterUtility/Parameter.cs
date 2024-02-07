using System.Collections.Generic;
using System.Xml.Serialization;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// Class used to store the multiple commands information.
    /// </summary>
    [XmlRoot(ElementName = Constants.MSG_ATTRIBUTE_PARAM)]
    public class Parameter
    {
        #region Public Properties

        /// <summary>
        /// Used to store the list of commands.
        /// </summary>
        [XmlElement(ElementName = Constants.ATTRIBUTE_COMMAND)]
        public List<Command> Command { get; set; }

        #endregion
    }
}