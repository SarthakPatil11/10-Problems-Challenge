namespace TaskTextFilter.Helper
{
    /// <summary>
    /// Class used to declare the constants.
    /// </summary>
    internal class Constants
    {
        #region String Constants

        /// <summary>
        /// Constant used to display the start massege.
        /// </summary>
        public const string MSG_START = "Start";

        /// <summary>
        /// Constant used to display the end massege.
        /// </summary>
        public const string MSG_END = "End";

        /// <summary>
        /// Constants used to display search element.
        /// </summary>
        public const string MSG_COMMAND = "Command ";

        /// <summary>
        /// Constants used to display output.
        /// </summary>
        public const string MSG_OUTPUT = "Output: ";

        /// <summary>
        /// Constants used to display executed.
        /// </summary>
        public const string MSG_EXECUTED = "Executed.";

        /// <summary>
        /// Constants used to display not applicable.
        /// </summary>
        public const string MSG_NOT_APPLICABLE = "Not Applicable.";

        /// <summary>
        /// Constants used to display processing line.
        /// </summary>
        public const string MSG_PROCESSING_LINE = "Processing Line ";

        /// <summary>
        /// Constants used to display result.
        /// </summary>
        public const string MSG_FILNAL_RESULT = "Result: ";

        /// <summary>
        /// Constants used to display file is not xml.
        /// </summary>
        public const string MSG_FILE_NOT_CORRECT = "File is not correct file!!!";

        /// <summary>
        /// Constants used to display error message.
        /// </summary>
        public const string MSG_ERROR = "Error E";

        /// <summary>
        /// Constants used to display warning message.
        /// </summary>
        public const string MSG_WARNING = "Warning: ";

        /// <summary>
        /// Constants used to display error message.
        /// </summary>
        public const string MSG_EXCEPTION = "Exception E";

        /// <summary>
        /// Constant used to display dashed line in the output.
        /// </summary>
        public const string MSG_SEPARATOR = "---------------------------------------------------";

        /// <summary>
        /// Constant used to display LONG dashed line in the output.
        /// </summary>
        public const string MSG_LONG_SEPARATOR = "----------------------------------------------------------------------------------------------------------------------";

        /// <summary>
        /// Constants used to display enter valid range.
        /// </summary>
        public const string MSG_END_RANGE_GREATER = " End Range should be grater than or equal to Start Range!!!";

        /// <summary>
        /// Constants used to display enter valid end range.
        /// </summary>
        public const string MSG_PROPER_START_END_RANGE = " To have a End Range, Start Range should be there!!!";

        /// <summary>
        /// Constants used to display enter valid start range.
        /// </summary>
        public const string MSG_PROPER_RANGES = "Enter valid Ranges!!!";

        /// <summary>
        /// Constant used for display enter valid command.
        /// </summary>
        public const string MSG_INVALID_COMMAND_NAME = " Enter valid command name!!!";

        /// <summary>
        /// Constant used for display enter valid sreach replace string.
        /// </summary>
        public const string MSG_INVALID_SEARCH_REPLACE_STRING = " To have a Replace String, Search String should be there!!!";

        /// <summary>
        /// Constant used for display input correct paths.
        /// </summary>
        public const string MSG_CORRECT_PATH = "Input Correct Paths!!!";

        /// <summary>
        /// Constant used for display input file is empty.
        /// </summary>
        public const string MSG_FILE_EMPTY = "File is empty!!!";

        /// <summary>
        /// Constant used for declareing xml schema file name.
        /// </summary>
        public const string MSG_SCHEMA_FILE = "TaskTextFilter.Resource.XMLSchema.xsd";

        /// <summary>
        /// Constant used to declare attribute parameter.
        /// </summary>
        public const string MSG_ATTRIBUTE_PARAM = "Parameter";

        /// <summary>
        /// Constant used to declare attribute command.
        /// </summary>
        public const string ATTRIBUTE_COMMAND = "Command";

        /// <summary>
        /// Constant used to declare attribute start range.
        /// </summary>
        public const string ATTRIBUTE_START_RANGE = "StartRange";

        /// <summary>
        /// Constant used to declare attribute end range.
        /// </summary>
        public const string ATTRIBUTE_END_RANGE = "EndRange";

        /// <summary>
        /// Constant used to declare attribute command name.
        /// </summary>
        public const string ATTRIBUTE_COMMAND_NAME = "CommandName";

        /// <summary>
        /// Constant used to declare attribute search string.
        /// </summary>
        public const string ATTRIBUTE_SEARCH_STRING = "SearchString";

        /// <summary>
        /// Constant used to declare attribute replace String.
        /// </summary>
        public const string ATTRIBUTE_REPLACE_STRING = "ReplaceString";

        /// <summary>
        /// Constant used to declare valid xml massege line number.
        /// </summary>
        public const string MSG_LINE_NUM = "Line number ";

        /// <summary>
        /// Constant used to declare start of file.
        /// </summary>
        public const string MSG_START_OF_FILE = "1";

        /// <summary>
        /// Constant used to declare end of file.
        /// </summary>
        public const string MSG_END_OF_FILE = "E";

        /// <summary>
        /// Constant used to declare end of file with quote.
        /// </summary>
        public const string MSG_END_OF_FILE_WITH_QUOTE = "'E'";

        /// <summary>
        /// Constant used to declare end of file with quote.
        /// </summary>
        public const string MSG_WITH_QUOTE = "''";

        /// <summary>
        /// Constant used to show colon.
        /// </summary>
        public const string MSG_OPEN_SQUARE_BRACKET = "[";

        /// <summary>
        /// Constant used to show colon.
        /// </summary>
        public const string MSG_CLOSE_SQUARE_BRACKET = "]";

        /// <summary>
        /// Constant used to show space.
        /// </summary>
        public const string MSG_SPACE = " ";

        /// <summary>
        /// Constant used to show colon.
        /// </summary>
        public const string MSG_COLON = ": ";

        /// <summary>
        /// Constant used to show colon.
        /// </summary>
        public const string MSG_DOT = ".";

        /// <summary>
        /// Constant used to show colon.
        /// </summary>
        public const string MSG_JAP_DOT = "。";

        /// <summary>
        /// Constant used to show single quotes.
        /// </summary>
        public const string MSG_SINGLE_QUOTES = "'";

        /// <summary>
        /// Constant used to show occured in.
        /// </summary>
        public const string MSG_OCCUR_IN = " This exception occured in ";

        /// <summary>
        /// Constant used to show occured in.
        /// </summary>
        public const string MSG_METHOD = " Method.";

        /// <summary>
        /// Constant used to show constructor.
        /// </summary>
        public const string MSG_CONSTRUCTOR = " Constructor.";

        /// <summary>
        /// Constant used to declare xml extention.
        /// </summary>
        public const string MSG_XML_EXTENTION = ".xml";

        /// <summary>
        /// Constant used to declare xml extention.
        /// </summary>
        public const string MSG_TXT_EXTENTION = ".txt";

        /// <summary>
        /// Constnt used to get all the digits from string.
        /// </summary>
        public const string DIGIT_REGEX = @"\d+";

        /// <summary>
        /// Constants used to display save result.
        /// </summary>
        public const string MSG_WANT_TO_SAVE = "\nDo you want to save result [Y/N] : ";
        
        /// <summary>
        /// Constants used to display save result.
        /// </summary>
        public const string MSG_RESULT = "_Result";

        /// <summary>
        /// Consant used to display output file.
        /// </summary>
        public const string MSG_OUTPUT_FILE = "\nOutput File: ";

        /// <summary>
        /// Constant usaed to display double dashed line in the output.
        /// </summary>
        public const string MSG_DOUBLE_SEPARATOR = "\n==============================================================\n";

        /// <summary>
        /// Constant usaed to check the mode is debug.
        /// </summary>
        public const string DEBUG_MODE = "debug";

        #endregion

        #region Character Constants

        /// <summary>
        /// Constants used to declare error code zeros.
        /// </summary>
        public const char MSG_ERROR_CODE_ZEROS = '0';

        #endregion

        #region Integer Constants

        /// <summary>
        /// Constant used for declare end range.
        /// </summary>
        public const int END_RANGE = -1;

        /// <summary>
        /// Constant used for declare int zero.
        /// </summary>
        public const int MIN = 0;

        /// <summary>
        /// Constant used for declare offset.
        /// </summary>
        public const int OFFSET = 0;

        /// <summary>
        /// Constant used for declare zeroth index.
        /// </summary>
        public const int ZEROTH_IDX = 0;

        /// <summary>
        /// Constant used for declare first index.
        /// </summary>
        public const int FIRST_IDX = 1;

        /// <summary>
        /// Constant used for declare second index.
        /// </summary>
        public const int SECOND_IDX = 2;

        /// <summary>
        /// Constant used for declare incrementer one.
        /// </summary>
        public const int INCREMENTER_ONE = 1;

        /// <summary>
        /// Constant used for declare decrementer one.
        /// </summary>
        public const int DECREMENTER_ONE = 1;

        /// <summary>
        /// Constant used for declare start range.
        /// </summary>
        public const int START_RANGE = 1;

        /// <summary>
        /// Constant used for declare second frame.
        /// </summary>
        public const int SECOND_FRAME = 1;

        /// <summary>
        /// Constant used for declare min arguments.
        /// </summary>
        public const int MIN_ARGS = 2;

        /// <summary>
        /// Constant used for declare mode argument.
        /// </summary>
        public const int MODE_ARG = 3;

        /// <summary>
        /// Constant used for declare number of zeros.
        /// </summary>
        public const int NUM_OF_ZEROS = 5;

        #endregion
    }
}