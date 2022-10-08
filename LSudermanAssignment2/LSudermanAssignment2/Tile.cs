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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSudermanAssignment2
{
    class Tile : PictureBox
    {
        public int row;
        public int column;
        public int toolType;
    }
}
