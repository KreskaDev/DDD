﻿using System.Diagnostics;
using System.IO;
using System.Text;

namespace DddSob.Storage.Persistance.Nh.Configurations
{
    internal class DebugWriter : TextWriter
    {
        public override void WriteLine(string value)
        {

            Debug.WriteLine(value);
            base.WriteLine(value);
        }

        public override void Write(string value)
        {
            Debug.Write(value);
            base.Write(value);
        }

        public override Encoding Encoding => Encoding.Unicode;
    }
}