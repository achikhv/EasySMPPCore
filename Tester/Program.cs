/*
 * EasySMPP - SMPP protocol library for fast and easy
 * SMSC(Short Message Service Centre) client development
 * even for non-telecom guys.
 * 
 * Easy to use classes covers all needed functionality
 * for SMS applications developers and Content Providers.
 * 
 * Written for .NET 2.0 in C#
 * 
 * Copyright (C) 2006 Balan Andrei, http://balan.name
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://easysmpp.sf.net/
 * 
 * 
 * "Support Open Source software. What about a donation today?"
 *
 * 
 * File Name: Program.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;
using System.Collections.Generic;
using System.Text;

using EasySMPP;
using System.Threading;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            SMPPClient client = new SMPPClient();
            SMSC sms = new SMSC()
            {
                Host = "smpp.smsc.ru",
                Port = 3700,
                SystemId = "SystemId",
                Password = "Password",
                SourceTon = 5,
                SourceNpi = 1,
                AddrTon = 1,
                AddrNpi = 1,
                SystemType = ""
            };

            client.AddSMSC(sms);

            if (client.Connect())
            {
                int res = client.SendSms("from", "to", "message");
                Console.WriteLine(res);

                client.Disconnect();
                client.ClearSMSC();
            }

            Console.ReadLine();
        }
    }
}
