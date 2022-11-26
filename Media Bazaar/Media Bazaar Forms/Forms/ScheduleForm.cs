    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar.Forms
{
    public partial class ScheduleForm : Form
    {
        // List of users and schedules are stored in this
        private Schedule schedule;

        // The list of weeks with their weeknumber and dates.
        // This is used to present the weeks to the user in the combobox where you can switch to another week.
        private List<string> weeks;

        private bool checkNow = false; // This will be false until all the users are added to the datagrid. This is to prevent an error when selecting an user.

        private User loggedUser;

        private int department;

        private bool manualScheduling = false;


        public ScheduleForm(User user)
        {
            InitializeComponent();
            this.schedule = new Schedule();
            this.loggedUser = user;
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            // Preparing the schedule DGV
            this.scheduleDgvSchedule.Rows.Add(3);
            this.scheduleDgvSchedule.Rows[0].HeaderCell.Value = "Morning";
            this.scheduleDgvSchedule.Rows[1].HeaderCell.Value = "Afternoon";
            this.scheduleDgvSchedule.Rows[2].HeaderCell.Value = "Evening";

            this.DepartmentCboxSetup();

            // Checking the role and which department the logged in user is in
            if (this.loggedUser.Role == RoleType.Admin)
            {
                this.scheduleCboxDepartment.Visible = true;
                this.scheduleCboxDepartment.Enabled = true;
                this.scheduleLblDepartment.Visible = true;
                this.scheduleCboxDepartment.SelectedIndex = 0;
                this.department = this.schedule.GetDepartmentIdFromString(this.scheduleCboxDepartment.Text);
                //this.department = Convert.ToInt32(this.scheduleCboxDepartment.Text);
            }
            else
            {
                this.department = this.loggedUser.Department;
            }

            // Datebase setup
            this.DataBaseSetup();

            // Week combobox Setup
            this.weeks = new List<string>();
            this.WeekDatesSetup();

            // Employees loading to datagridview this is already done after creating the weekdates setup
            // this.UsersToEmp(); 
            this.scheduleDgvEmp.Rows[0].Selected = true;
            this.ShowAvailability();

            this.scheduleChckBoxManual_CheckedChanged(new object{ }, new EventArgs { } );



            // Loading all the how to panels and resetting them

            this.DisableAllManualPanels();
            this.PnlManualEnable.Visible = true;

            this.DisableAllGeneralPanels();
            this.PnlGeneralDepartment.Visible = true;


        }

        #region Setup

        // Setting up the list of weeks for the user to switch to and from.

        private void DepartmentCboxSetup()
        {
            List<Department> departments = DepartmentController.GetAllDepartments();
            foreach(Department d in departments)
            {
                this.scheduleCboxDepartment.Items.Add(d.DepartmentName);
            }
        }

        private void WeekDatesSetup()
        {
            // The first monday of the year is needed to know where week 1 starts.
            DateTime firstMonday = this.calculateFirstMondayOfYear(new DateTime(DateTime.Now.Year, 1, 1));

            // Adding the weeks and week dates and showing this in the combobox
            this.GetWeeksList(firstMonday); 
            for (int i = 0; i < weeks.Count; i++)
            {
                this.scheduleCboxDate.Items.Add(this.weeks[i]);
            }

            // Showing the current week to the user.
            int currentWeek = this.GetWeekOfDate(DateTime.Now);
            this.scheduleCboxDate.SelectedIndex = currentWeek - 1; // Index 0-51 with index 0 = week 1
        }

        private DateTime calculateFirstMondayOfYear(DateTime firstDayOfYear)
        {

            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("nl-NL");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            // Get the week of the first day of the year. 
            int firstWeek = myCal.GetWeekOfYear(firstDayOfYear, myCWR, myFirstDOW);

            // Checking the difference between the monday of that week and the first day of the year.
            int diff = (7 + (firstDayOfYear.DayOfWeek - myFirstDOW)) % 7;
            DateTime firstMonday = firstDayOfYear.AddDays(-1 * diff).Date;

            // If the first day of the year falls in the week of last year, then we take the week after.
            if (firstWeek != 1)
            {
                firstMonday = firstMonday.AddDays(7);
            }

            return firstMonday;
        }

        // Adding all the weeks to the week list. 
        private void GetWeeksList(DateTime firstMonday)
        {
            // Begin date of the week
            DateTime monday = firstMonday;

            // Last date of the week
            DateTime sunday = firstMonday.AddDays(6);

            for (int i = 0; i < 52; i++)
            {

                string week = $"Week {i + 1}: {monday.Date.ToShortDateString()} - {sunday.Date.ToShortDateString()}";

                this.weeks.Add(week);

                monday = monday.AddDays(7);
                sunday = sunday.AddDays(7);
            }
        }

        // Get the weeknumber of a certain date
        private int GetWeekOfDate(DateTime date)
        {
            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("nl-NL");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            // Get the week of the date
            int week = myCal.GetWeekOfYear(date, myCWR, myFirstDOW);

            return week;
        }

        private void DataBaseSetup()
        {
            // This can be changed to only department people.
            this.schedule.Users = UserController.GetAllUsers();

            // Change this later to only get the availability of the people of the department
            this.schedule.Availability = SchedulerController.GetEmpAvailability();
        }

        private void UsersToEmp()
        {
            this.checkNow = false;
            List<User> users = this.schedule.GetUsersOfDepartment(this.department);
            int empCount = users.Count;

            this.scheduleDgvEmp.Rows.Clear();
            this.scheduleDgvEmp.Rows.Add(empCount);

            int row = 0;
            foreach (User user in users)
            {
                this.scheduleDgvEmp.Rows[row].Cells[0].Value = $"{user.FirstName.Substring(0, 1).ToUpper()}, {user.SurName}";
                this.scheduleDgvEmp.Rows[row].Cells[1].Value = user.ID;

                int amountOfshifts = this.schedule.TotalAssignedShfits(user) * 4;
                int contractHours = this.schedule.GetUserContractHour(user.ID);

                if(amountOfshifts >= contractHours)
                {
                    this.scheduleDgvEmp.Rows[row].Cells[2].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    this.scheduleDgvEmp.Rows[row].Cells[2].Style.BackColor = default;
                }

                this.scheduleDgvEmp.Rows[row].Cells[2].Value = $"{amountOfshifts}/{contractHours}";
                row++;
            }

            //this.scheduleDgvEmp.CurrentRow.Selected = false;

            this.checkNow = true;
        }

        #endregion

        #region formInteractions

        private void scheduleBtnCurrentWeek_Click(object sender, EventArgs e)
        {
            // Showing the current week to the user.
            int currentWeek = this.GetWeekOfDate(DateTime.Now);
            this.scheduleCboxDate.SelectedIndex = currentWeek - 1; // Index 0-51 with index 0 = week 1
        }

        // Changes the current week view

        // This is not fully live updating, as you don't get the new list of shifts from the
        // database, but only after changing the weeknumber. 
        // If someone schedules at the same time in the same week, you won't see their changes right away.
        private void scheduleCboxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int weekNumber = this.scheduleCboxDate.SelectedIndex + 1;
            this.schedule.CurrentWeek = weekNumber;

            //Creating 7 empty shifts and filling them with information from the database
            this.schedule.CreateWeek();
            List<List<string>> scheduleToAdd = SchedulerController.GetSchedule(weekNumber, this.department);
            this.schedule.AddShiftsToSchedule(scheduleToAdd);

            // Putting the numbers in the schedule DGV cells
            this.SetupShiftAmountCells();

            int lastSelectedEmp = 0;
            int lastEmpCount = this.scheduleDgvEmp.Rows.Count; // Change this later to check if the department has changed instead of doing this.

            if (checkNow)
                lastSelectedEmp = this.scheduleDgvEmp.CurrentCell.RowIndex;

            this.UsersToEmp();
            if (this.scheduleDgvEmp.Rows.Count == 0)
            {
                // Dummy code
            }
            else if (this.scheduleDgvEmp.Rows.Count != lastEmpCount)
            {
                this.scheduleDgvEmp.Rows[0].Selected = true;
            }
            else
            {
                this.scheduleDgvEmp.Rows[lastSelectedEmp].Selected = true;
            }
                

            this.ShowAvailability();

        }

        private void scheduleBtnGoPrevWeek_Click(object sender, EventArgs e)
        {
            int prevIndex = this.scheduleCboxDate.SelectedIndex - 1;

            // index -1 doesn't exist so we prevent this from entering.
            if (prevIndex == -1)
                prevIndex = 0;

            this.scheduleCboxDate.SelectedIndex = prevIndex;
        }

        private void scheduleBtnGoNextWeek_Click(object sender, EventArgs e)
        {
            int prevIndex = this.scheduleCboxDate.SelectedIndex + 1;

            // index 52 is out of bounds, so we prevent this from entering.
            if (prevIndex == 52)
                prevIndex = 51;

            this.scheduleCboxDate.SelectedIndex = prevIndex;
        }

        // The selected user is added to the right shift and the cell of the DGV is updated.
        // The user can also click on the column headers to get more information of that day.
        private void scheduleDgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.scheduleRtxtShiftInformation.Clear();

            if (this.scheduleDgvEmp.SelectedRows.Count != 0)
            {
                this.scheduleDgvSchedule.CurrentCell.Selected = false;

                int rIndex = e.RowIndex;
                int cIndex = e.ColumnIndex;

                if (cIndex >= 0)
                {
                    // Parameter both used in adding/removing and showing information
                    string time = Shift.GetShiftTime(rIndex);

                    // Positive rIndex means adding/removing user
                    // Negative rIndex means the employee will be shown the information of that day
                    if (rIndex >= 0) 
                    {
                        // We can only schedule manually when this is enabled
                        if (this.manualScheduling == true)
                        {

                            // Preparing parameters for the adding/removing
                            User userToAdd = this.schedule.GetUserByID((int)this.scheduleDgvEmp.SelectedCells[1].Value);
                            List<string> avail = this.schedule.GetUserAvailability(userToAdd.ID);

                            // Amount of hours worked this week
                            int amountOfShifts = this.schedule.TotalAssignedShfits(userToAdd);

                            Shift shift = this.schedule.GetShift(cIndex + 1);

                            // This is used to check if the shift is new, removed or has to be changed.
                            // It also is needed to check if the person already has two shifts on this day.
                            List<string> shiftPresence = shift.GetShiftPresence(userToAdd);

                            bool ignore = this.scheduleChckBoxIgnore.Checked;

                            // Adding or removing user from the shift
                            int result = shift.AddOrRemoveShift(userToAdd, time, amountOfShifts, avail, shiftPresence, ignore);

                            // Refresh
                            shiftPresence = shift.GetShiftPresence(userToAdd);

                            // Employee added 
                            if (result == 0)
                            {
                                if (shiftPresence.Count == 1) // New shift created in the database
                                {
                                    SchedulerController.AddEmployeeShift(userToAdd, this.schedule.CurrentWeek, shift.Day, time, this.department);
                                }
                                else // Shift changed 
                                {
                                    SchedulerController.ChangeShift(userToAdd, this.schedule.CurrentWeek, shift.Day, this.department, shiftPresence);
                                }
                            }
                            else if (result == 1) // Employee removed
                            {
                                if (shiftPresence.Count == 0)
                                {
                                    SchedulerController.RemoveEmployeeShift(userToAdd, this.schedule.CurrentWeek, this.department, shift.Day);
                                }
                                else // Shift changed
                                {
                                    SchedulerController.ChangeShift(userToAdd, this.schedule.CurrentWeek, shift.Day, this.department, shiftPresence);
                                }
                            }

                            // Updating the numbers of assigned users to the consumer
                            this.UpdateAmountWorkedCell(userToAdd);
                            this.UpdateShiftAmountCell(rIndex, cIndex, time);

                            this.ShowAvailability();
                            //this.AvailabilityColorSelection(userToAdd);
                        }
                    }
                    else
                    {
                        List<string> shiftInformation = new List<string>();
                        List<User> shift = this.schedule.Shifts[cIndex].GetShiftListByTime(time);

                        this.scheduleRtxtShiftInformation.Text = this.schedule.Shifts[cIndex].GetShiftInformation(this.scheduleCboxDate.Text);
                    }
                }
            }
        }


        // The selected user is added to the right shift and the cell of the DGV is updated.
        private void scheduleDgvEmp_SelectionChanged(object sender, EventArgs e)
        {
            // Updating the colors in the DGV for availability
            this.ShowAvailability();
        }

        #endregion

        #region ScheduleDGV Methods

        // This will update the cell for the whole week
        private void SetupShiftAmountCells()
        {
            for (int rIndex = 0; rIndex < 3; rIndex++)
            {
                string time = Shift.GetShiftTime(rIndex);

                for (int cIndex = 0; cIndex < 7; cIndex++)
                {
                    this.UpdateShiftAmountCell(rIndex, cIndex, time);
                }
            }
        }

        // This updated the content inside the cell to a x/x format
        private void UpdateShiftAmountCell(int rIndex, int cIndex, string time)
        {
            int amountOfAssignedPeople = this.schedule.Shifts[cIndex].GetShiftListByTime(time).Count;
            int maxShifts = this.schedule.Shifts[cIndex].MaxShifts;

            if (time.Equals("afternoon"))
                maxShifts = 3;

            this.scheduleDgvSchedule.Rows[rIndex].Cells[cIndex].Value = $"{amountOfAssignedPeople}/{maxShifts}";
        }

        // Showing the availability in Colors to the user
        // GREY: User not available
        // RED: user available, shift is not full
        // GREEN: Shift is full
        // YELLOW: User is assigned to shift, but the shift is not full yet.          
        private void AvailabilityColorSelection(User user)
        {
            List<string> avail = this.schedule.GetUserAvailability(user.ID);

            // Check every cell in the Schedule DGV
            for (int rIndex = 0; rIndex < 3; rIndex++)
            {
                string time = Shift.GetShiftTime(rIndex);
                for (int cIndex = 0; cIndex < 7; cIndex++)
                {
                    // The cell properties
                    DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)scheduleDgvSchedule.Rows[rIndex].Cells[cIndex];
                    buttonCell.FlatStyle = FlatStyle.Flat;

                    // The shift to look into
                    Shift shift = this.schedule.GetShift(cIndex + 1);
                    List<User> usersInShift = shift.GetShiftListByTime(time);

                    buttonCell.Style.Font = default;

                    // Shift full?
                    if (shift.TimeIsFull(usersInShift, time))
                    {
                        // MAKE GREEN: shift is full
                        buttonCell.Style.BackColor = Color.LightGreen;

                        if (usersInShift.Contains(user))
                        {
                            //string kek = buttonCell.Value.ToString().Substring(0, 3);
                            //buttonCell.Value = $"{kek}\n X";

                            // Change this and show to client
                            // FontStyle.Underline
                            buttonCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold | FontStyle.Italic );
                        }
                    }
                    else
                    {
                        // Employee already in shift?
                        if (usersInShift.Contains(user))
                        {
                           // string kek = buttonCell.Value.ToString().Substring(0, 3);
                           // buttonCell.Value = $"{kek}\n X";

                            // MAKE CELL YELLOW : user is in shift
                            buttonCell.Style.BackColor = Color.LightYellow;
                            buttonCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold | FontStyle.Italic);
                        }
                        else
                        {
                            if (avail[cIndex + 2].Equals("true"))
                            {
                                // MAKE RED: shift is not full and still needs some employees
                                buttonCell.Style.BackColor = Color.Coral;
                            }
                            else
                            {
                                // MAKE GREY: Employee is not available for this shift
                                buttonCell.Style.BackColor = Color.Gray;
                            }
                        }
                    }

                    // THIS IS ONE SOLUTION ON HOW TO MAKE SURE THE PERSON KNOWS THAT THE PERSON IS ASSIGNED AND SHIFT IS FULL.

                    //// Employee alraedy in shifts
                    //if (usersInShift.Contains(user))
                    //{
                    //    if (shift.ShiftIsFull(usersInShift, time))
                    //    {
                    //        // MAKE GREEN: shift is full
                    //        buttonCell.Style.BackColor = Color.GreenYellow;
                    //    }
                    //    else
                    //    {
                    //        // MAKE CELL YELLOW : user is in shift
                    //        buttonCell.Style.BackColor = Color.LightYellow;
                    //    }
                    //}
                    //else
                    //{
                    //    // Shift full?
                    //    if (shift.ShiftIsFull(usersInShift, time))
                    //    {
                    //        // MAKE GREEN: shift is full
                    //        buttonCell.Style.BackColor = Color.LightGreen;
                    //    }
                    //    else
                    //    {
                    //        if (avail[cIndex + 2].Equals("true"))
                    //        {
                    //            // MAKE RED: shift is not full and still needs some employees
                    //            buttonCell.Style.BackColor = Color.Coral;
                    //        }
                    //        else
                    //        {
                    //            // MAKE GREY: Employee is not available for this shift
                    //            buttonCell.Style.BackColor = Color.Gray;
                    //        }
                    //    }
                    //}
                }
            }
        }

        private void ShowAvailability()
        {
            if (this.checkNow)
            {
                this.scheduleDgvSchedule.CurrentCell.Selected = false;
                User user = this.schedule.GetUserByID((int)this.scheduleDgvEmp.SelectedCells[1].Value);
                this.AvailabilityColorSelection(user);
            }
        }

        #endregion

        #region EmpDGV Methods

        public void UpdateAmountWorkedCell(User user)
        {
            int amountOfshifts = this.schedule.TotalAssignedShfits(user) * 4;
            int contractHours = this.schedule.GetUserContractHour(user.ID);

            if (amountOfshifts >= contractHours)
            {
                this.scheduleDgvEmp.CurrentRow.Cells[2].Style.BackColor = Color.LightGreen;
            }
            else
            {
                this.scheduleDgvEmp.CurrentRow.Cells[2].Style.BackColor = default;
            }

            this.scheduleDgvEmp.CurrentRow.Cells[2].Value = $"{amountOfshifts}/{contractHours}";
        }

        #endregion


        // This creates a bug if you press and hold a cell and then click on the button and back. To fix this, just make this visible and also go to the front or back perhaps.
        private void scheduleBtnHowToSchedule_Click(object sender, EventArgs e)
        {
            if(this.SchedulePnlHowTo.Visible == false)
            {
                this.SchedulePnlHowTo.Visible = true;
            }
            else
            {
                this.SchedulePnlHowTo.Visible = false;
            }



            //if(this.schedulePnlInfo.Visible == true)
            //{
            //    this.schedulePnlInfo.Visible = false;
            //}
            //else
            //{
            //    this.schedulePnlInfo.Visible = true;
            //}
        }

        private void scheduleCboxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkNow)
            {
                this.department = this.schedule.GetDepartmentIdFromString(this.scheduleCboxDepartment.Text);
                this.scheduleCboxDate_SelectedIndexChanged(new object { }, new EventArgs { });
            }
        }

        // Auto schedule
        private void button1_Click(object sender, EventArgs e)
        {
            this.schedule.AutomaticScheduling(this.department);

            // Employees loading to datagridview this is already done after creating the weekdates setup 
            this.scheduleDgvEmp.Rows[0].Selected = true;
            this.ShowAvailability();
            this.SetupShiftAmountCells();
            this.UsersToEmp();

        }

        private void scheduleChckBoxManual_CheckedChanged(object sender, EventArgs e)
        {
            this.manualScheduling = scheduleChckBoxManual.Checked;

            if(this.manualScheduling == false)
            {
                this.scheduleChckBoxIgnore.Enabled = false;
                this.scheduleChckBoxIgnore.Checked = false;

                this.scheduleBtnAutoSchedule.Enabled = true;
            }
            else
            {
                this.scheduleChckBoxIgnore.Enabled = true;
                this.scheduleBtnAutoSchedule.Enabled = false;
            }
        }

        private void ScheduleBtnHowReturn_Click(object sender, EventArgs e)
        {
            if (this.SchedulePnlHowTo.Visible == false)
            {
                this.SchedulePnlHowTo.Visible = true;
            }
            else
            {
                this.SchedulePnlHowTo.Visible = false;
            }
        }

        #region How To Manual

        private int howToManualPanel = 1;

        // ENABLE PANELS IN LOAD

        private void scheduleBtnHowManualBack_Click(object sender, EventArgs e)
        {
            this.GetManualPanel(howToManualPanel).Hide();

            this.howToManualPanel--;
            if (this.howToManualPanel == 0)
                this.howToManualPanel = 1;

            this.GetManualPanel(howToManualPanel).Show();
        }

        private void scheduleBtnHowManualForward_Click(object sender, EventArgs e)
        {
            this.howToManualPanel++;

            if (this.howToManualPanel == 5)
                this.howToManualPanel = 4;

            this.GetManualPanel(howToManualPanel).Show();
        }

        private void DisableAllManualPanels()
        {
            this.PnlManualAssigning.Hide();
            this.PnlManualLimit.Hide();
            this.PnlManualRemoving.Hide();
        }

        private Panel GetManualPanel(int panelNumber)
        {
            Panel result = this.PnlManualEnable;

            switch (panelNumber)
            {
                case 1:
                    result = this.PnlManualEnable;
                    break;
                case 2:
                    result = this.PnlManualAssigning;
                    break;
                case 3:
                    result = this.PnlManualRemoving;
                    break;
                case 4:
                    result = this.PnlManualLimit;
                    break;
            }

            return result;
        }

        #endregion

        #region How To General

        private int howToGeneralPanel = 1;

        private void scheduleBtnHowGeneralBack_Click(object sender, EventArgs e)
        {
            this.GetGeneralPanel(howToGeneralPanel).Hide();

            this.howToGeneralPanel--;
            if (this.howToGeneralPanel == 0)
                this.howToGeneralPanel = 1;

            this.GetGeneralPanel(howToGeneralPanel).Show();
        }

        private void scheduleBtnHowGeneralForward_Click(object sender, EventArgs e)
        {
            this.howToGeneralPanel++;

            if (this.howToGeneralPanel == 4)
                this.howToGeneralPanel = 3;

            this.GetGeneralPanel(howToGeneralPanel).Show();
        }

        private void DisableAllGeneralPanels()
        {
            this.PnlGeneralShowingInfo.Hide();
            this.PnlGeneralWeek.Hide();
        }


        private Panel GetGeneralPanel(int panelNumber)
        {
            Panel result = this.PnlGeneralDepartment;

            switch (panelNumber)
            {
                case 1:
                    result = this.PnlGeneralDepartment;
                    break;
                case 2:
                    result = this.PnlGeneralShowingInfo;
                    break;
                case 3:
                    result = this.PnlGeneralWeek;
                    break;
            }

            return result;
        }
    }

    #endregion
}
