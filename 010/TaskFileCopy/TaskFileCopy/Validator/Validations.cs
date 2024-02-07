using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using TaskFileCopy.EnumHolder;
using TaskFileCopy.Helper;
using TaskFileCopy.Modals;

namespace TaskFileCopy.Validator
{
    /// <summary>
    /// Class used to perform validetions.
    /// </summary>
    internal class Validations
    {
        #region Private Methods

        /// <summary>
        /// To check the folder has spesific permision.
        /// </summary>
        /// <param name="strDirPath"> To take the folder path. </param>
        /// <param name="objRight"> To take the specific right. </param>
        /// <returns> True if directory has the permission. </returns>
        private static bool HasPermissionToDir(string strDirPath, FileSystemRights objRight)
        {
            bool bWriteAllow = false;
            bool bWriteDeny = false;

            //To get all the access control list of a file.
            DirectorySecurity objAccessControlList = Directory.GetAccessControl(strDirPath);

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
                if ((objRule.FileSystemRights & objRight) != objRight) //If spesific right is not given.
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
        /// To check the file has spesific permision.
        /// </summary>
        /// <param name="strFilePath"> To take the file path. </param>
        /// <param name="objRight"> To take the specific right. </param>
        /// <returns> True if file has the permission. </returns>
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

        #endregion

        #region Puplic Methods

        /// <summary>
        /// Method used to perform validetions on file.
        /// </summary>
        /// <param name="strReadFile"> To take file path. </param>
        /// <param name="objRight"> To take permission to check. </param>
        /// <returns> Validation Result </returns>
        public static Result PerformValidationsOnFile(string strReadFile, FileSystemRights objRight)
        {
            if (File.Exists(strReadFile)) //To check if directory exist.
            {
                if (HasPermissionToFile(strReadFile, objRight)) //To check if directory has permission.
                {
                    Result objResult = new Result(true, Constants.MIN, string.Empty);
                    return objResult;
                }
                else //If directory has no permission.
                {
                    Result objResult = new Result(false, ErrorCodes.FileHasNotPermission, Constants.MSG_FILE_HAS_NO_PERMISSION);
                    return objResult;
                }
            }
            else //If directory don't exist.
            {
                Result objResult = new Result(false, ErrorCodes.FileNotExist, Constants.MSG_PATH_NOT_EXIST);
                return objResult;
            }
        }

        /// <summary>
        /// Method used to perform validetions on folder.
        /// </summary>
        /// <param name="strFolderPath"> To take folder path. </param>
        /// <param name="objRight"> To take permission to check. </param>
        /// <returns> Validation Result </returns>
        public static Result PerformValidationsOnFolder(string strFolderPath, FileSystemRights objRight)
        {
            if (Directory.Exists(strFolderPath)) //To check if directory exist.
            {
                if (HasPermissionToDir(strFolderPath, objRight)) //To check if directory has permission.
                {
                    Result objResult = new Result(true);
                    return objResult;
                }
                else //If directory has no permission.
                {
                    Result objResult = new Result(false, ErrorCodes.DirectoryHasNotPermission, Constants.MSG_DIRECTORY_HAS_NO_PERMISSION);
                    return objResult;
                }
            }
            else //If directory don't exist.
            {
                Result objResult = new Result(false, ErrorCodes.DirectoryNotExist, Constants.MSG_PATH_NOT_EXIST);
                return objResult;
            }
        }

        #endregion
    }
}