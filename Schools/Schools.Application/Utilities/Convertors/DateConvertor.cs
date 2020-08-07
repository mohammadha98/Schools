using System;
using System.Globalization;

namespace Schools.Application.Utilities.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsiWithMount(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            var date= pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
            var mount = date.Split('/')[1];
            switch (mount)
            {
                case "01":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "فروردین" + " " + pc.GetYear(value);
                    break;
                case "02":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "اردیبهشت" + " " + pc.GetYear(value);
                    break;
                case "3":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "خرداد" + " " + pc.GetYear(value);
                    break;
                case "04":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "تیر" + " " + pc.GetYear(value);
                    break;
                case "05":
                     date = pc.GetDayOfMonth(value).ToString("d") + " " + "مرداد" + " " + pc.GetYear(value);
                    break;
                case "06":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "شهریور" + " " + pc.GetYear(value);
                     break;
                case "07":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "مهر" + " " + pc.GetYear(value);
                    break;
                case "08":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "آبان" + " " + pc.GetYear(value);
                    break;
                case "09":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "آذر" + " " + pc.GetYear(value);
                    break;
                case "10":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "دی" + " " + pc.GetYear(value);
                    break;
                case "11":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "بهمن" + " " + pc.GetYear(value);
                    break;
                case "12":
                    date = pc.GetDayOfMonth(value).ToString("d") + " " + "اسفند" + " " + pc.GetYear(value);
                    break;
            }
            return date;
        }
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
    }
}