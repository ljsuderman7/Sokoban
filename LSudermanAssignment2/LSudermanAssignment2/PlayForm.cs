/*
 * Program Name: LSAsignment2
 * 
 * Purpose: To be able to load a previously saved level of Sokoban, and play it
 * 
 * Revision History:
 *          October 20, 2019: Created
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
using System.IO;

namespace LSudermanAssignment2
{
    /// <summary>
    /// This contains all the contents for the PlayForm class
    /// </summary>
    public partial class PlayForm : Form
    {
        int pushes = 0;
        int moves = 0;
        const int LEFT = 25;
        const int TOP = 25;
        const int WIDTH = 50;
        const int HEIGHT = 50;
        const int VERTICLE_GAP = 5;
        const int HORIZONTAL_GAP = 5;
        const int EMPTY = 0;
        const int WALL = 2;
        const int BOX = 3;
        const int DESTINATION = 4;
        const int BOX_AT_DESTINATION = 5;
        int rows;
        int columns;
        Tile[,] board;
        Tile hero = new Tile();
        Tile move = new Tile();
        Tile pushCheck = new Tile();

        public PlayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This exits the PlayForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// this loads the chosen file, and places the playing board ready to play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMoves.Text = moves.ToString();
            txtPushes.Text = pushes.ToString();
            StreamReader reader;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                reader = new StreamReader(openFileDialog.FileName);
                try
                {
                    rows = int.Parse(reader.ReadLine());
                    columns = int.Parse(reader.ReadLine());
                    board = new Tile[columns, rows];

                    int leftPosition = LEFT;
                    int topPosition = TOP;

                    for (int i = 0; i < columns; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            Tile tile = new Tile();
                            tile.row = int.Parse(reader.ReadLine());
                            tile.column = int.Parse(reader.ReadLine());
                            tile.toolType = int.Parse(reader.ReadLine());
                            tile.Height = HEIGHT;
                            tile.Width = WIDTH;
                            tile.Top = topPosition;
                            tile.Left = leftPosition;
                            tile.BorderStyle = BorderStyle.FixedSingle;
                            tile.SizeMode = PictureBoxSizeMode.Zoom;

                            //this.Controls.Add(tile);
                            pnlPanel.Controls.Add(tile);

                            leftPosition += WIDTH + HORIZONTAL_GAP;

                            if (tile.toolType == EMPTY)
                            {
                                tile.Image = null;
                            }
                            else if (tile.toolType == 1)
                            {
                                tile.Image = LSudermanAssignment2.Properties.Resources.heroDown;
                                tile.toolType = 0;
                                hero = tile;
                            }
                            else if (tile.toolType == WALL)
                            {
                                tile.Image = LSudermanAssignment2.Properties.Resources.wall;
                            }
                            else if (tile.toolType == BOX)
                            {
                                tile.Image = LSudermanAssignment2.Properties.Resources.box;
                            }
                            else if (tile.toolType == DESTINATION)
                            {
                                tile.BackgroundImage = LSudermanAssignment2.Properties.Resources.destination;
                                tile.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            board[j, i] = tile;
                        }
                        topPosition += HEIGHT + VERTICLE_GAP;
                        leftPosition = LEFT;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Loading File");
                }
            }
        }

        /// <summary>
        /// This moves the hero in the desired direction (if they can), and if there is a box in that tile,
        /// it pushes the box to the next tile(if it can) and then checks to see the player has won, and if they did displays
        /// their total moves and pushes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int heroMoveRow = 0, heroMoveColumn = 0, boxMoveRow = 0, boxMoveColumn = 0;
            string direction = "";
            if (button.Text == "UP")
            {
                heroMoveRow = hero.row - 1;
                heroMoveColumn = hero.column;
                boxMoveRow = hero.row -2 ;
                boxMoveColumn = hero.column;
                direction = "UP";
            }
            else if (button.Text == "LEFT")
            {
                heroMoveRow = hero.row;
                heroMoveColumn = hero.column - 1;
                boxMoveRow = hero.row;
                boxMoveColumn = hero.column - 2;
                direction = "LEFT";
            }
            else if (button.Text == "DOWN")
            {
                heroMoveRow = hero.row + 1;
                heroMoveColumn = hero.column;
                boxMoveRow = hero.row + 2;
                boxMoveColumn = hero.column;
                direction = "DOWN";
            }
            else if (button.Text == "RIGHT")
            {
                heroMoveRow = hero.row;
                heroMoveColumn = hero.column + 1;
                boxMoveRow = hero.row;
                boxMoveColumn = hero.column + 2;
                direction = "RIGHT";
            }

            move = getTile(heroMoveColumn, heroMoveRow);

            if (move.toolType == EMPTY || move.toolType == DESTINATION)
            {
                board[hero.column, hero.row].Image = null;

                if(move.toolType == EMPTY && board[hero.column, hero.row].toolType == DESTINATION ||
                    move.toolType == DESTINATION && board[hero.column, hero.row].toolType == DESTINATION)
                {
                    board[hero.column, hero.row].toolType = DESTINATION;
                }
                else if(move.toolType == EMPTY && board[hero.column, hero.row].toolType == EMPTY ||
                    move.toolType == DESTINATION && board[hero.column, hero.row].toolType == EMPTY)
                {
                    board[hero.column, hero.row].toolType = EMPTY;
                }

                hero.row = heroMoveRow;
                hero.column = heroMoveColumn;
                moveHero(hero, direction);
            }
            else if (move.toolType == BOX || move.toolType == BOX_AT_DESTINATION)
            {
                pushCheck = getTile(boxMoveColumn, boxMoveRow);

                if (board[pushCheck.column, pushCheck.row].toolType == EMPTY)
                {
                    board[pushCheck.column, pushCheck.row].toolType = BOX;
                    board[pushCheck.column, pushCheck.row].Image = Properties.Resources.box;

                    board[hero.column, hero.row].Image = null;

                    if (move.toolType == EMPTY && board[hero.column, hero.row].toolType == DESTINATION ||
                    move.toolType == DESTINATION && board[hero.column, hero.row].toolType == DESTINATION)
                    {
                        board[hero.column, hero.row].toolType = DESTINATION;
                    }
                    else if (move.toolType == EMPTY && board[hero.column, hero.row].toolType == EMPTY ||
                        move.toolType == DESTINATION && board[hero.column, hero.row].toolType == EMPTY)
                    {
                        board[hero.column, hero.row].toolType = EMPTY;
                    }

                    if(board[move.column, move.row].toolType == BOX_AT_DESTINATION)
                    {
                        board[move.column, move.row].toolType = DESTINATION;
                    }
                    else
                    {
                        board[move.column, move.row].toolType = EMPTY;
                    }

                    hero.row = heroMoveRow;
                    hero.column = heroMoveColumn;

                    moveHero(hero, direction);

                    pushes++;
                    txtPushes.Text = pushes.ToString();
                }
                else if (board[pushCheck.column, pushCheck.row].toolType == DESTINATION)
                {
                    board[pushCheck.column, pushCheck.row].toolType = BOX_AT_DESTINATION;
                    board[pushCheck.column, pushCheck.row].Image = Properties.Resources.boxAtDestination;

                    board[hero.column, hero.row].Image = null;

                    if (move.toolType == EMPTY && board[hero.column, hero.row].toolType == DESTINATION ||
                    move.toolType == DESTINATION && board[hero.column, hero.row].toolType == DESTINATION)
                    {
                        board[hero.column, hero.row].toolType = DESTINATION;
                    }
                    else if (move.toolType == EMPTY && board[hero.column, hero.row].toolType == EMPTY ||
                        move.toolType == DESTINATION && board[hero.column, hero.row].toolType == EMPTY)
                    {
                        board[hero.column, hero.row].toolType = EMPTY;
                    }

                    if (board[move.column, move.row].toolType == BOX_AT_DESTINATION)
                    {
                        board[move.column, move.row].toolType = DESTINATION;
                    }
                    else
                    {
                        board[move.column, move.row].toolType = EMPTY;
                    }

                    hero.row = heroMoveRow;
                    hero.column = heroMoveColumn;

                    moveHero(hero, direction);

                    pushes++;
                    txtPushes.Text = pushes.ToString();
                }
                if (gameOver())
                {
                    MessageBox.Show($"You Win!\nTotal Moves: {moves}\nTotal Pushes: {pushes}");
                    pnlPanel.Controls.Clear();
                }
            }
        }

        /// <summary>
        /// goes through each tile in the board
        /// </summary>
        /// <param name="column">column of the desired tile</param>
        /// <param name="row">row of the desired tile</param>
        /// <returns>the desired tile</returns>
        private Tile getTile(int column, int row)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if(i == column && j == row)
                    {
                        return board[i, j];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// puts the correct hero image, based on the direction
        /// </summary>
        /// <param name="hero">this is the hero tile</param>
        /// <param name="direction">this is the direction of the hero movement</param>
        private void moveHero(Tile hero, string direction)
        {
            moves++;
            txtMoves.Text = moves.ToString();
            switch (direction)
            {
                case "UP":
                    board[hero.column, hero.row].Image = Properties.Resources.heroUp;
                    break;
                case "LEFT":
                    board[hero.column, hero.row].Image = Properties.Resources.heroRight; // mixed up left/right in pic names
                    break;
                case "DOWN":
                    board[hero.column, hero.row].Image = Properties.Resources.heroDown;
                    break;
                case "RIGHT":
                    board[hero.column, hero.row].Image = Properties.Resources.heroLeft; // mixed up left/right in pic names
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// this check to see if the player has won
        /// </summary>
        /// <returns>false, unless their are no tiles that contain just a box, and not a box at a destination</returns>
        private bool gameOver()
        {
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (board[column, row].toolType == BOX)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
