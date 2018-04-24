namespace Assessment_Center_Solution
{
    /// <summary>
    /// Specifies all available types of buttons.
    /// </summary>
    enum ButtonType
    {
        DefaultButton, StartButton, TargetButton, PathButton, StartTargetButton
    }

    /// <summary>
    /// This class holds all resources of the program.
    /// </summary>
    static class ResourceManager
    {
        /// <summary>
        /// Returns the text for the given ButtonType.
        /// </summary>
        /// <param name="buttonType">Type of a button</param>
        /// <returns>The text of the specified ButtonType.</returns>
        public static string GetButtonText(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.StartButton:
                    return "S";
                case ButtonType.TargetButton:
                    return "Z";
                case ButtonType.PathButton:
                    return "";
                case ButtonType.StartTargetButton:
                    return "S / Z";
                case ButtonType.DefaultButton:
                default:
                    return "";
            }
        }

        /// <summary>
        /// Returns the color for the given ButtonType.
        /// </summary>
        /// <param name="buttonType">Type of a button</param>
        /// <returns>The color of the specified ButtonType.</returns>
        public static System.Drawing.Color GetButtonColor(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.StartButton:
                    return System.Drawing.Color.DodgerBlue;
                case ButtonType.TargetButton:
                    return System.Drawing.Color.Red;
                case ButtonType.PathButton:
                    return System.Drawing.Color.Green;
                case ButtonType.StartTargetButton:
                    return System.Drawing.Color.MediumPurple;
                case ButtonType.DefaultButton:
                default:
                    return System.Windows.Forms.Button.DefaultBackColor;
            }
        }
    }
}
