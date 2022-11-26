using System.Collections.Generic;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Class
{
    public class Shift
    {
        private Day day;

        private List<User> morning;
        private List<User> afternoon;
        private List<User> evening;

        // Default shift numbers for morning and evening on weekdays.
        // The default max shifts for evening is 3
        private int maxShifts = 2;

        public int MaxShifts { get { return this.maxShifts; } }

        public List<User> Morning { get { return this.morning; } set { this.morning = value; } }
        public List<User> Afternoon {  get { return this.afternoon; } set { this.afternoon = value; } }
        public List<User> Evening { get { return this.evening; } set { this.evening = value; } }

        public Day Day { get { return this.day; } }

        public Shift(Day day)
        {
            this.day = day;

            this.afternoon = new List<User>();
            this.morning = new List<User>();
            this.evening = new List<User>();

            if (day == Day.SATURDAY || day == Day.SUNDAY)
            {
                this.maxShifts = 3;
            }
        }

        // Person will be added to the shift if he is available and not in the shift.
        // If the person is already assigned, then he/she will be removed from the shift.
        public int AddOrRemoveShift(User userToAdd, string time, int amountOfShifts, List<string> availability, List<string> presence, bool ignoreLimit)
        {
            // Return results:
            // 0 = succes: employee added
            // 1 =  succes: employee removed
            // -1 = unsuccesfull; shift is full
            // -2 = unsuccesfull; person is already in shift
            // -3 = unsuccesfull: Not available
            // -4 = unsuccesfull: Max shifts of the week already met
            // -5 = unsuccesfull: Max shifts of the day met

            List<User> shifts = this.GetShiftListByTime(time);
            string shiftTime = time.ToLower();
            int dayNumber = (int)this.day;

            if (!shifts.Contains(userToAdd))
            {
                if (this.TimeIsFull(shifts, time) == false)
                {
                    if (availability[dayNumber + 1].Equals("true") || ignoreLimit)
                    {
                        if(presence.Count < 2 || ignoreLimit)
                        {
                            int contractHour = int.Parse(availability[1]);
                            if ( (AssignedEnough(amountOfShifts, contractHour) == false && contractHour != 0) || ignoreLimit || (contractHour == 0 && amountOfShifts < 9))    // Checking if the user already has reached his maximum amount of hours.
                            {
                                shifts.Add(userToAdd);
                                return 0; // Succes : Person added
                            }
                            else
                            {
                                return -4; // Person has met their limit for the week
                            }
                        }
                        else
                        {
                            return -5; // Person has met their limit for the day
                        }
                    }
                    else
                    {
                        return -3; // Error: Person is not available for this shift
                    }
                }
                else
                {
                    return -1; // Error: Shift is full
                }
            }
            else
            {
                shifts.Remove(userToAdd);
                return 1; // Succes: Person is removed
            }
        }

        // Checking if the List<User> for the given timeSlot is full or not
        public bool TimeIsFull(List<User> shifts, string time)
        {
            if (time.Equals("afternoon"))
            {
                if (shifts.Count < 3)
                    return false; // Still some space left
            }
            else
            {
                if (shifts.Count < this.maxShifts)
                    return false; // Still some space left
            }

            return true; // The shift is full
        }

        // Returns the right shift list of users for the requested time slot.
        public List<User> GetShiftListByTime(string time)
        {
            string shiftMoment = time.ToLower();
            if (shiftMoment.Equals("morning"))
                return this.morning;
            else if (shiftMoment.Equals("afternoon"))
                return this.afternoon;
            else
                return this.evening;
        }

        // Returns the time slot in string
        public static string GetShiftTime(int columnIndex)
        {
            // Timetype:
            // 0 = morning
            // 1 = afternoon
            // 2 = evening

            string time = "morning";

            if (columnIndex == 1)
                time = "afternoon";
            else if (columnIndex == 2)
                time = "evening";

            return time;
        }

        // Returns a bool regarding if the person has met their limit of assigned shifts in the current week.
        // If its true, then the person shouldn't be able to get scheduled again.
        public static bool AssignedEnough(int amount, int contractHours)
        {
            // Contract type:
            // 40 hour --> 10 shifts
            // 24 hour --> 6 shifts
            // 0 hour  --> 9 shifts or less


            if (contractHours == 0 && amount <= 9)
            {
                return true;
            }
            else if (amount >= (contractHours / 4) && contractHours != 0)
            {
                return true;
            }
            return false;
        }


        // Returns a string containing information of the shifts on this day. Who is scheduled in what timeslot.
        public string GetShiftInformation(string date)
        {
            string day = this.day.ToString().Substring(0, 1).ToLower() + this.day.ToString().ToLower().Substring(1);

            string result = $"{date}\n{day}";
            result = result + $"\n\n{this.GetShiftDetails("Morning shift:", this.GetShiftListByTime("morning"))}";
            result = result + $"\n\n{this.GetShiftDetails("Afternoon shift:", this.GetShiftListByTime("afternoon"))}";
            result = result + $"\n\n{this.GetShiftDetails("Evening shift:", this.GetShiftListByTime("evening"))}";

            return result;
        }

        private string GetShiftDetails(string time, List<User> shiftList)
        {
            string result = time;
            foreach (User user in shiftList)
            {
                result = result + $"\n{user.FirstName} {user.SurName}";
            }

            return result;
        }

        public List<string> GetShiftPresence(User user)
        {
            List<string> result = new List<string>();

            if (this.morning.Contains(user))
                result.Add("morning");
            if (this.afternoon.Contains(user))
                result.Add("afternoon");
            if (this.evening.Contains(user))
                result.Add("evening");

            return result;
        }
    }
}
