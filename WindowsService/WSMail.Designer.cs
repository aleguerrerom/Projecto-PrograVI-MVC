namespace WindowsService
{
    partial class WSMail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BW_SW = new System.ComponentModel.BackgroundWorker();
            this.T_SW = new System.Windows.Forms.Timer(this.components);
            // 
            // BW_SW
            // 
            this.BW_SW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_SW_DoWork);
            this.BW_SW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_SW_ProgressChanged);
            this.BW_SW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_SW_RunWorkerCompleted);
            // 
            // T_SW
            // 
            this.T_SW.Enabled = true;
            this.T_SW.Tick += new System.EventHandler(this.T_SW_Tick);
            // 
            // WSMail
            // 
            this.ServiceName = "Service1";

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BW_SW;
        private System.Windows.Forms.Timer T_SW;
    }
}
