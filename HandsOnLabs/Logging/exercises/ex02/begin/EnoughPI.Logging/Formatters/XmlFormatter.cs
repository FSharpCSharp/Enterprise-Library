//===============================================================================
// Microsoft patterns & practices
// Enterprise Library 6 and Unity 3 Hands-on Labs
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters; 

namespace EnoughPI.Logging.Formatters
{
    [ConfigurationElementType(typeof(CustomFormatterData))]
    public class XmlFormatter: LogFormatter
    {
        private NameValueCollection Attributes = null;

        public XmlFormatter(NameValueCollection attributes)
        {
            this.Attributes = attributes;
        }

        public XmlFormatter(string prefix, string ns)
        {
            this.Attributes = new NameValueCollection();
            this.Attributes["prefix"] = prefix;
            this.Attributes["namespace"] = ns;
        }

        public override string Format(LogEntry log)
        {
            string prefix = this.Attributes["prefix"];
            string ns = this.Attributes["namespace"];

            using (StringWriter s = new StringWriter())
            {
                XmlTextWriter w = new XmlTextWriter(s);
                w.Formatting = Formatting.Indented;
                w.Indentation = 2;
                w.WriteStartDocument(true);
                w.WriteStartElement(prefix, "logEntry", ns);
                w.WriteAttributeString("Priority", ns,
                    log.Priority.ToString(CultureInfo.InvariantCulture));
                w.WriteElementString("Timestamp", ns, log.TimeStampString);
                w.WriteElementString("Message", ns, log.Message);
                w.WriteElementString("EventId", ns,
                    log.EventId.ToString(CultureInfo.InvariantCulture));
                w.WriteElementString("Severity", ns, log.Severity.ToString());
                w.WriteElementString("Title", ns, log.Title);
                w.WriteElementString("Machine", ns, log.MachineName);
                w.WriteElementString("AppDomain", ns, log.AppDomainName);
                w.WriteElementString("ProcessId", ns, log.ProcessId);
                w.WriteElementString("ProcessName", ns, log.ProcessName);
                w.WriteElementString("Win32ThreadId", ns, log.Win32ThreadId);
                w.WriteElementString("ThreadName", ns, log.ManagedThreadName);
                w.WriteEndElement();
                w.WriteEndDocument();

                return s.ToString();
            }
        }

    }
}