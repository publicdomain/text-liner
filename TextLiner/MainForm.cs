﻿// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace TextLiner
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The buffer lines count.
        /// </summary>
        int bufferLinesCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TextLiner.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
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
        }

        /// <summary>
        /// Handles  the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the open tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
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
            // TODO Add code
        }

        /// <summary>
        /// Handles  the copy tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
        }

        /// <summary>
        /// Handles  the paste tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the select all tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSelectAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
        }

        /// <summary>
        /// Handles  the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
        }

        /// <summary>
        /// Handles  the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles  the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
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
        /// Handles  the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code 
        }
    }
}
