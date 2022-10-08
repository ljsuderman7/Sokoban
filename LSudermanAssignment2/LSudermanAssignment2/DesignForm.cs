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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSudermanAssignment2
{
    public partial class DesignForm : Form
    {
        const int LEFT = 150;
        const int TOP = 150;
        const int WIDTH = 50;
        const int HEIGHT = 50;
        const int VERTICLE_GAP = 5;
        const int HORIZONTAL_GAP = 5;
        int rows = 0;
        int columns = 0;
        ToolSelected toolSelected = ToolSelected.NONE;

        public DesignForm()
        {
            InitializeComponent();
        }

        enum ToolSelected
        {
            NONE,
            HERO,
            WALL,
            BOX,
            DESTINATION
        }

        /// <summary>
        /// Generates a grid of Tiles(picture boxes) with the number of 
        /// specified rows and columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                rows = int.Parse(txtRows.Text);
                columns = int.Parse(txtColumns.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter number of rows and columns!");
            }
            int leftPosition = LEFT;
            int topPosition = TOP;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Tile tile = new Tile();
                    tile.row = i;
                    tile.column = j;
                    tile.Height = HEIGHT;
                    tile.Width = WIDTH;
                    tile.Top = topPosition;
                    tile.Left = leftPosition;
                    tile.BorderStyle = BorderStyle.FixedSingle;
                    tile.SizeMode = PictureBoxSizeMode.Zoom;

                    tile.Click += PictureBox_Click;
                    this.Controls.Add(tile);

                    leftPosition += WIDTH + HORIZONTAL_GAP;

                }
                topPosition += HEIGHT + VERTICLE_GAP;
                leftPosition = LEFT;
            }
        }

        /// <summary>
        /// displays the chosen image in the chosen tile, and saves the 
        /// information to that tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Tile tile = (Tile)sender;
            switch (toolSelected)
            {
                case ToolSelected.NONE:
                    tile.Image = null;
                    tile.toolType = 0;
                    break;
                case ToolSelected.HERO:
                    tile.Image = LSudermanAssignment2.Properties.Resources.hero;
                    tile.toolType = 1;
                    break;
                case ToolSelected.WALL:
                    tile.Image = LSudermanAssignment2.Properties.Resources.wall;
                    tile.toolType = 2;
                    break;
                case ToolSelected.BOX:
                    tile.Image = LSudermanAssignment2.Properties.Resources.box;
                    tile.toolType = 3;
                    break;
                case ToolSelected.DESTINATION:
                    tile.Image = LSudermanAssignment2.Properties.Resources.destination;
                    tile.toolType = 4;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// changes tool selected to NONE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNone_Click(object sender, EventArgs e)
        {
            toolSelected = ToolSelected.NONE;
        }

        /// <summary>
        /// changes tool selected to HERO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHero_Click(object sender, EventArgs e)
        {
            toolSelected = ToolSelected.HERO;
        }

        /// <summary>
        /// changes tool selected to WALL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWall_Click(object sender, EventArgs e)
        {
            toolSelected = ToolSelected.WALL;
        }

        /// <summary>
        /// changes tool selected to BOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBox_Click(object sender, EventArgs e)
        {
            toolSelected = ToolSelected.BOX;
        }

        /// <summary>
        /// changes tool selected to DESTINATION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDestination_Click(object sender, EventArgs e)
        {
            toolSelected = ToolSelected.DESTINATION;
        }

        /// <summary>
        /// Brings up a dialog box for the user to chose the name of the level,
        /// and where it is to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    string filename = saveFileDialog.FileName;
                    save(filename);
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Saves the level to a file
        /// </summary>
        /// <param name="fileName"></param>
        private void save(string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine(rows + "\n" + columns);

                //This goes through each tile on the screen
                foreach (Tile tile in Controls.OfType<Tile>())
                {
                    writer.WriteLine(tile.row);
                    writer.WriteLine(tile.column);
                    writer.WriteLine(tile.toolType);
                }
                writer.Close();
                MessageBox.Show("File Saved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file");
            }
        }
    }
}
