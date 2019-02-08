/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package logparser;

/**
 *
 * @author cortlim
 */
public class TimeConverter {

    public int hr = 0, min = 0, sec = 0, hrtemp = 0;
    public double dsec;
    public String day = " AM";

    public TimeConverter(String time)
    {
        //initializes the timeconverter class with the base time from the logs
        String strHr, strMin, strSec;
        strHr = (String) time.subSequence(0, 2);
        strMin = (String) time.subSequence(3, 5);
        strSec = (String) time.subSequence(6, 8);
        hr = Integer.parseInt(strHr);
        min = Integer.parseInt(strMin);
        sec = Integer.parseInt(strSec);
        dsec = sec;
    }

    /*
     * returns the time of the class
     */
    public String getTime()
    {

        String timestamp;
        sec = (int) dsec;
        if (hr >= 12)
        {
            day = " PM";
            if (hr == 12)
                hrtemp = hr;
            else
                hrtemp = hr - 12;
        }
        else
            day = " AM";
        if (sec < 10)
            timestamp = String.valueOf(hrtemp) + ":" + String.valueOf(min) + ":0" + String.valueOf(sec) + day;
        else
            timestamp = String.valueOf(hrtemp) + ":" + String.valueOf(min) + ":" + String.valueOf(sec) + day;
        return (timestamp);
    }

    /*
     * adds time from the duration of the log to the base time of the TimeConverter class
     * also returns the time after adding
     */
    public String addTime(double strSec)
    {

        String timestamp;
        int temp = 0;
        dsec = dsec + strSec;
        /*if((strSec >= 0.5 && strSec < 1.0) || (strSec >= 1.5 && strSec <2.0))
            sec++;*/
        if(dsec >= 60)
        {
            temp = (int) (dsec / 60);
            dsec = dsec%60;
            min = min + temp;
        }
        if(min >= 60)
        {
            temp = min/60;
            min = min%60;
            hr = hr + temp;
        }
        sec = (int) dsec;
        if (hr >= 12)
        {
            day = " PM";
            if (hr == 12)
                hrtemp = hr;
            else
                hrtemp = hr - 12;
        }
        else
            day = " AM";
        if (sec < 10)
            timestamp = String.valueOf(hrtemp) + ":" + String.valueOf(min) + ":0" + String.valueOf(sec) + day;
        else
            timestamp = String.valueOf(hrtemp) + ":" + String.valueOf(min) + ":" + String.valueOf(sec) + day;
        return (timestamp);
    }
}
