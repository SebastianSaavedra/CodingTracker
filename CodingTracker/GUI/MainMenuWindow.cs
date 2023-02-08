using CodingTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CodingTracker.GUI
{
    namespace MainMenuExample
    {
        class MainMenuWindow : Window
        {
            private readonly IDatabaseController _databaseController;
            MenuBar menu;
            public MainMenuWindow(IDatabaseController databaseController)
            {
                _databaseController = databaseController;

                Title = "Coding Tracker - Main Menu";
                menu = new MenuBar(new MenuBarItem[]
                {
                    new MenuBarItem("_Help", new MenuItem[]
                    {
                        new MenuItem("_About", "", () => { Application.Run(AboutDialog()); })
                    })
                });
                Add(new Label("Welcome to the Main Menu!"));


                Button recordSessionBtn = new Button()
                {
                    Text = "Record coding session.",
                    Y = 3,
                    X = 3,
                    IsDefault = true,
                };
                recordSessionBtn.Clicked += RunActiveSessionWindow;


                Button option2 = new Button()
                {
                    Text = "Show records.",
                    Y = 4,
                    X = 3,
                    IsDefault = false
                };
                option2.Clicked += RunViewRecordsWindow;

                Button option3 = new Button()
                {
                    Text = "Exit.",
                    Y = 5,
                    X = 3,
                    IsDefault = false
                };
                option3.Clicked += RequestStop;

                Add(recordSessionBtn,option2,option3);
            }

            private Dialog AboutDialog()
            {
                Dialog aboutDialog = new Dialog("About", 100, 15);

                Label[] labels = new Label[] {
                                new Label(1, 1, "A coding tracker that use Sqlite as the database and Entity framework as the ORM."),
                                new Label(1, 2, "All the Gui was made using Terminal.Gui Library."),
                                new Label(1, 3, "Version 1.0.0"),
                                new Label(1, 4, "Copyright (c) 2023"),
                                new Label(1, 5, ""),
                                new Label(1, 6, "Developed by Sebastián Saavedra"),
                                new Label(1, 7, "sebastiansaavedr@gmail.com"),
                                new Label(1, 8, "github.com/SebastianSaavedra/CodingTracker"),
                                new Label(1, 9, "")};

                Button Ok = new Button()
                {
                    Text = "OK",
                    X = 2,
                    Y = 10,
                };
                Ok.Clicked += () =>
                {
                    aboutDialog.RequestStop();
                };

                aboutDialog.Add(labels);
                aboutDialog.Add(Ok);

                return aboutDialog;
            }

            private void RunActiveSessionWindow()
            {
                ActiveSessionWindow activeSessionWindow = new ActiveSessionWindow(_databaseController);
                Application.Run(activeSessionWindow);
            }

            private void RunViewRecordsWindow()
            {
                ViewRecordsWindow viewRecordsWindow = new ViewRecordsWindow(_databaseController);
                Application.Run(viewRecordsWindow);
            }

            public void Show()
            {
                Application.Top.Add(menu);
                Application.Top.Add(this);
            }
        }
    }

}
