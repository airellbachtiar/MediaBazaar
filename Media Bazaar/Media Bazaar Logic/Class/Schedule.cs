using System.Collections.Generic;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Class
{
    public class Schedule
    {
        private List<User> users;
        private List<List<string>> availability; // [userId, contractType, monday,tuesday, etc]
        private List<Shift> shifts; // 0 = monday, 1 = tuesday until sunday

        private int currentWeek;

        public List<User> Users { get { return this.users; } set { this.users = value; } }
        public List<List<string>> Availability { get { return this.availability; } set { this.availability = value; } }
        public List<Shift> Shifts { get { return this.shifts; } }
        public int CurrentWeek { get { return this.currentWeek; } set { this.currentWeek = value; } }

        public Schedule()
        {
            this.users = new List<User>();
            this.availability = new List<List<string>>();
            this.shifts = new List<Shift>();
        }

        public void CreateWeek()
        {
            this.shifts.Clear();
            this.shifts.Add(new Shift(Day.MONDAY));
            this.shifts.Add(new Shift(Day.TUESDAY));
            this.shifts.Add(new Shift(Day.WEDNESDAY));
            this.shifts.Add(new Shift(Day.THURSDAY));
            this.shifts.Add(new Shift(Day.FRIDAY));
            this.shifts.Add(new Shift(Day.SATURDAY));
            this.shifts.Add(new Shift(Day.SUNDAY));
        }

        public User GetUserByID(int id)
        {
            foreach (User u in this.users)
            {
                if (u.ID == id)
                    return u;
            }
            return null;
        }

        // Getting the contract hour of a user: 40, 24 and 0 hour contract Types
        public int GetUserContractHour(int userID)
        {
            foreach (List<string> avail in this.availability)
            {
                if (int.Parse(avail[0]) == userID)
                    return int.Parse(avail[1]);
            }
            return -1;
        }

        // Get the availability of a single user
        public List<string> GetUserAvailability(int userID)
        {
            foreach (List<string> avail in this.availability)
            {
                if (int.Parse(avail[0]) == userID)
                    return avail;
            }
            return null;
        }


        // This method already exists in UserController. So switch this to that method.
        public List<User> GetUsersOfDepartment(int department)
        {
            List<User> users = new List<User>();
            foreach(User user in this.users)
            {
                if (user.Department == department)
                    users.Add(user);
            }

            return users;
        }

        // Move this elsewhere later
        public int GetDepartmentIdFromString(string departmentName)
        {
            List<Department> departments = DepartmentController.GetAllDepartments();
            foreach(Department d in departments)
            {
                if (d.DepartmentName.Equals(departmentName))
                    return d.DepartmentID;
            }
            return -1;
        }

        public Shift GetShift(int dayNumber)
        {

            Day day = (Day)dayNumber;
            foreach (Shift s in this.shifts)
            {
                if (s.Day == day)
                    return s;
            }
            return null;
        }

        // Returns the amount of shifts this user is scheduled for the entire week as of this moment.
        public int TotalAssignedShfits(User user)
        {
            int amount = 0; // The amount of shifts this user has this week.

            foreach (Shift shift in this.shifts)
            {
                if (shift.Morning.Contains(user))
                    amount++;
                if (shift.Afternoon.Contains(user))
                    amount++;
                if (shift.Evening.Contains(user))
                    amount++;
            }

            return amount;
        }


        public void AddShiftsToSchedule(List<List<string>> schedule)
        {
            foreach(List<string> userToAdd in schedule)
            {
                this.AddToShiftFromDB(int.Parse(userToAdd[0]), int.Parse(userToAdd[1]), userToAdd[2]);
            }
        }

        // Adding users to schedule.
        // Only use this method when you get the information from the database
        private void AddToShiftFromDB(int userID, int day, string shifts)
        {
            User usertoAdd = this.GetUserByID(userID);
            Shift shift = this.GetShift(day);

            bool morning = shifts.ToLower().Contains("morning");
            bool afternoon = shifts.ToLower().Contains("afternoon");
            bool evening = shifts.ToLower().Contains("evening");

            if (morning)
                shift.Morning.Add(usertoAdd);
            if (afternoon)
                shift.Afternoon.Add(usertoAdd);
            if (evening)
                shift.Evening.Add(usertoAdd);
        }

        public bool ShiftIsFull(int day)
        {
            Shift shiftToCheck = this.GetShift(day);

            bool morningFull = shiftToCheck.TimeIsFull(shiftToCheck.GetShiftListByTime("morning"), "morning");
            bool afternoonFull = shiftToCheck.TimeIsFull(shiftToCheck.GetShiftListByTime("afternoon"), "afternoon");
            bool eveningFull = shiftToCheck.TimeIsFull(shiftToCheck.GetShiftListByTime("evening"), "evening");

            if(morningFull && afternoonFull && eveningFull)
            {
                // The shift is full
                return true;
            }
            else
            {
                // The shift is not full
                return false;
            }
        }

        // Returns only the availbility of the employees in the given deparment.
        public List<List<string>> GetAvailabilityOfDepartment(int department)
        {
            List<User> departmentEmps = this.GetUsersOfDepartment(department);

            List<List<string>> availOfDepartment = new List<List<string>>();

            foreach (User emp in departmentEmps)
            {
                availOfDepartment.Add(this.GetUserAvailability(emp.ID));
            }

            return availOfDepartment;
        }

        // Insertion sort: source link: http://anh.cs.luc.edu/170/notes/CSharpHtml/sorting.html

        // You can also get the list of availability sorted while you're getting it from the database using the query

        // This sorts the availabilities of the given list in order of 0 to 40 hour in order.
        private List<List<string>> SortAvailbility(List<List<string>> avail)
        {
            List<List<string>> sorted = avail;

            int i, j;
            int N = sorted.Count;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && (int.Parse(sorted[i][1]) < int.Parse(sorted[i - 1][1])); i--)
                {
                    exchange(sorted, i, i - 1);
                }
            }

            return sorted;
        }

        // Exchanges the position of two objects in the list
        private static void exchange(List<List<string>> data, int m, int n)
        {
            List<string> temp;

            temp = data[m];
            data[m] = data[n];
            data[n] = temp;
        }

        // There are some cases where the schedule will not be filled fully, but these are rare ones.
        // Automatic scheduling
        public void AutomaticScheduling(int department)
        {

            if (this.IsScheduleFull() == false)
            {
                List<List<string>> departmentAvail = this.GetAvailabilityOfDepartment(department);

                departmentAvail = this.SortAvailbility(departmentAvail);


                // Fill in the normal auto schedule
                this.FillAutoSchedule(departmentAvail, department);

                //if(this.IsScheduleFull)

                // Rearrange some shifts to try to make it full if its not full
                this.ReArrangeShiftsToComplete(departmentAvail, department);
            }

            // Schedule is full so nothing to do
        }

        #region Nomral Auto Scheduling

        private void FillAutoSchedule(List<List<string>> sortedAvail, int department)
        {
            // Begins with monday = 1 and ends on sunday = 7
            for(int day = 1; day < 8; day++)
            {
                // Stop with checking if its full
                if (this.IsScheduleFull() == false)
                {

                    // Checking if there are any shifts left on the selected day
                    if (this.ShiftIsFull(day) == false)
                    {
                        // Begins with the last person in the list as it is sorted.
                        // The list is sorted from 0 to 40 hour contract.
                        for (int empIndex = sortedAvail.Count - 1; empIndex > -1; empIndex--)
                        {

                            if (this.IsScheduleFull() == false)
                            {

                                if (this.ShiftIsFull(day) == false)
                                {

                                    User empToAdd = this.GetUserByID(int.Parse(sortedAvail[empIndex][0]));
                                    int amountOfWorkedHours = this.TotalAssignedShfits(empToAdd);
                                    int contractHour = int.Parse(sortedAvail[empIndex][1]);

                                    // We only need to check for the employees that don't have met their maximum shifts
                                    if ((Shift.AssignedEnough(amountOfWorkedHours, contractHour) == false && contractHour != 0) || (contractHour == 0 && amountOfWorkedHours < 9))
                                    {
                                        // Checking if the employee is available for this day
                                        if (sortedAvail[empIndex][1 + day].Equals("true") == true)
                                        {
                                            // Assign the selected employee to shifts
                                            this.FillShift(day, empToAdd, sortedAvail, department, empIndex);
                                        }
                                        // Employee is not available for the selected day
                                    }
                                    // Employee has met their maximum amount of shifts
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    // There are no shifts empty on the selected day
                }
                else
                {
                    break;
                }
            }
        }

        private void FillShift(int day, User empToAdd, List<List<string>> sortedAvail, int department, int empIndex)
        {
            Shift shift = this.GetShift(day);

            for(int shiftNumber = 0; shiftNumber < 3; shiftNumber++)
            {
                // Stop with auto schedule if the schedule is full
                if (this.IsScheduleFull() == false)
                {

                    string shiftName = Shift.GetShiftTime(shiftNumber);
                    List<User> usersInShift = shift.GetShiftListByTime(shiftName);

                    int amountOfWorkedHours = this.TotalAssignedShfits(empToAdd);
                    int contractHour = int.Parse(sortedAvail[empIndex][1]);

                    // If the person has enough hours, then there is no need to fill him more shifts.
                    if ((Shift.AssignedEnough(amountOfWorkedHours, contractHour) == false && contractHour != 0) || (contractHour == 0 && amountOfWorkedHours < 9))
                    {
                        // Any spots left in the selected time of day
                        if (shift.TimeIsFull(usersInShift, shiftName) == false)
                        {

                            // We don't need to assign the user if the emp is already in the shift
                            if (usersInShift.Contains(empToAdd) == false)
                            {
                                // WE need to check if the user is not already in the shift
                                // So checking that there is no presence

                                // Checking if adding the employee will cause any problems for another employee
                                bool canBeAdded = this.CanBeAddedWithoutProblem(shift, empToAdd, shiftName, sortedAvail);

                                List<string> avail = sortedAvail[empIndex];
                                //List<string> avail = this.GetUserAvailability(empToAdd.ID);

                                if (canBeAdded == true)
                                {
                                    // Add employee to the shift

                                    int result = shift.AddOrRemoveShift(empToAdd, shiftName, this.TotalAssignedShfits(empToAdd), avail, shift.GetShiftPresence(empToAdd), false);
                                    if (result == 0)
                                    {
                                        List<string> firstPresence = shift.GetShiftPresence(empToAdd);

                                        if (firstPresence.Count == 1) // New shift created in the database
                                        {
                                            SchedulerController.AddEmployeeShift(empToAdd, this.CurrentWeek, shift.Day, shiftName, department);
                                        }
                                        else // Shift changed 
                                        {
                                            SchedulerController.ChangeShift(empToAdd, this.CurrentWeek, shift.Day, department, firstPresence);
                                        }
                                    }
                                }
                                else
                                {
                                    // Check if this is the only shift that the person can be added to, if so still add the person
                                    int possibleShiftsLeft = this.GetPossibleShiftsForTheWeek(avail, null);
                                    int shiftsNeededForTheWeek = this.GetMinShifts(empToAdd, int.Parse(avail[1]));

                                    // Because we checked that the employee is able to be scheduled in this shift and time, we know that if the possible shift = 1, then this shift and time is the only one available
                                    if (possibleShiftsLeft == 1 && shiftsNeededForTheWeek == 1)
                                    {
                                        // Still add it
                                        int result = shift.AddOrRemoveShift(empToAdd, shiftName, this.TotalAssignedShfits(empToAdd), avail, shift.GetShiftPresence(empToAdd), false);
                                        if (result == 0)
                                        {
                                            List<string> firstPresence = shift.GetShiftPresence(empToAdd);

                                            if (firstPresence.Count == 1) // New shift created in the database
                                            {
                                                SchedulerController.AddEmployeeShift(empToAdd, this.CurrentWeek, shift.Day, shiftName, department);
                                            }
                                            else // Shift changed 
                                            {
                                                SchedulerController.ChangeShift(empToAdd, this.CurrentWeek, shift.Day, department, firstPresence);
                                            }
                                        }
                                    }

                                    // Not possible to add it
                                }
                            }

                        }
                    }
                    // Shift is full
                }
            }
        }

        private bool CanBeAddedWithoutProblem(Shift shiftToCheck, User toBeAdded, string shiftToCheckName, List<List<string>> sortedAvail)
        {
            // This list will contain the availability of the employees with either 24 or 40 hour contracts.
            // Adding the emps with 24 and 40 hour contract in that order, because the initial list is already sorted
            List<List<string>> sortedAvailForMinEmp =this.GetAvailForNonFlexAndSingleUser(sortedAvail, toBeAdded);

            // Recreating the shift and using this as a temporary one to add the person to check if it doesn't create problems for another employees
            Shift newShift = this.DuplicateShift(shiftToCheck);

            // adding the Employee to the new shift temporary
            newShift.GetShiftListByTime(shiftToCheckName).Add(toBeAdded);

            // We need to check for each user separately
            for (int empIndex = (sortedAvailForMinEmp.Count - 1); empIndex > -1; empIndex--)
            {
                // The number of possible shifts for the week for the selected employee
                int possibleShifts = this.GetPossibleShiftsForTheWeek(sortedAvailForMinEmp[empIndex], newShift);

                User empToCheck = this.GetUserByID(int.Parse(sortedAvailForMinEmp[empIndex][0]));

                // Checking if the amount of needed shifts is smaller than the available shifts.
                // If its true, then it will return false.
                if (possibleShifts < this.GetMinShifts(empToCheck, int.Parse(sortedAvailForMinEmp[empIndex][1])))
                {
                    return false;
                }
            }

            // There was no problem with this person being added to the given shift and time
            return true;
        }

        private int GetPossibleShiftsForTheWeek(List<string> avail, Shift newShift)
        {
            // The number of possible shifts for the week for the selected employee
            int possibleShifts = 0;

            User empToCheck = this.GetUserByID(int.Parse(avail[0]));

            // Counting the available shifts for each day and then adding them up.
            for (int day = 1; day < 8; day++)
            {

                // Is the person available on the selected day?
                if (avail[1 + day].Equals("true") == true)
                {
                    // Counted the amount of available shifts for the selected employee
                    int availableShiftsSelectedDay = 0;

                    // The shift that will be checked
                    Shift shift;

                    // We want to use the fake shift to check instead of the normal one.
                    if (newShift != null)
                    {
                        if((int)newShift.Day == day)
                        {
                            shift = newShift;
                        }
                        else
                        {
                            shift = this.GetShift(day);
                        }
                    }
                    else
                    {
                        shift = this.GetShift(day);
                    }

                    // The presence of this employee on this day
                    List<string> PresenceOfEmp = shift.GetShiftPresence(empToCheck);

                    // Is the employee in two shifts already?
                    if (PresenceOfEmp.Count < 2)
                    {
                        //
                        bool shiftCheck = false;

                        if (newShift == null)
                        {
                            shiftCheck = (this.ShiftIsFull(day) == false);
                        }
                        else
                        {
                            shiftCheck = ((this.ShiftIsFull(day) == false && day != (int)newShift.Day) || day == (int)newShift.Day);
                        }

                        // No need to check if the shift is already full if its not the fake shift
                        if ( shiftCheck)
                        {
                            for (int shiftNumber = 0; shiftNumber < 3; shiftNumber++)
                            {
                                string shiftName = Shift.GetShiftTime(shiftNumber);
                                List<User> usersInShift = shift.GetShiftListByTime(shiftName);

                                if (shift.TimeIsFull(usersInShift, shiftName) == false)
                                {
                                    // Is the selected employee already in the shift?
                                    if (usersInShift.Contains(empToCheck) == false)
                                    {
                                        availableShiftsSelectedDay++;
                                    }
                                    // Employee is in the shift
                                }
                                // This time of the shift is full
                            }
                        }
                        // shift is full

                    }
                    // Employee is in two shifts on the selected day


                    // Getting the real available possible shifts for the selected employee for the selected day
                    availableShiftsSelectedDay = this.GetRealAvailableShiftsOfTheDay(PresenceOfEmp, availableShiftsSelectedDay);

                    // Adding the possible for the selected day to the total of the week
                    possibleShifts += availableShiftsSelectedDay;
                }
            }

            return possibleShifts;
        }

        // This is needed for method: 'CanBeAddedWithoutProblem'
        // This method returns a List of availability of non flex workers, so 24 and 40 hour contracts, and the employee who we don't want to check
        private List<List<string>> GetAvailForNonFlexAndSingleUser(List<List<string>> avail, User notToAdd)
        {
            List<List<string>> result = new List<List<string>>();

            // The user to be checked shouldn't be added to the list, as we want to check it for other people
            foreach (List<string> empAvail in avail)
            {
                if (int.Parse(empAvail[1]) != 0 && int.Parse(empAvail[0]) != notToAdd.ID)
                {
                    result.Add(empAvail);
                }
            }

            return result;
        }

        // Duplicate the shift and returning this without any reference.
        private Shift DuplicateShift(Shift shift)
        {
            Shift newShift = new Shift(shift.Day);
            newShift.Morning = new List<User>(shift.Morning);
            newShift.Afternoon = new List<User>(shift.Afternoon);
            newShift.Evening = new List<User>(shift.Evening);

            return newShift;
        }

        // Because of the some rules, we need to check that we don't overocunt shifts as possible.
        private int GetRealAvailableShiftsOfTheDay(List<string> presence, int availableCount)
        {
            int result = availableCount;

            if(availableCount > 2)
            {
                result = 2;
            }
            else if(availableCount == 2 && presence.Count == 1)
            {
                result = 1;
            }

            return result;
        }

        // Returning the minimal amount of shifts still needed after checking how many there are already assigned
        private int GetMinShifts(User user, int contracthours)
        {
            int amountOfAlreadyAssigned = this.TotalAssignedShfits(user);

            return (contracthours / 4) - amountOfAlreadyAssigned;

        }

        private bool IsScheduleFull()
        {
            int shiftcount = 0;
            foreach (Shift shift in this.Shifts)
            {
                shiftcount += shift.Morning.Count;
                shiftcount += shift.Afternoon.Count;
                shiftcount += shift.Evening.Count;
            }

            // The total minimum shifts for a week is 53.
            if (shiftcount >= 53)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Switch up some shifts to try to complete the schedule
        private void ReArrangeShiftsToComplete(List<List<string>> sortedAvail, int department)
        {
            if(this.IsScheduleFull() == false)
            {
                // The empty shifts
                List<List<int>> amountOfShiftsOver = this.AmountOfShiftsOver();

                for(int i = 0; i < amountOfShiftsOver.Count; i++)
                {
                    int day = amountOfShiftsOver[i][0];
                    Shift shiftToCheck = this.GetShift(day);
                    string shiftName = Shift.GetShiftTime(amountOfShiftsOver[i][1]);

                    // The already filled users
                    List<User> usersInShift = shiftToCheck.GetShiftListByTime(shiftName);

                    this.FindRearrange(sortedAvail, department, day, shiftToCheck, usersInShift, shiftName);

                }
            }
        }

        private bool FindRearrange(List<List<string>> sortedAvail, int department, int day, Shift shiftToCheck, List<User> usersInShift, string shiftName)
        {
            // Going by every employee until two are found.
            // One that can fill in the shift and another one that can fill for the shift the first one was in before
            foreach (List<string> avail in sortedAvail)
            {
                // Selected emp is available for the empty shift?
                if (avail[1 + day].Equals("true") == true)
                {
                    User empToCheck = this.GetUserByID(int.Parse(avail[0]));
                    List<string> presence = shiftToCheck.GetShiftPresence(empToCheck);

                    // Is the emp already in the shift?
                    if (usersInShift.Contains(empToCheck) == false)
                    {
                        // The employee can still be assigned for the selected day without going over the presence rule
                        if (presence.Count < 2)
                        {
                            // Looking for a shift that can be switched to another person
                            for (int dayToReArrange = 1; dayToReArrange < 8; dayToReArrange++)
                            {
                                // The day of the empty shift should be skipped.
                                if (dayToReArrange != day)
                                {
                                    // We want to find a shift where the first person is in to perhaps switch from.
                                    Shift shiftOfDay = this.GetShift(dayToReArrange);
                                    List<string> presenceOfDay = shiftOfDay.GetShiftPresence(empToCheck);

                                    // The user is scheduled on this day?
                                    if (presenceOfDay.Count > 0)
                                    {
                                        for (int shiftNumber = 0; shiftNumber < 3; shiftNumber++)
                                        {
                                            string shiftNameToCheck = Shift.GetShiftTime(shiftNumber);

                                            // Is the person scheduled to this day?
                                            if (presenceOfDay.Contains(shiftNameToCheck) == true)
                                            {
                                                // A User to find a replacement with
                                                User empToSwitchWith = this.GetShiftReplacement(sortedAvail, dayToReArrange, shiftOfDay, shiftNumber, empToCheck.ID);

                                                // If an emp is found, they can switch
                                                if (empToSwitchWith != null)
                                                {
                                                    // Remove first user from initial shift
                                                    int firstShiftRemoval = shiftOfDay.AddOrRemoveShift(empToCheck, shiftNameToCheck, this.TotalAssignedShfits(empToCheck), avail, presenceOfDay, false);
                                                    if (firstShiftRemoval == 1)
                                                    {
                                                        List<string> firstShiftPresence = shiftOfDay.GetShiftPresence(empToCheck);

                                                        if (firstShiftPresence.Count == 0)
                                                        {
                                                            SchedulerController.RemoveEmployeeShift(empToCheck, this.CurrentWeek, department, shiftOfDay.Day);
                                                        }
                                                        else // Shift changed
                                                        {
                                                            SchedulerController.ChangeShift(empToCheck, this.CurrentWeek, shiftOfDay.Day, department, firstShiftPresence);
                                                        }               
                                                    }

                                                    // Add user to new shift
                                                    int fillInShift = shiftToCheck.AddOrRemoveShift(empToCheck, shiftName, this.TotalAssignedShfits(empToCheck), avail, presence, false);
                                                    
                                                    if (fillInShift == 0)
                                                    {

                                                        List<string> secondShiftPresence = shiftToCheck.GetShiftPresence(empToCheck);

                                                        if (secondShiftPresence.Count == 1) // New shift created in the database
                                                        {
                                                            SchedulerController.AddEmployeeShift(empToCheck, this.CurrentWeek, shiftToCheck.Day, shiftName, department);
                                                        }
                                                        else // Shift changed 
                                                        {
                                                            SchedulerController.ChangeShift(empToCheck, this.CurrentWeek, shiftToCheck.Day, department, secondShiftPresence);
                                                        }
                                                    }


                                                    List<string> availOfFoundEmp = this.GetUserAvailability(empToSwitchWith.ID);
                                                    List<string> presenceOfFoundUser = shiftOfDay.GetShiftPresence(empToSwitchWith);

                                                    // // Add found user to replace in first user shift
                                                    int replaceNewEmptyShift = shiftOfDay.AddOrRemoveShift(empToSwitchWith, shiftNameToCheck, this.TotalAssignedShfits(empToSwitchWith), availOfFoundEmp, presenceOfFoundUser, false);
                                                    if (replaceNewEmptyShift == 0)
                                                    {

                                                        List<string> thirdShiftPresence = shiftOfDay.GetShiftPresence(empToSwitchWith);

                                                        if (thirdShiftPresence.Count == 1) // New shift created in the database
                                                        {
                                                            SchedulerController.AddEmployeeShift(empToSwitchWith, this.CurrentWeek, shiftOfDay.Day, shiftNameToCheck, department);
                                                        }
                                                        else // Shift changed 
                                                        {
                                                            SchedulerController.ChangeShift(empToSwitchWith, this.CurrentWeek, shiftOfDay.Day, department, thirdShiftPresence);
                                                        }
                                                    }

                                                    return true; // Do nothing, but just end the whole method
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // Emp is already in the shift
                }
                // Emp not available
            }

            return false; // Do nothing, but just end the whole method
        }


        private User GetShiftReplacement(List<List<string>> sortedAvail, int dayToCheck, Shift shiftToCheck, int shiftNumber, int EmpIdNotToCheck)
        {
            User result = null;

            foreach(List<string> avail in sortedAvail)
            {
                // We should skip the person that we want to swtich shifts with
                if (int.Parse(avail[0]) != EmpIdNotToCheck)
                {
                    User empToCheck = this.GetUserByID(int.Parse(avail[0]));
                    string shiftName = Shift.GetShiftTime(shiftNumber);

                    int amountOfWorkedHours = this.TotalAssignedShfits(empToCheck);
                    int contractHour = int.Parse(avail[1]);

                    // If the employee already has
                    if ((Shift.AssignedEnough(amountOfWorkedHours, contractHour) == false && contractHour != 0) || (contractHour == 0 && amountOfWorkedHours < 9))
                    {
                        // The employee is available for that day
                        if (avail[1 + dayToCheck].Equals("true") == true)
                        {
                            List<string> presence = shiftToCheck.GetShiftPresence(empToCheck);

                            // Person can still be assigned to the shift and not present in the selected shift slot
                            if (presence.Count < 2 && (presence.Contains(shiftName) == false))
                            {
                                // We can switch with this person for the shifts.
                                result = empToCheck;
                                break;
                            }

                        }
                    }
                }
            }

            return result;
        }

        private List<List<int>> AmountOfShiftsOver()
        {
            // A list of left over shifts
            List<List<int>> amountOfShiftsOver = new List<List<int>>(); // (day, shiftNumber)

            foreach(Shift shift in this.shifts)
            {
                // Is the shift full?
                if(this.ShiftIsFull((int)shift.Day) == false)
                {
                    for(int shiftNumber = 0; shiftNumber < 3; shiftNumber++)
                    {
                        string shiftName = Shift.GetShiftTime(shiftNumber);
                        List<User> usersInShift = shift.GetShiftListByTime(shiftName);

                        // Checking if the selected time slot is full already or not
                        if(shift.TimeIsFull(usersInShift, shiftName) == false)
                        {
                            // We need this to save in the list
                            int day = (int)shift.Day;
                            int amountOfEmptySlots = 0;

                            // Saturday, sunday and afternoon shifts all have 3 employees slots, while the other have 2 slots for employees
                            if (shift.Day == Day.SATURDAY || shift.Day == Day.SUNDAY || shiftName.Equals("afternoon"))
                            {
                                amountOfEmptySlots = (3 - usersInShift.Count);
                            }
                            else
                            {
                                amountOfEmptySlots = (2 - usersInShift.Count);
                            }

                            // Adding the left over shifts position to the list
                            // This needs to be repeated the amount of slots that are empty
                            for (int count = 0; count < amountOfEmptySlots; count++)
                            {
                                List<int> leftOverShift = new List<int>();
                                leftOverShift.Add(day);
                                leftOverShift.Add(shiftNumber);

                                // Adding the left over shift to the list
                                amountOfShiftsOver.Add(leftOverShift);
                            }
                        }
                    }
                }
            }

            return amountOfShiftsOver;
        }

        #endregion
    }
}
