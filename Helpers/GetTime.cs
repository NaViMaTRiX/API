namespace API.Helper;

public class GetTime
{
    public static DateTime GetCurrentTime()
    {
        // Is not working
        var serverTime = DateTime.Now;
        var localTime =
            TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Egypt Standart Time");
        return localTime;
    }
}