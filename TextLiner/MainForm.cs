// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace TextLiner
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using PublicDomain;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The buffer lines count.
        /// </summary>
        private int bufferLinesCount = 0;

        /// <summary>
        /// The file path.
        /// </summary>
        private string filePath = string.Empty;

        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

        /// <summary>
        /// The settings data path.
        /// </summary>
        private string settingsDataPath = $"{Application.ProductName}-SettingsData.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TextLiner.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Set icons */

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set PublicDomain.is tool strip menu item image
            this.freeReleasesPublicDomainisToolStripMenuItem.Image = this.associatedIcon.ToBitmap();

            /* Settings data */

            // Check for settings file
            if (!File.Exists(this.settingsDataPath))
            {
                // Create new settings file
                this.SaveSettingsFile(this.settingsDataPath, new SettingsData());
            }

            // Load settings from disk
            this.settingsData = this.LoadSettingsFile(this.settingsDataPath);
        }

        /// <summary>
        /// Handles  the minimum length button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMinLengthButtonClick(object sender, EventArgs e)
        {
            // Copy lines array to list
            IEnumerable<string> lines = this.bufferTextBox.Lines;

            // First check if must trim
            if (this.trimLinesToolStripMenuItem.Checked)
            {
                // Trim lines
                lines = lines.Select(x => x.Trim());
            }

            // Check if must remove blanks
            if (this.removeBlankLinesToolStripMenuItem.Checked)
            {
                // Remove empty lines
                lines = lines.Where(x => !string.IsNullOrEmpty(x));
            }

            // Order lines by min. length
            lines = lines.OrderBy(x => x.Length);

            // Set into text box lines
            this.bufferTextBox.Lines = lines.ToArray();

            // Set last
            this.settingsData.last = this.minLengthButton.Text;

            // TODO Reflect last [Can be made DRY]
            this.lastToolStripStatusLabel.Text = this.settingsData.last;
        }

        /// <summary>
        /// Handles  the max length button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMaxLengthButtonClick(object sender, EventArgs e)
        {
            // Copy lines array to list
            IEnumerable<string> lines = this.bufferTextBox.Lines;

            // First check if must trim
            if (this.trimLinesToolStripMenuItem.Checked)
            {
                // Trim lines
                lines = lines.Select(x => x.Trim());
            }

            // Check if must remove blanks
            if (this.removeBlankLinesToolStripMenuItem.Checked)
            {
                // Remove empty lines
                lines = lines.Where(x => !string.IsNullOrEmpty(x));
            }

            // Order text box lines by max. length
            lines = lines.OrderByDescending(x => x.Length).ToArray();

            // Set into text box lines
            this.bufferTextBox.Lines = lines.ToArray();

            // Set last
            this.settingsData.last = this.maxLengthButton.Text;

            // TODO Reflect last [Can be made DRY]
            this.lastToolStripStatusLabel.Text = this.settingsData.last;
        }

        /// <summary>
        /// Handles  the ascending button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAscendingButtonClick(object sender, EventArgs e)
        {
            // Copy lines array to list
            IEnumerable<string> lines = this.bufferTextBox.Lines;

            // First check if must trim
            if (this.trimLinesToolStripMenuItem.Checked)
            {
                // Trim lines
                lines = lines.Select(x => x.Trim());
            }

            // Check if must remove blanks
            if (this.removeBlankLinesToolStripMenuItem.Checked)
            {
                // Remove empty lines
                lines = lines.Where(x => !string.IsNullOrEmpty(x));
            }

            // Order text box lines by ascending
            lines = lines.OrderBy(x => x);

            // Set into text box lines
            this.bufferTextBox.Lines = lines.ToArray();

            // Set last
            this.settingsData.last = this.ascendingButton.Text;

            // TODO Reflect last [Can be made DRY]
            this.lastToolStripStatusLabel.Text = this.settingsData.last;
        }

        /// <summary>
        /// Handles  the descending button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDescendingButtonClick(object sender, EventArgs e)
        {
            // Copy lines array to list
            IEnumerable<string> lines = this.bufferTextBox.Lines;

            // First check if must trim
            if (this.trimLinesToolStripMenuItem.Checked)
            {
                // Trim lines
                lines = lines.Select(x => x.Trim());
            }

            // Check if must remove blanks
            if (this.removeBlankLinesToolStripMenuItem.Checked)
            {
                // Remove empty lines
                lines = lines.Where(x => !string.IsNullOrEmpty(x));
            }

            // Order text box lines by descending
            lines = lines.OrderByDescending(x => x);

            // Set into text box lines
            this.bufferTextBox.Lines = lines.ToArray();

            // Set last
            this.settingsData.last = this.descendingButton.Text;

            // TODO Reflect last [Can be made DRY]
            this.lastToolStripStatusLabel.Text = this.settingsData.last;
        }

        /// <summary>
        /// Handles  the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Clear text buffer
            this.bufferTextBox.Clear();

            // Reset file path
            this.filePath = string.Empty;

            // Reflect file path reset
            this.fileNameToolStripStatusLabel.Text = "Not set";
        }

        /// <summary>
        /// Handles  the open tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Reset file name
            this.openFileDialog.FileName = string.Empty;

            // Show open file dialog
            if (this.openFileDialog.ShowDialog() == DialogResult.OK && this.openFileDialog.FileName.Length > 0)
            {
                try
                {
                    // Read file into text box
                    this.bufferTextBox.Lines = File.ReadAllLines(this.openFileDialog.FileName);

                    // Set file path
                    this.filePath = this.openFileDialog.FileName;

                    // Reflect file name
                    this.fileNameToolStripStatusLabel.Text = Path.GetFileName(this.openFileDialog.FileName);

                    // Check if must apply last
                    if (this.applylastOnOpenToolStripMenuItem.Checked)
                    {
                        // Apply last on open
                        switch (this.settingsData.last)
                        {
                            // Min. length
                            case "M&in. length":
                                // Click button
                                this.minLengthButton.PerformClick();

                                break;

                            // Max. length
                            case "M&ax. length":
                                // Click button
                                this.maxLengthButton.PerformClick();

                                break;

                            // Ascending
                            case "&Ascending":
                                // Click button
                                this.ascendingButton.PerformClick();

                                break;

                            // Descending
                            case "&Descending":
                                // Click button
                                this.descendingButton.PerformClick();

                                break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    // Inform user
                    MessageBox.Show($"Error when opening \"{Path.GetFileName(this.openFileDialog.FileName)}\":{Environment.NewLine}{exception.Message}", "Open file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles  the save tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the save as tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the cut tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Cut operation
            this.bufferTextBox.Cut();
        }

        /// <summary>
        /// Handles  the copy tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Copy operation
            this.bufferTextBox.Copy();
        }

        /// <summary>
        /// Handles  the paste tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Paste operation
            this.bufferTextBox.Paste();
        }

        /// <summary>
        /// Handles  the select all tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSelectAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Select all operation
            this.bufferTextBox.SelectAll();
        }

        /// <summary>
        /// Handles  the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles  the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our website
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles  the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open orignal thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=43525.0");
        }

        /// <summary>
        /// Handles  the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/text-liner");
        }

        /// <summary>
        /// Handles  the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the buffer text box text changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBufferTextBoxTextChanged(object sender, EventArgs e)
        {
            // Check for a different line count
            if (this.bufferLinesCount != this.bufferTextBox.Lines.Count())
            {
                // Update buffer lines count
                this.bufferLinesCount = this.bufferTextBox.Lines.Count();

                // Update line count
                this.linesCountToolStripStatusLabel.Text = this.bufferLinesCount.ToString();
            }
        }

        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <returns>The settings file.</returns>
        /// <param name="settingsFilePath">Settings file path.</param>
        private SettingsData LoadSettingsFile(string settingsFilePath)
        {
            // Use file stream
            using (FileStream fileStream = File.OpenRead(settingsFilePath))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Return populated settings data
                return xmlSerializer.Deserialize(fileStream) as SettingsData;
            }
        }

        /// <summary>
        /// Saves the settings file.
        /// </summary>
        /// <param name="settingsFilePath">Settings file path.</param>
        /// <param name="settingsDataParam">Settings data parameter.</param>
        private void SaveSettingsFile(string settingsFilePath, SettingsData settingsDataParam)
        {
            try
            {
                // Use stream writer
                using (StreamWriter streamWriter = new StreamWriter(settingsFilePath, false))
                {
                    // Set xml serialzer
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                    // Serialize settings data
                    xmlSerializer.Serialize(streamWriter, settingsDataParam);
                }
            }
            catch (Exception exception)
            {
                // Advise user
                MessageBox.Show($"Error saving settings file.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{exception.Message}", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            /* Setiings data values */

            // ALways on top
            this.settingsData.AlwaysOnTop = this.alwaysOnTopToolStripMenuItem.Checked;

            // Apply last on open
            this.settingsData.ApplyLastOnOpen = this.applylastOnOpenToolStripMenuItem.Checked;

            // Remove blank lines
            this.settingsData.RemoveBlankLines = this.removeBlankLinesToolStripMenuItem.Checked;

            // Trim lines
            this.settingsData.TrimLines = this.trimLinesToolStripMenuItem.Checked;

            // Save settings data to disk
            this.SaveSettingsFile(this.settingsDataPath, this.settingsData);
        }

        /// <summary>
        /// Handles the main form load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Set topmost
            this.TopMost = this.settingsData.AlwaysOnTop;

            // Always on top
            this.alwaysOnTopToolStripMenuItem.Checked = this.settingsData.AlwaysOnTop;

            // Apply last on open
            this.applylastOnOpenToolStripMenuItem.Checked = this.settingsData.ApplyLastOnOpen;

            // Remove blank lines
            this.removeBlankLinesToolStripMenuItem.Checked = this.settingsData.RemoveBlankLines;

            // Trim lines
            this.trimLinesToolStripMenuItem.Checked = this.settingsData.TrimLines;

            // Reflect last
            this.lastToolStripStatusLabel.Text = this.settingsData.last;
        }

        /// <summary>
        /// Handles  the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program        
            this.Close();
        }
    }
}
