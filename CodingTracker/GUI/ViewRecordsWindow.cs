using CodingTracker.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CodingTracker.GUI
{
    internal class ViewRecordsWindow : Window
    {
        private readonly IDatabaseController _databaseController;
        TableView _tableView = new TableView();
        public ViewRecordsWindow(IDatabaseController dbController)
        {
            _databaseController = dbController;

            _tableView = new TableView(GetAllRecords());
            _tableView.X = 0;
            _tableView.Y = 0;
            _tableView.Width = Dim.Sized(35);
            _tableView.Height = Dim.Fill();
            _tableView.AutoSize = true;
            _tableView.Style.AlwaysShowHeaders = true;

            var filterComboBox = new ComboBox();
            filterComboBox.SetSource(new[] { "Day", "Month", "Year" });
            //filterComboBox.X = _tableView. Columns[3].X + _tableView.Columns[3].Width;
            //filterComboBox.Y = _tableView.Columns[3].Y;
            filterComboBox.Width = 20;
            filterComboBox.Height = 20;

            // Create the textfield
            //var filterTextField = new TextField(filterComboBox.Frame.Right + 1, 0, 10, "");

            // Add the combobox and textfield to the filter view

            Add(filterComboBox, _tableView);
        }

        private DataTable GetAllRecords()
        {
            var records = _databaseController.GetAllSessions();
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Start Time", typeof(string));
            table.Columns.Add("End Time", typeof(string));
            table.Columns.Add("Duration", typeof(int));

            foreach (var record in records)
            {
                table.Rows.Add(record.Id, record.StartTime, record.EndTime, record.Duration);
            }

            return table;
        }

    }
}
