﻿using System.ComponentModel;
using System.Configuration.Install;

namespace CoAd.Fo.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
