using DevExpress.Office.Services;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ContentAnalyzer {
    public partial class Form1 : RibbonForm {
        readonly List<UnsupportedContentItem> log = new List<UnsupportedContentItem>();        

        public Form1() {
            InitializeComponent();

            richEditControl.AddService(typeof(ILogUnsupportedContentService), new LogUnsupportedContentService(this.log));
            richEditControl.BeforeImport += OnBeforeImport;
            richEditControl.EmptyDocumentCreated += OnEmptyDocumentCreated;
            richEditControl.DocumentLoaded += OnDocumentLoaded;

            RibbonControl ribbonControl = richEditControl.CreateRibbon(RichEditToolbarType.File);
            this.Controls.Add(ribbonControl);


            this.gridControl.DataSource = this.log;
        }

        private void OnBeforeImport(object sender, DevExpress.XtraRichEdit.BeforeImportEventArgs e) {
            this.log.Clear();
        }
        private void OnEmptyDocumentCreated(object sender, EventArgs e) {
            this.log.Clear();
            this.gridControl.RefreshDataSource();
        }

        private void OnDocumentLoaded(object sender, EventArgs e) {
            this.gridControl.RefreshDataSource();
            if (this.log.Count == 0)
                MessageBox.Show("Your document does not contain any verified unsupported tags.\r\nIf the document is loaded or rendered incorrectly, submit a ticket to our Support Center and attach your document to the ticket.");
        }
    }

    public class LogUnsupportedContentService : ILogUnsupportedContentService {
        readonly List<UnsupportedContentItem> log;
        Dictionary<string, string> unsupportedItems;
        string dictionaryPath = "dictionary.csv";
        public LogUnsupportedContentService(List<UnsupportedContentItem> log) {
            this.log = log;
            this.unsupportedItems = new Dictionary<string, string>();

            InitializeDictionary();            
        }

        private void InitializeDictionary()
        {
            try
            {
                XElement pathElement = XDocument.Parse(System.IO.File.ReadAllText("Settings.config"))
                                   .Descendants("configuration")
                                   .Descendants("dictionaryPath")
                                   .FirstOrDefault();

                if (pathElement != null)
                {
                    string path = pathElement.Value;
                    using (WebClient client = new WebClient())
                        client.DownloadFile(path, dictionaryPath);                        
                }
            }
            finally
            {
                if (System.IO.File.Exists(dictionaryPath))
                {
                    string[] dictionaryItems = System.IO.File.ReadAllLines(dictionaryPath);
                    foreach (string item in dictionaryItems)
                    {
                        string[] values = item.Split(';');
                        unsupportedItems[values[0].ToLower()] = values[1].ToLower();
                    }
                }
            }
        }

        public void Log(string fileName, string tag, string @namespace, string prefix) {

            if (unsupportedItems.ContainsKey(tag.ToLower()))
            {
                UnsupportedContentItem item = new UnsupportedContentItem();
                item.FileName = fileName;
                item.Tag = tag;
                item.Namespace = @namespace;
                item.Prefix = prefix;
                item.Description = unsupportedItems[tag.ToLower()];

                log.Add(item);
            }
        }
    }

    public class UnsupportedContentItem {
        public string FileName { get; set; }
        public string Tag { get; set; }
        public string Namespace { get; set; }
        public string Prefix { get; set; }
        public string Description { get; set; }
    }
}
