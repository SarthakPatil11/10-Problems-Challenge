using System;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;
using TaskFileCopy.FileOpration;
using TaskFileCopy.Helper;
using TaskFileCopy.Modals;
using TaskFileCopy.Validator;

namespace TaskFileCopy
{
    public partial class FileCopyForm : Form
    {
        #region Private Data Members

        /// <summary>
        /// To store the instance of FileCopy.
        /// </summary>
        private FileCopy m_objFileCopy;

        /// <summary>
        /// To store the instance of the Copythread.
        /// </summary>
        private Thread m_objCopyThread;

        /// <summary>
        /// To store the einitial directory.
        /// </summary>
        private string m_strInitialDirectory = Constants.MSG_INITIAL_DIRECTORY;

        private ManualResetEvent objResetEvent = new ManualResetEvent(false);

        private string m_strWriteFilePath;

        private bool bStop = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// To store the manual reset event.
        /// </summary>
        public ManualResetEvent ResetEvent
        {
            get { return objResetEvent; }
        }

        public bool Stop
        {
            get { return bStop; }
        }

        #endregion

        #region Public Constructor

        /// <summary>
        /// Constructor to initalize form.
        /// </summary>
        public FileCopyForm()
        {
            InitializeComponent();
            FormClosed += Form_FormClosing;
            m_objFileCopy = new FileCopy(this);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Used to updating the controls.
        /// </summary>
        /// <param name="nProgress"> To take the progressbar's value. </param>
        /// <param name="strLabel"> TO take the label's value. </param>
        private void ShowUpdates(int nProgress, string strLabel)
        {
            if (!ResetEvent.WaitOne(0))
            //if (bStop == false)
            {
                lblStatus.Invoke(new MethodInvoker(delegate () { lblStatus.Text = strLabel; }));
                progbarFileCopy.Invoke(new MethodInvoker(delegate () { progbarFileCopy.Value = nProgress; }));
            }
        }

        /// <summary>
        /// Used to hide or show the progress window.
        /// </summary>
        /// <param name="bHide"> To take the hide or not. </param>
        private void ProgressWindow(bool bHide)
        {
            btnStart.Visible = bHide;
            btnCancel.Visible = !bHide;

            btnSelectFile.Enabled = bHide;
            SelectFolder.Enabled = bHide;

            lblSource.Enabled = bHide;
            lblDestinition.Enabled = bHide;

            tbxSource.Enabled = bHide;
            tbxDestinition.Enabled = bHide;

            if (bHide) //To check the progress window is hidden.
            {
                Size = new Size(Constants.ININTIAL_FORM_WIDTH, Constants.ININTIAL_FORM_HEIGHT);
            }
            else //If the progress window is hidden.
            {
                Size = new Size(Constants.ININTIAL_FORM_WIDTH, Constants.INCREASED_FORM_HEIGHT);
            }
        }

        /// <summary>
        /// Used to handle the start button click event.
        /// </summary>
        /// <param name="objSender"> To take the sender object. </param>
        /// <param name="objEventArgs"> To take the event arguments. </param>
        private void StartBtn_Click(object objSender, EventArgs objEventArgs)
        {
            //To get the paths.
            string strReadFilePath = tbxSource.Text;
            string strFileName = Path.GetFileName(tbxSource.Text);
            string strWriteFolderPath = tbxDestinition.Text;
            m_strWriteFilePath = Path.Combine(strWriteFolderPath, strFileName);

            Result objReadFileResult = Validations.PerformValidationsOnFile(strReadFilePath, FileSystemRights.Read);
            if (objReadFileResult.IsSuccess) //To check the validation on read file is success.
            {
                Result objWriteFolderResult = Validations.PerformValidationsOnFolder(strWriteFolderPath, FileSystemRights.Write);
                if (objWriteFolderResult.IsSuccess) //To check the validation on write folder is success.
                {
                    //TO initialize the copy thread.
                    m_objCopyThread = new Thread(() =>
                    {
                        m_objFileCopy.Copy(strReadFilePath, m_strWriteFilePath, ShowUpdates);
                    });

                    ProgressWindow(false);

                    m_objCopyThread.Start();
                }
                else // If read folder is not valid.
                {
                    Display.ShowErrorDialog(this, objWriteFolderResult.ErrorMessage, objWriteFolderResult.ErrorCode);
                }
            }
            else // If read folder is not valid.
            {
                Display.ShowErrorDialog(this, objReadFileResult.ErrorMessage, objReadFileResult.ErrorCode);
            }
        }

        /// <summary>
        /// Used to cancel the coping opretion.
        /// </summary>
        /// <param name="objSender"> To take the sender object. </param>
        /// <param name="objEventArgs"> To take the event arguments. </param>
        private void CancelBtn_Click(object objSender, EventArgs objEventArgs)
        {
            //To abort thre thread and hide the progress window.
            if (m_objCopyThread != null && m_objCopyThread.IsAlive) //To check the thread is alive.
            {
                objResetEvent.Set();
                //bStop = true;

                m_objCopyThread.Join();

                File.Delete(m_strWriteFilePath);
            }

            ProgressWindow(true);

            tbxSource.Text = string.Empty;
            tbxDestinition.Text = string.Empty;
        }

        /// <summary>
        /// Used to select file.
        /// </summary>
        /// <param name="objSender"> To take the sender object. </param>
        /// <param name="objEventArgs"> To take the event arguments. </param>
        private void SelectFileBtn_Click(object objSender, EventArgs objEventArgs)
        {
            //To file dialog and set some settings.
            OpenFileDialog objOpenFileDialog = new OpenFileDialog
            {
                Title = Constants.MSG_SELECT_FILE,
                InitialDirectory = m_strInitialDirectory,
                Filter = Constants.MSG_FILTER,
                FilterIndex = 1,
                Multiselect = false
            };
            objOpenFileDialog.ShowDialog();

            if (objOpenFileDialog.FileName != string.Empty) //To check file is not selected.
            {
                m_strInitialDirectory = Path.GetDirectoryName(objOpenFileDialog.FileName);
                tbxSource.Text = objOpenFileDialog.FileName;
            }
        }

        /// <summary>
        /// Used to select folder.
        /// </summary>
        /// <param name="objSender"> To take the sender object. </param>
        /// <param name="objEventArgs"> To take the event arguments. </param>
        private void SelectFolderBtn_Click(object objSender, EventArgs objEventArgs)
        {
            FolderBrowserDialog objFolderBrowserDialog = new FolderBrowserDialog();

            if (objFolderBrowserDialog.ShowDialog() == DialogResult.OK) //To check if dialog is returing OK.
            {
                if (objFolderBrowserDialog.SelectedPath != string.Empty) //To check folder is not selected.
                {
                    tbxDestinition.Text = objFolderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Used to close the form.
        /// </summary>
        /// <param name="objSender"> To take the sender object. </param>
        /// <param name="objEventArgs"> To take the event arguments. </param>
        private void Form_FormClosing(object objSender, EventArgs objEventArgs)
        {
            //To abort thre thread.
            if (m_objCopyThread != null && m_objCopyThread.IsAlive) //To check the thread is alive.
            {
                objResetEvent.Set();

                //m_objCopyThread.Join();

                File.Delete(m_strWriteFilePath);
            }
        }

        #endregion
    }
}