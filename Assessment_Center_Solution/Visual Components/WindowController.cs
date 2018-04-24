using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment_Center_Solution
{
    /// <summary>
    /// This class controlls the window of the program.
    /// </summary>
    class WindowController
    {
        public const int CHESSBOARD_WIDTH = 20;
        public const int BUTTON_MARGIN = 1;
        public const int FORM_HEAD_HEIGHT = 23;

        private MainWindow window;
        private List<ChessboardButton> buttons;
        private List<Tuple<int, int>> markedPath;

        /// <summary>
        /// Creates a new WindowController.
        /// </summary>
        /// <param name="handler">Method which will be called, if a button gets clicked.</param>
        public WindowController(ButtonClickedHandler handler)
        {
            buttons = new List<ChessboardButton>();
            markedPath = new List<Tuple<int, int>>();
            window = new MainWindow();
            SetupForm(handler);
        }

        /// <summary>
        /// Returns the form of the window.
        /// </summary>
        /// <returns>Form of the window.</returns>
        public MainWindow GetForm()
        {
            return window;
        }

        /// <summary>
        /// Removes all markings at the buttons.
        /// </summary>
        public void ResetMarkings()
        {
            foreach (Tuple<int, int> position in markedPath)
            {
                MarkButton(position, ButtonType.DefaultButton);
            }
            markedPath.Clear();
        }

        /// <summary>
        /// Marks the buttons with the given path.
        /// The first position in the list should be the start-position,
        /// the last position should be the target-position.
        /// </summary>
        /// <param name="path">The path, which will be marked.</param>
        public void MarkPath(List<Tuple<int, int>> path)
        {
            markedPath.AddRange(path);
            if (path.Count == 0) return;
            if (path.Count == 1)
            {
                MarkButton(path.First(), ButtonType.StartTargetButton);
            }
            else
            {
                MarkButton(path.First(), ButtonType.StartButton);
                path.RemoveAt(0);

                MarkButton(path.Last(), ButtonType.TargetButton);
                path.RemoveAt(path.Count - 1);

                foreach (Tuple<int, int> position in path)
                {
                    MarkButton(position, ButtonType.PathButton);
                }
            }
        }

        /// <summary>
        /// Marks the button with the given position as the start-button.
        /// </summary>
        /// <param name="position">Position of the start-button.</param>
        public void MarkStart(Tuple<int, int> position)
        {
            markedPath.Add(position);
            MarkButton(position, ButtonType.StartButton);
        }

        /// <summary>
        /// Marks a specified button with the given parameters.
        /// </summary>
        /// <param name="position">Position of the button, which will be marked.</param>
        /// <param name="buttonType">New type of the button.</param>
        private void MarkButton(Tuple<int, int> position, ButtonType buttonType)
        {
            GetButton(position).BackColor = ResourceManager.GetButtonColor(buttonType);
            GetButton(position).Text = ResourceManager.GetButtonText(buttonType);
        }

        /// <summary>
        /// Returns the button of the specified position.
        /// </summary>
        /// <param name="position">Position of the wanted button.</param>
        /// <returns>The button at the given position or null, if the position is not valid.</returns>
        private ChessboardButton GetButton(Tuple<int, int> position)
        {
            if (position.Item1 >= CHESSBOARD_WIDTH || position.Item2 >= CHESSBOARD_WIDTH || position.Item1 < 0 || position.Item2 < 0) return null;
            return buttons[position.Item1 + position.Item2 * CHESSBOARD_WIDTH];
        }

        /// <summary>
        /// Setup the form by creating and configuring all needed buttons.
        /// </summary>
        /// <param name="handler">Method which will be called, if a button gets clicked.</param>
        private void SetupForm(ButtonClickedHandler handler)
        {
            for (int i = 0; i < CHESSBOARD_WIDTH * CHESSBOARD_WIDTH; i++)
            {
                ChessboardButton newButton = new ChessboardButton(i % CHESSBOARD_WIDTH, i / CHESSBOARD_WIDTH, handler);
                newButton.Width = (window.Width - CHESSBOARD_WIDTH * BUTTON_MARGIN * 2) / CHESSBOARD_WIDTH;
                newButton.Height = (window.Height - CHESSBOARD_WIDTH * BUTTON_MARGIN * 2 - FORM_HEAD_HEIGHT) / CHESSBOARD_WIDTH;
                newButton.Margin = new System.Windows.Forms.Padding(BUTTON_MARGIN);
                newButton.BackColor = ResourceManager.GetButtonColor(ButtonType.DefaultButton);
                buttons.Add(newButton);
                window.AddControl(newButton);
            }
        }
    }
}
