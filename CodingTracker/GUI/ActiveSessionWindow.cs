using CodingTracker.Controllers;
using CodingTracker.GUI.MainMenuExample;
using CodingTracker.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CodingTracker.GUI
{
    class ActiveSessionWindow : Window
    {
        private readonly IDatabaseController _databaseController;
        Label stopwatchLabel;
        Stopwatch stopwatch = new Stopwatch();
        public ActiveSessionWindow(IDatabaseController databaseController)
        {
            _databaseController = databaseController;

            Title = "Recording Coding Session";
            X = 0;
            Y = 0;
            //Width = Dim.Fill();
            //Height = Dim.Fill();

            stopwatchLabel = new Label("00:00:00")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };

            var startButton = new Button("Start")
            {
                X = Pos.Center(),
                Y = stopwatchLabel.Y + 1
            };
            startButton.Clicked += StartStopwatch;

            var pauseButton = new Button("Pause")
            {
                X = Pos.Center(),
                Y = startButton.Y + 1
            };
            pauseButton.Clicked += StopStopwatch;

            var resetButton = new Button("Reset")
            {
                X = Pos.Center(),
                Y = pauseButton.Y + 1
            };
            resetButton.Clicked += ResetStopwatch;

            var endButton = new Button("End")
            {
                X = Pos.Center(),
                Y = resetButton.Y + 1
            };
            endButton.Clicked += () =>
            {
                Application.RequestStop(this);
            };

            Add(stopwatchLabel, startButton, pauseButton, resetButton,endButton);
        }

        private void StartStopwatch()
        {
            stopwatch.Start();
            Application.MainLoop.AddTimeout(TimeSpan.FromMilliseconds(10), UpdateStopwatch);
        }

        private bool UpdateStopwatch(MainLoop arg)
        {
            stopwatchLabel.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
            return stopwatch.IsRunning;
        }

        private void StopStopwatch()
        {
            stopwatch.Stop();
        }

        private void ResetStopwatch()
        {
            stopwatch.Reset();
            stopwatchLabel.Text = "00:00:00";
        }
    }
}
