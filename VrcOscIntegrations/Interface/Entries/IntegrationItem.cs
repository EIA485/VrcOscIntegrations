﻿namespace VrcOscIntegrations.Interface.Entries
{
    public partial class IntegrationItem : PoisonUserControl
    {
        public IntegrationItem()
        {
            InitializeComponent();
        }


        public string Id { get; set; }

        string _name;
        public string IntegrationName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                integrationName.Text = _name;
            }
        }

        string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                integrationAuthor.Text = _author;
            }
        }

        private void interactionButton_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainPanel panel)
            {
                panel.integrationHeader.IntegrationId = Id;
                panel.integrationHeader.IntegrationName = this.IntegrationName;
                panel.integrationHeader.Visible = true;
            }

            foreach (Control control in this.Parent.Controls)
                control.Visible = false;

            this.Parent.Controls.Add(IntegrationsManager.Integrations[Id].MainPanel);
        }
    }
}
