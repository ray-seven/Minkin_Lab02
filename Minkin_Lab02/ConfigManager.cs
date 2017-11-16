﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Minkin_Lab02
{
    internal class ConfigManager
    {
        public string ConfigPath { get; private set; }

        public ConfigManager()
        {
            ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
        }

        public bool Exist()
        {
            return File.Exists(ConfigPath);
        }

        public Config ReadFromFile()
        {
            Config config = new Config();
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (FileStream filestream = new FileStream(ConfigPath, FileMode.OpenOrCreate))
            {
                config = (Config)serializer.Deserialize(filestream);
            }
            return config;
        }

        public void WriteToFile(Config config)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (FileStream filestream = new FileStream("config.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(filestream, config);
            }
        }
    }
}