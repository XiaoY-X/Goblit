using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traductor : MonoBehaviour
{
    public static string translate(String morsed)
    {
        if (morsed.Contains("........"))
        {
            return "";
        }
        String res = "";
        Boolean correctEnd = morsed.EndsWith('/');
        string[] divided = morsed.Split('/');
        if (correctEnd)
        {
            for (int i = 0; i < divided.Length; i++)
            {
                res += letter(divided[i]);
            }
        }
        else
        {
            for (int i = 0; i + 1 < divided.Length; i++)
            {
                res += letter(divided[i]);
            }
            res += divided[divided.Length - 1];
        }

        return res;
    }
    public static string letter(String single)
    {
        String res;
        switch (single)
        {
            case "":
                res = " ";
                break;
            case ".----":
                res = "1";
                break;
            case "..---":
                res = "2";
                break;
            case "...--":
                res = "3";
                break;
            case "....-":
                res = "4";
                break;
            case ".....":
                res = "5";
                break;
            case "-....":
                res = "6";
                break;
            case "--...":
                res = "7";
                break;
            case "---..":
                res = "8";
                break;
            case "----.":
                res = "9";
                break;
            case "-----":
                res = "0";
                break;
            case ".-":
                res = "a";
                break;
            case "-...":
                res = "b";
                break;
            case "-.-.":
                res = "c";
                break;
            case "-..":
                res = "d";
                break;
            case ".":
                res = "e";
                break;
            case "..-.":
                res = "f";
                break;
            case "--.":
                res = "g";
                break;
            case "....":
                res = "h";
                break;
            case "..":
                res = "i";
                break;
            case ".---":
                res = "j";
                break;
            case "-.-":
                res = "k";
                break;
            case ".-..":
                res = "l";
                break;
            case "--":
                res = "m";
                break;
            case "-.":
                res = "n";
                break;
            case "--.--":
                res = "ñ";
                break;
            case "---":
                res = "o";
                break;
            case ".--.":
                res = "p";
                break;
            case "--.-":
                res = "q";
                break;
            case ".-.":
                res = "r";
                break;
            case "...":
                res = "s";
                break;
            case "-":
                res = "t";
                break;
            case "..-":
                res = "u";
                break;
            case "...-":
                res = "v";
                break;
            case ".--":
                res = "w";
                break;
            case "-..-":
                res = "x";
                break;
            case "-.--":
                res = "y";
                break;
            case "--..":
                res = "z";
                break;
            default:
                res = single;

                break;
        }
        return res;
    }
}
