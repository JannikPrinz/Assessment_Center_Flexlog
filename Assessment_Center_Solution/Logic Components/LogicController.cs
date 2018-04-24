using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment_Center_Solution
{
    /// <summary>
    /// This class holds the logic of the program.
    /// </summary>
    class LogicController
    {
        private WindowController windowController;
        private Tuple<int, int> startPosition;
        private Tuple<int, int> targetPosition;
        private bool nextClickedButtonBecomesTheStartPosition = true;

        public LogicController()
        {
            windowController = new WindowController(processButtonClick);
        }

        /// <summary>
        /// Returns the form of the window.
        /// </summary>
        /// <returns>Form of the window.</returns>
        public MainWindow GetForm()
        {
            return windowController.GetForm();
        }

        /// <summary>
        /// Processes a button-click.
        /// The clicked button and the path to the last clicked button will be marked.
        /// </summary>
        /// <param name="position">Position of the clicked button.</param>
        private void processButtonClick(Tuple<int, int> position)
        {
            windowController.ResetMarkings();

            if (nextClickedButtonBecomesTheStartPosition)
            {
                startPosition = position;
            }
            else
            {
                targetPosition = position;
            }
            nextClickedButtonBecomesTheStartPosition = !nextClickedButtonBecomesTheStartPosition;

            if (targetPosition != null)
            {
                windowController.MarkPath(CalculatePath());
            }
            else
            {
                windowController.MarkStart(startPosition);
            }
        }

        /// <summary>
        /// Calculates a path from the start-position to the target-position.
        /// The start- and target-position are included in the returned path.
        /// </summary>
        /// <returns>A path between the start-position and the target-position.</returns>
        private List<Tuple<int, int>> CalculatePath()
        {
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();

            // Adds the horizontal part of the path (along x-axis):
            path.AddRange(
                GetSequence(startPosition.Item1, targetPosition.Item1)
                .Select(x => new Tuple<int, int>(x, startPosition.Item2)));
            // Adds the vertical part of the path (along y-axis):
            path.AddRange(
                GetSequence(startPosition.Item2, targetPosition.Item2)
                .Select(y => new Tuple<int, int>(targetPosition.Item1, y))
                .Skip(1));

            return path;
        }

        /// <summary>
        /// Returns a sequence of integers from the given start to the given end.
        /// </summary>
        /// <param name="start">Start-number of the wanted sequence.</param>
        /// <param name="end">End-number of the wanted sequence.</param>
        /// <returns>A sequence of integers from start to end.</returns>
        private IEnumerable<int> GetSequence(int start, int end)
        {
            if (start > end)
            {
                return GetSequence(end, start).Reverse();
            }
            else
            {
                return Enumerable.Range(start, end - start + 1);
            }
        }
    }
}
