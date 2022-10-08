/*
 * Program Name: LSAsignment1
 * 
 * Purpose: To be able to create a level of Sokoban, and save it to a file
 * 
 * Revision History:
 *          September 18, 2019: Created
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSudermanAssignment2
{
    public partial class SokobanControlPanel : Form
    {
        public SokobanControlPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the design form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            DesignForm DesignForm = new DesignForm();
            DesignForm.ShowDialog();
        }

        /// <summary>
        /// Shows the Play form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayForm PlayForm = new PlayForm();
            PlayForm.ShowDialog();
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
