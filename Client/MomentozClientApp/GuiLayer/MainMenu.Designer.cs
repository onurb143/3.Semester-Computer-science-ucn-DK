namespace MomentozClientApp
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

      
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            LinkLabel = new LinkLabel();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            BaggageLabel = new Label();
            AfgangLabel = new Label();
            PrisLabel = new Label();
            Destinationer = new Label();
            label6 = new Label();
            ReturLabel = new Label();
            DestinationLabel = new Label();
            DestinationDropDown = new ComboBox();
            ReturValgDropDown = new ComboBox();
            BaggageDropDown = new ComboBox();
            AfgangsDestination = new Label();
            Destination = new Label();
            OrdreInfo = new Label();
            SamletPris = new Label();
            BestilKnap = new Button();
            ForNavnLabel = new Label();
            labelCustomerName = new Label();
            efterNavnLabel = new Label();
            MobileLabel = new Label();
            MailLabel = new Label();
            lastName = new Label();
            mobilePhone = new Label();
            email = new Label();
            KundeInfo = new Label();
            label1 = new Label();
            customerID = new Label();
            SuspendLayout();
            // 
            // LinkLabel
            // 
            LinkLabel.AutoSize = true;
            LinkLabel.Location = new Point(12, 327);
            LinkLabel.Name = "LinkLabel";
            LinkLabel.Size = new Size(88, 15);
            LinkLabel.TabIndex = 9;
            LinkLabel.TabStop = true;
            LinkLabel.Text = "Om Momentoz";
            LinkLabel.LinkClicked += OmMomentoz;
            // 
            // BaggageLabel
            // 
            BaggageLabel.AutoSize = true;
            BaggageLabel.Location = new Point(597, 164);
            BaggageLabel.Name = "BaggageLabel";
            BaggageLabel.Size = new Size(56, 15);
            BaggageLabel.TabIndex = 10;
            BaggageLabel.Text = "Baggage:";
            // 
            // AfgangLabel
            // 
            AfgangLabel.AutoSize = true;
            AfgangLabel.Location = new Point(597, 99);
            AfgangLabel.Name = "AfgangLabel";
            AfgangLabel.Size = new Size(49, 15);
            AfgangLabel.TabIndex = 11;
            AfgangLabel.Text = "Afgang:";
            // 
            // PrisLabel
            // 
            PrisLabel.AutoSize = true;
            PrisLabel.Location = new Point(597, 205);
            PrisLabel.Name = "PrisLabel";
            PrisLabel.Size = new Size(29, 15);
            PrisLabel.TabIndex = 13;
            PrisLabel.Text = "Pris:";
            // 
            // Destinationer
            // 
            Destinationer.AutoSize = true;
            Destinationer.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Destinationer.Location = new Point(12, 17);
            Destinationer.Name = "Destinationer";
            Destinationer.Size = new Size(182, 37);
            Destinationer.TabIndex = 15;
            Destinationer.Text = "Destinationer:";
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 51;
            // 
            // ReturLabel
            // 
            ReturLabel.AutoSize = true;
            ReturLabel.Location = new Point(597, 131);
            ReturLabel.Name = "ReturLabel";
            ReturLabel.Size = new Size(67, 15);
            ReturLabel.TabIndex = 24;
            ReturLabel.Text = "Retur billet:";
            // 
            // DestinationLabel
            // 
            DestinationLabel.AutoSize = true;
            DestinationLabel.Location = new Point(314, 247);
            DestinationLabel.Name = "DestinationLabel";
            DestinationLabel.Size = new Size(98, 15);
            DestinationLabel.TabIndex = 27;
            DestinationLabel.Text = "Valgt destination:";
            // 
            // DestinationDropDown
            // 
            DestinationDropDown.Location = new Point(12, 69);
            DestinationDropDown.Name = "DestinationDropDown";
            DestinationDropDown.Size = new Size(182, 23);
            DestinationDropDown.TabIndex = 30;
            DestinationDropDown.SelectedIndexChanged += flightsDropDown;
            // 
            // ReturValgDropDown
            // 
            ReturValgDropDown.FormattingEnabled = true;
            ReturValgDropDown.Location = new Point(685, 128);
            ReturValgDropDown.Name = "ReturValgDropDown";
            ReturValgDropDown.Size = new Size(100, 23);
            ReturValgDropDown.TabIndex = 25;
            ReturValgDropDown.SelectedIndexChanged += ReturBillet;
            // 
            // BaggageDropDown
            // 
            BaggageDropDown.FormattingEnabled = true;
            BaggageDropDown.Location = new Point(685, 164);
            BaggageDropDown.Name = "BaggageDropDown";
            BaggageDropDown.Size = new Size(100, 23);
            BaggageDropDown.TabIndex = 20;
            BaggageDropDown.SelectedIndexChanged += BaggageValg;
            // 
            // AfgangsDestination
            // 
            AfgangsDestination.AutoSize = true;
            AfgangsDestination.Location = new Point(704, 99);
            AfgangsDestination.Name = "AfgangsDestination";
            AfgangsDestination.Size = new Size(49, 15);
            AfgangsDestination.TabIndex = 31;
            AfgangsDestination.Text = "Aalborg";
            AfgangsDestination.Click += AfgangsDestinationLabel;
            // 
            // Destination
            // 
            Destination.AutoSize = true;
            Destination.Location = new Point(418, 247);
            Destination.Name = "Destination";
            Destination.Size = new Size(67, 15);
            Destination.TabIndex = 33;
            Destination.Text = "Destination";
            Destination.Click += DestinationsDropDown;
            // 
            // OrdreInfo
            // 
            OrdreInfo.AutoSize = true;
            OrdreInfo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            OrdreInfo.Location = new Point(642, 24);
            OrdreInfo.Name = "OrdreInfo";
            OrdreInfo.Size = new Size(76, 30);
            OrdreInfo.TabIndex = 34;
            OrdreInfo.Text = "Ordre:";
            // 
            // SamletPris
            // 
            SamletPris.AutoSize = true;
            SamletPris.Location = new Point(704, 205);
            SamletPris.Name = "SamletPris";
            SamletPris.Size = new Size(65, 15);
            SamletPris.TabIndex = 35;
            SamletPris.Text = "Samlet pris";
            // 
            // BestilKnap
            // 
            BestilKnap.Location = new Point(685, 300);
            BestilKnap.Name = "BestilKnap";
            BestilKnap.Size = new Size(99, 42);
            BestilKnap.TabIndex = 36;
            BestilKnap.Text = "Bestil";
            BestilKnap.UseVisualStyleBackColor = true;
            BestilKnap.Click += GodkendOrdreKnap;
            // 
            // ForNavnLabel
            // 
            ForNavnLabel.AutoSize = true;
            ForNavnLabel.Location = new Point(314, 99);
            ForNavnLabel.Name = "ForNavnLabel";
            ForNavnLabel.Size = new Size(53, 15);
            ForNavnLabel.TabIndex = 37;
            ForNavnLabel.Text = "Fornavn:";
            ForNavnLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.Location = new Point(391, 99);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(50, 15);
            labelCustomerName.TabIndex = 38;
            labelCustomerName.Text = "Fornavn";
            labelCustomerName.Click += forNavn;
            // 
            // efterNavnLabel
            // 
            efterNavnLabel.AutoSize = true;
            efterNavnLabel.Location = new Point(316, 135);
            efterNavnLabel.Name = "efterNavnLabel";
            efterNavnLabel.Size = new Size(60, 15);
            efterNavnLabel.TabIndex = 39;
            efterNavnLabel.Text = "Efternavn:";
            efterNavnLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MobileLabel
            // 
            MobileLabel.AutoSize = true;
            MobileLabel.Location = new Point(316, 168);
            MobileLabel.Name = "MobileLabel";
            MobileLabel.Size = new Size(41, 15);
            MobileLabel.TabIndex = 40;
            MobileLabel.Text = "Mobil:";
            MobileLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MailLabel
            // 
            MailLabel.AutoSize = true;
            MailLabel.Location = new Point(316, 203);
            MailLabel.Name = "MailLabel";
            MailLabel.Size = new Size(39, 15);
            MailLabel.TabIndex = 41;
            MailLabel.Text = "Email:";
            MailLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lastName
            // 
            lastName.AutoSize = true;
            lastName.Location = new Point(391, 135);
            lastName.Name = "lastName";
            lastName.Size = new Size(57, 15);
            lastName.TabIndex = 43;
            lastName.Text = "Efternavn";
            lastName.Click += lastNameLabel_Click;
            // 
            // mobilePhone
            // 
            mobilePhone.AutoSize = true;
            mobilePhone.Location = new Point(391, 168);
            mobilePhone.Name = "mobilePhone";
            mobilePhone.Size = new Size(50, 15);
            mobilePhone.TabIndex = 44;
            mobilePhone.Text = "Mobiloz";
            mobilePhone.Click += mobilePhoneLabel_Click;
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(391, 203);
            email.Name = "email";
            email.Size = new Size(36, 15);
            email.TabIndex = 45;
            email.Text = "Email";
            email.Click += EmailLabel_Click;
            // 
            // KundeInfo
            // 
            KundeInfo.AutoSize = true;
            KundeInfo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KundeInfo.Location = new Point(336, 24);
            KundeInfo.Name = "KundeInfo";
            KundeInfo.Size = new Size(80, 30);
            KundeInfo.TabIndex = 50;
            KundeInfo.Text = "Kunde:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(314, 74);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 52;
            label1.Text = "ID:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // customerID
            // 
            customerID.AutoSize = true;
            customerID.Location = new Point(391, 74);
            customerID.Name = "customerID";
            customerID.Size = new Size(18, 15);
            customerID.TabIndex = 53;
            customerID.Text = "ID";
            customerID.TextAlign = ContentAlignment.TopCenter;
            customerID.Click += customerID_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 376);
            Controls.Add(customerID);
            Controls.Add(label1);
            Controls.Add(KundeInfo);
            Controls.Add(email);
            Controls.Add(mobilePhone);
            Controls.Add(lastName);
            Controls.Add(MailLabel);
            Controls.Add(MobileLabel);
            Controls.Add(efterNavnLabel);
            Controls.Add(labelCustomerName);
            Controls.Add(ForNavnLabel);
            Controls.Add(BestilKnap);
            Controls.Add(SamletPris);
            Controls.Add(OrdreInfo);
            Controls.Add(Destination);
            Controls.Add(AfgangsDestination);
            Controls.Add(DestinationDropDown);
            Controls.Add(DestinationLabel);
            Controls.Add(ReturValgDropDown);
            Controls.Add(ReturLabel);
            Controls.Add(label6);
            Controls.Add(BaggageDropDown);
            Controls.Add(Destinationer);
            Controls.Add(PrisLabel);
            Controls.Add(AfgangLabel);
            Controls.Add(BaggageLabel);
            Controls.Add(LinkLabel);
            Name = "MainMenu";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private LinkLabel LinkLabel;
        private Label BaggageLabel;
        private Label AfgangLabel;
        private Label PrisLabel;
        private Label Destinationer;
        private Label label6;
        private Label KundeInfo;
        private Label ReturLabel;
        private Label DestinationLabel;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox DestinationDropDown;
        private ComboBox ReturValgDropDown;
        private ComboBox BaggageDropDown;
        private Label AfgangsDestination;
        private Label Destination;
        private Label OrdreInfo;
        private Label SamletPris;
        private Label label14;
        private Button BestilKnap;
        private Label ForNavnLabel;
        private Label labelCustomerName;
        private Label lastName;
        private Label efterNavnLabel;
        private Label MobileLabel;
        private Label MailLabel;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label23;
        private ComboBox comboBox4;
        private Label label18;
        private Label mobilePhone;
        private Label email;
        private Label label1;
        private Label customerID;
    }
}