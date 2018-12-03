using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace QuizzicalFBLA.ViewModels
{
    public class TermsOfServiceViewModel : BaseViewModel
    {
        public TermsOfServiceViewModel ()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(TermsOfServiceViewModel)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("QuizzicalFBLA.tos.txt");

                using (var reader = new StreamReader(stream))
                {
                    Terms = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
            }

            OnPropertyChanged("Terms");
        }

        public String Terms { get; set; } = "Loading Terms of Service";

    }
}
