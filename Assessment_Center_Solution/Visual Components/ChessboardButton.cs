using System;

namespace Assessment_Center_Solution
{
    public delegate void ButtonClickedHandler(Tuple<int, int> position);

    public partial class ChessboardButton : System.Windows.Forms.Button
    {
        private Tuple<int, int> position;
        private ButtonClickedHandler clickHandler;

        /// <summary>
        /// Creates a new button.
        /// </summary>
        /// <param name="pos_x">X-coordinate of the new button</param>
        /// <param name="pos_y">Y-coordinate of the new button</param>
        /// <param name="buttonClickedHandler">Method which will be called, if the button gets clicked.</param>
        public ChessboardButton(int pos_x = 0, int pos_y = 0, ButtonClickedHandler buttonClickedHandler = null)
        {
            position = new Tuple<int, int>(pos_x, pos_y);
            clickHandler = buttonClickedHandler;
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (clickHandler != null)
            {
                clickHandler(position);
            }
        }
    }
}
