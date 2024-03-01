using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class LeaveStatus
{
    // Enum representing different leave statuses
    public enum LeaveStatuses
    {
        [Display(Name = "Pending")] // Display attribute for Pending status
        Pending = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "Rejected")]
        Rejected = 3,
        [Display(Name = "Cancelled")]
        Cancelled = 4,
    }

    // Method to get the display name of a leave status
    public static string GetLeaveStatusDisplayName(int status)
    {
        return status switch
        {
            (int)LeaveStatuses.Pending => GetDisplayName(LeaveStatuses.Pending),
            (int)LeaveStatuses.Approved => GetDisplayName(LeaveStatuses.Approved),
            (int)LeaveStatuses.Rejected => GetDisplayName(LeaveStatuses.Rejected),
            (int)LeaveStatuses.Cancelled => GetDisplayName(LeaveStatuses.Cancelled),
            _ => "N/A",
        };
    }

    // Method to get the display name from Display attribute of an enum value
    public static string GetDisplayName(Enum enumValue) 
        => enumValue.GetType()
        .GetMember(enumValue.ToString())
        .First()
        .GetCustomAttribute<DisplayAttribute>()
        .GetName();
}

public class Program
{
    public static void Main()
    {
        var status = (int) LeaveStatus.LeaveStatuses.Pending;
        Console.WriteLine(LeaveStatus.GetLeaveStatusDisplayName(status));
        Console.ReadKey();
    }
}