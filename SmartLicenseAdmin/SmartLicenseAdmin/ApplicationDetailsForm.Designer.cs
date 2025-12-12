namespace SmartLicenseAdmin
{
    partial class ApplicationDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

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
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            groupBox3 = new GroupBox();
            panel4 = new Panel();
            btnDownloadMedical = new Button();
            btnViewMedical = new Button();
            label2 = new Label();
            panel3 = new Panel();
            btnDownloadBirth = new Button();
            btnViewBirth = new Button();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblSubmittedValue = new Label();
            lblSubmitted = new Label();
            lblStatusValue = new Label();
            lblStatus = new Label();
            lblRestrictionsValue = new Label();
            lblRestrictions = new Label();
            lblSecretariatValue = new Label();
            lblSecretariat = new Label();
            groupBox1 = new GroupBox();
            lblPhoneValue = new Label();
            lblPhone = new Label();
            lblAddressValue = new Label();
            lblAddress = new Label();
            lblOrganDonorValue = new Label();
            lblOrganDonor = new Label();
            lblBloodGroupValue = new Label();
            lblBloodGroup = new Label();
            lblHeightValue = new Label();
            lblHeight = new Label();
            lblPrintedNameValue = new Label();
            lblPrintedName = new Label();
            lblOtherNamesValue = new Label();
            lblOtherNames = new Label();
            lblSurnameValue = new Label();
            lblSurname = new Label();
            lblIdNumberValue = new Label();
            lblIdNumber = new Label();
            lblIdTypeValue = new Label();
            lblIdType = new Label();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 81, 181);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 54);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(321, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "License Application Details";
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 54);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20, 23, 20, 23);
            panel2.Size = new Size(1000, 641);
            panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel4);
            groupBox3.Controls.Add(panel3);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Location = new Point(24, 483);
            groupBox3.Margin = new Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 5, 4, 5);
            groupBox3.Size = new Size(933, 185);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "📄 Uploaded Certificates";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(240, 240, 240);
            panel4.Controls.Add(btnDownloadMedical);
            panel4.Controls.Add(btnViewMedical);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(480, 46);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(427, 108);
            panel4.TabIndex = 1;
            // 
            // btnDownloadMedical
            // 
            btnDownloadMedical.BackColor = Color.FromArgb(76, 175, 80);
            btnDownloadMedical.Cursor = Cursors.Hand;
            btnDownloadMedical.FlatAppearance.BorderSize = 0;
            btnDownloadMedical.FlatStyle = FlatStyle.Flat;
            btnDownloadMedical.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDownloadMedical.ForeColor = Color.White;
            btnDownloadMedical.Location = new Point(227, 46);
            btnDownloadMedical.Margin = new Padding(4, 5, 4, 5);
            btnDownloadMedical.Name = "btnDownloadMedical";
            btnDownloadMedical.Size = new Size(160, 43);
            btnDownloadMedical.TabIndex = 2;
            btnDownloadMedical.Text = "📥 Download";
            btnDownloadMedical.UseVisualStyleBackColor = false;
            btnDownloadMedical.Click += btnDownloadMedical_Click;
            // 
            // btnViewMedical
            // 
            btnViewMedical.BackColor = Color.FromArgb(33, 150, 243);
            btnViewMedical.Cursor = Cursors.Hand;
            btnViewMedical.FlatAppearance.BorderSize = 0;
            btnViewMedical.FlatStyle = FlatStyle.Flat;
            btnViewMedical.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewMedical.ForeColor = Color.White;
            btnViewMedical.Location = new Point(27, 46);
            btnViewMedical.Margin = new Padding(4, 5, 4, 5);
            btnViewMedical.Name = "btnViewMedical";
            btnViewMedical.Size = new Size(160, 43);
            btnViewMedical.TabIndex = 1;
            btnViewMedical.Text = "👁 View";
            btnViewMedical.UseVisualStyleBackColor = false;
            btnViewMedical.Click += btnViewMedical_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(27, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(162, 23);
            label2.TabIndex = 0;
            label2.Text = "Medical Certificate";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(240, 240, 240);
            panel3.Controls.Add(btnDownloadBirth);
            panel3.Controls.Add(btnViewBirth);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(27, 46);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(427, 108);
            panel3.TabIndex = 0;
            // 
            // btnDownloadBirth
            // 
            btnDownloadBirth.BackColor = Color.FromArgb(76, 175, 80);
            btnDownloadBirth.Cursor = Cursors.Hand;
            btnDownloadBirth.FlatAppearance.BorderSize = 0;
            btnDownloadBirth.FlatStyle = FlatStyle.Flat;
            btnDownloadBirth.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDownloadBirth.ForeColor = Color.White;
            btnDownloadBirth.Location = new Point(227, 46);
            btnDownloadBirth.Margin = new Padding(4, 5, 4, 5);
            btnDownloadBirth.Name = "btnDownloadBirth";
            btnDownloadBirth.Size = new Size(160, 43);
            btnDownloadBirth.TabIndex = 2;
            btnDownloadBirth.Text = "📥 Download";
            btnDownloadBirth.UseVisualStyleBackColor = false;
            btnDownloadBirth.Click += btnDownloadBirth_Click;
            // 
            // btnViewBirth
            // 
            btnViewBirth.BackColor = Color.FromArgb(33, 150, 243);
            btnViewBirth.Cursor = Cursors.Hand;
            btnViewBirth.FlatAppearance.BorderSize = 0;
            btnViewBirth.FlatStyle = FlatStyle.Flat;
            btnViewBirth.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnViewBirth.ForeColor = Color.White;
            btnViewBirth.Location = new Point(27, 46);
            btnViewBirth.Margin = new Padding(4, 5, 4, 5);
            btnViewBirth.Name = "btnViewBirth";
            btnViewBirth.Size = new Size(160, 43);
            btnViewBirth.TabIndex = 1;
            btnViewBirth.Text = "👁 View";
            btnViewBirth.UseVisualStyleBackColor = false;
            btnViewBirth.Click += btnViewBirth_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(27, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 23);
            label1.TabIndex = 0;
            label1.Text = "Birth Certificate";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblSubmittedValue);
            groupBox2.Controls.Add(lblSubmitted);
            groupBox2.Controls.Add(lblStatusValue);
            groupBox2.Controls.Add(lblStatus);
            groupBox2.Controls.Add(lblRestrictionsValue);
            groupBox2.Controls.Add(lblRestrictions);
            groupBox2.Controls.Add(lblSecretariatValue);
            groupBox2.Controls.Add(lblSecretariat);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(24, 282);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(933, 171);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "📋 Application Information";
            // 
            // lblSubmittedValue
            // 
            lblSubmittedValue.AutoSize = true;
            lblSubmittedValue.Font = new Font("Segoe UI", 10F);
            lblSubmittedValue.Location = new Point(773, 100);
            lblSubmittedValue.Margin = new Padding(4, 0, 4, 0);
            lblSubmittedValue.Name = "lblSubmittedValue";
            lblSubmittedValue.Size = new Size(17, 23);
            lblSubmittedValue.TabIndex = 7;
            lblSubmittedValue.Text = "-";
            // 
            // lblSubmitted
            // 
            lblSubmitted.AutoSize = true;
            lblSubmitted.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubmitted.Location = new Point(587, 100);
            lblSubmitted.Margin = new Padding(4, 0, 4, 0);
            lblSubmitted.Name = "lblSubmitted";
            lblSubmitted.Size = new Size(125, 23);
            lblSubmitted.TabIndex = 6;
            lblSubmitted.Text = "Submitted At:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusValue.Location = new Point(213, 100);
            lblStatusValue.Margin = new Padding(4, 0, 4, 0);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(17, 23);
            lblStatusValue.TabIndex = 5;
            lblStatusValue.Text = "-";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(27, 100);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 23);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            // 
            // lblRestrictionsValue
            // 
            lblRestrictionsValue.Font = new Font("Segoe UI", 10F);
            lblRestrictionsValue.Location = new Point(773, 54);
            lblRestrictionsValue.Margin = new Padding(4, 0, 4, 0);
            lblRestrictionsValue.Name = "lblRestrictionsValue";
            lblRestrictionsValue.Size = new Size(34, 29);
            lblRestrictionsValue.TabIndex = 3;
            lblRestrictionsValue.Text = "-";
            // 
            // lblRestrictions
            // 
            lblRestrictions.AutoSize = true;
            lblRestrictions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRestrictions.Location = new Point(587, 60);
            lblRestrictions.Margin = new Padding(4, 0, 4, 0);
            lblRestrictions.Name = "lblRestrictions";
            lblRestrictions.Size = new Size(163, 23);
            lblRestrictions.TabIndex = 2;
            lblRestrictions.Text = "Driver Restrictions:";
            // 
            // lblSecretariatValue
            // 
            lblSecretariatValue.AutoSize = true;
            lblSecretariatValue.Font = new Font("Segoe UI", 10F);
            lblSecretariatValue.Location = new Point(213, 60);
            lblSecretariatValue.Margin = new Padding(4, 0, 4, 0);
            lblSecretariatValue.Name = "lblSecretariatValue";
            lblSecretariatValue.Size = new Size(17, 23);
            lblSecretariatValue.TabIndex = 1;
            lblSecretariatValue.Text = "-";
            // 
            // lblSecretariat
            // 
            lblSecretariat.AutoSize = true;
            lblSecretariat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSecretariat.Location = new Point(27, 60);
            lblSecretariat.Margin = new Padding(4, 0, 4, 0);
            lblSecretariat.Name = "lblSecretariat";
            lblSecretariat.Size = new Size(102, 23);
            lblSecretariat.TabIndex = 0;
            lblSecretariat.Text = "Secretariat:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPhoneValue);
            groupBox1.Controls.Add(lblPhone);
            groupBox1.Controls.Add(lblAddressValue);
            groupBox1.Controls.Add(lblAddress);
            groupBox1.Controls.Add(lblOrganDonorValue);
            groupBox1.Controls.Add(lblOrganDonor);
            groupBox1.Controls.Add(lblBloodGroupValue);
            groupBox1.Controls.Add(lblBloodGroup);
            groupBox1.Controls.Add(lblHeightValue);
            groupBox1.Controls.Add(lblHeight);
            groupBox1.Controls.Add(lblPrintedNameValue);
            groupBox1.Controls.Add(lblPrintedName);
            groupBox1.Controls.Add(lblOtherNamesValue);
            groupBox1.Controls.Add(lblOtherNames);
            groupBox1.Controls.Add(lblSurnameValue);
            groupBox1.Controls.Add(lblSurname);
            groupBox1.Controls.Add(lblIdNumberValue);
            groupBox1.Controls.Add(lblIdNumber);
            groupBox1.Controls.Add(lblIdTypeValue);
            groupBox1.Controls.Add(lblIdType);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(24, 10);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(933, 251);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "👤 Personal Information";
            // 
            // lblPhoneValue
            // 
            lblPhoneValue.AutoSize = true;
            lblPhoneValue.Font = new Font("Segoe UI", 10F);
            lblPhoneValue.Location = new Point(773, 206);
            lblPhoneValue.Margin = new Padding(4, 0, 4, 0);
            lblPhoneValue.Name = "lblPhoneValue";
            lblPhoneValue.Size = new Size(17, 23);
            lblPhoneValue.TabIndex = 19;
            lblPhoneValue.Text = "-";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.Location = new Point(587, 200);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(136, 23);
            lblPhone.TabIndex = 18;
            lblPhone.Text = "Phone Number:";
            // 
            // lblAddressValue
            // 
            lblAddressValue.Font = new Font("Segoe UI", 10F);
            lblAddressValue.Location = new Point(213, 200);
            lblAddressValue.Margin = new Padding(4, 0, 4, 0);
            lblAddressValue.Name = "lblAddressValue";
            lblAddressValue.Size = new Size(50, 29);
            lblAddressValue.TabIndex = 17;
            lblAddressValue.Text = "-";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.Location = new Point(27, 200);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(79, 23);
            lblAddress.TabIndex = 16;
            lblAddress.Text = "Address:";
            // 
            // lblOrganDonorValue
            // 
            lblOrganDonorValue.AutoSize = true;
            lblOrganDonorValue.Font = new Font("Segoe UI", 10F);
            lblOrganDonorValue.Location = new Point(773, 162);
            lblOrganDonorValue.Margin = new Padding(4, 0, 4, 0);
            lblOrganDonorValue.Name = "lblOrganDonorValue";
            lblOrganDonorValue.Size = new Size(17, 23);
            lblOrganDonorValue.TabIndex = 15;
            lblOrganDonorValue.Text = "-";
            // 
            // lblOrganDonor
            // 
            lblOrganDonor.AutoSize = true;
            lblOrganDonor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrganDonor.Location = new Point(586, 162);
            lblOrganDonor.Margin = new Padding(4, 0, 4, 0);
            lblOrganDonor.Name = "lblOrganDonor";
            lblOrganDonor.Size = new Size(121, 23);
            lblOrganDonor.TabIndex = 14;
            lblOrganDonor.Text = "Organ Donor:";
            // 
            // lblBloodGroupValue
            // 
            lblBloodGroupValue.AutoSize = true;
            lblBloodGroupValue.Font = new Font("Segoe UI", 10F);
            lblBloodGroupValue.Location = new Point(213, 162);
            lblBloodGroupValue.Margin = new Padding(4, 0, 4, 0);
            lblBloodGroupValue.Name = "lblBloodGroupValue";
            lblBloodGroupValue.Size = new Size(17, 23);
            lblBloodGroupValue.TabIndex = 13;
            lblBloodGroupValue.Text = "-";
            // 
            // lblBloodGroup
            // 
            lblBloodGroup.AutoSize = true;
            lblBloodGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBloodGroup.Location = new Point(27, 162);
            lblBloodGroup.Margin = new Padding(4, 0, 4, 0);
            lblBloodGroup.Name = "lblBloodGroup";
            lblBloodGroup.Size = new Size(117, 23);
            lblBloodGroup.TabIndex = 12;
            lblBloodGroup.Text = "Blood Group:";
            // 
            // lblHeightValue
            // 
            lblHeightValue.AutoSize = true;
            lblHeightValue.Font = new Font("Segoe UI", 10F);
            lblHeightValue.Location = new Point(773, 123);
            lblHeightValue.Margin = new Padding(4, 0, 4, 0);
            lblHeightValue.Name = "lblHeightValue";
            lblHeightValue.Size = new Size(17, 23);
            lblHeightValue.TabIndex = 11;
            lblHeightValue.Text = "-";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeight.Location = new Point(587, 123);
            lblHeight.Margin = new Padding(4, 0, 4, 0);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(70, 23);
            lblHeight.TabIndex = 10;
            lblHeight.Text = "Height:";
            // 
            // lblPrintedNameValue
            // 
            lblPrintedNameValue.AutoSize = true;
            lblPrintedNameValue.Font = new Font("Segoe UI", 10F);
            lblPrintedNameValue.Location = new Point(213, 123);
            lblPrintedNameValue.Margin = new Padding(4, 0, 4, 0);
            lblPrintedNameValue.Name = "lblPrintedNameValue";
            lblPrintedNameValue.Size = new Size(17, 23);
            lblPrintedNameValue.TabIndex = 9;
            lblPrintedNameValue.Text = "-";
            // 
            // lblPrintedName
            // 
            lblPrintedName.AutoSize = true;
            lblPrintedName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrintedName.Location = new Point(27, 123);
            lblPrintedName.Margin = new Padding(4, 0, 4, 0);
            lblPrintedName.Name = "lblPrintedName";
            lblPrintedName.Size = new Size(126, 23);
            lblPrintedName.TabIndex = 8;
            lblPrintedName.Text = "Printed Name:";
            // 
            // lblOtherNamesValue
            // 
            lblOtherNamesValue.AutoSize = true;
            lblOtherNamesValue.Font = new Font("Segoe UI", 10F);
            lblOtherNamesValue.Location = new Point(773, 82);
            lblOtherNamesValue.Margin = new Padding(4, 0, 4, 0);
            lblOtherNamesValue.Name = "lblOtherNamesValue";
            lblOtherNamesValue.Size = new Size(17, 23);
            lblOtherNamesValue.TabIndex = 7;
            lblOtherNamesValue.Text = "-";
            // 
            // lblOtherNames
            // 
            lblOtherNames.AutoSize = true;
            lblOtherNames.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOtherNames.Location = new Point(587, 82);
            lblOtherNames.Margin = new Padding(4, 0, 4, 0);
            lblOtherNames.Name = "lblOtherNames";
            lblOtherNames.Size = new Size(120, 23);
            lblOtherNames.TabIndex = 6;
            lblOtherNames.Text = "Other Names:";
            // 
            // lblSurnameValue
            // 
            lblSurnameValue.AutoSize = true;
            lblSurnameValue.Font = new Font("Segoe UI", 10F);
            lblSurnameValue.Location = new Point(213, 82);
            lblSurnameValue.Margin = new Padding(4, 0, 4, 0);
            lblSurnameValue.Name = "lblSurnameValue";
            lblSurnameValue.Size = new Size(17, 23);
            lblSurnameValue.TabIndex = 5;
            lblSurnameValue.Text = "-";
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSurname.Location = new Point(27, 82);
            lblSurname.Margin = new Padding(4, 0, 4, 0);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(86, 23);
            lblSurname.TabIndex = 4;
            lblSurname.Text = "Surname:";
            // 
            // lblIdNumberValue
            // 
            lblIdNumberValue.AutoSize = true;
            lblIdNumberValue.Font = new Font("Segoe UI", 10F);
            lblIdNumberValue.Location = new Point(773, 39);
            lblIdNumberValue.Margin = new Padding(4, 0, 4, 0);
            lblIdNumberValue.Name = "lblIdNumberValue";
            lblIdNumberValue.Size = new Size(17, 23);
            lblIdNumberValue.TabIndex = 3;
            lblIdNumberValue.Text = "-";
            // 
            // lblIdNumber
            // 
            lblIdNumber.AutoSize = true;
            lblIdNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIdNumber.Location = new Point(587, 39);
            lblIdNumber.Margin = new Padding(4, 0, 4, 0);
            lblIdNumber.Name = "lblIdNumber";
            lblIdNumber.Size = new Size(105, 23);
            lblIdNumber.TabIndex = 2;
            lblIdNumber.Text = "ID Number:";
            // 
            // lblIdTypeValue
            // 
            lblIdTypeValue.AutoSize = true;
            lblIdTypeValue.Font = new Font("Segoe UI", 10F);
            lblIdTypeValue.Location = new Point(213, 39);
            lblIdTypeValue.Margin = new Padding(4, 0, 4, 0);
            lblIdTypeValue.Name = "lblIdTypeValue";
            lblIdTypeValue.Size = new Size(17, 23);
            lblIdTypeValue.TabIndex = 1;
            lblIdTypeValue.Text = "-";
            // 
            // lblIdType
            // 
            lblIdType.AutoSize = true;
            lblIdType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIdType.Location = new Point(27, 39);
            lblIdType.Margin = new Padding(4, 0, 4, 0);
            lblIdType.Name = "lblIdType";
            lblIdType.Size = new Size(76, 23);
            lblIdType.TabIndex = 0;
            lblIdType.Text = "ID Type:";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(244, 67, 54);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Bottom;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(0, 695);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(1000, 37);
            btnClose.TabIndex = 2;
            btnClose.Text = "✖ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ApplicationDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 732);
            Controls.Add(panel2);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApplicationDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "License Application Details";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIdType;
        private System.Windows.Forms.Label lblIdTypeValue;
        private System.Windows.Forms.Label lblIdNumberValue;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.Label lblSurnameValue;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblOtherNamesValue;
        private System.Windows.Forms.Label lblOtherNames;
        private System.Windows.Forms.Label lblPrintedNameValue;
        private System.Windows.Forms.Label lblPrintedName;
        private System.Windows.Forms.Label lblHeightValue;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblBloodGroupValue;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.Label lblOrganDonorValue;
        private System.Windows.Forms.Label lblOrganDonor;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhoneValue;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSecretariatValue;
        private System.Windows.Forms.Label lblSecretariat;
        private System.Windows.Forms.Label lblRestrictionsValue;
        private System.Windows.Forms.Label lblRestrictions;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSubmittedValue;
        private System.Windows.Forms.Label lblSubmitted;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewBirth;
        private System.Windows.Forms.Button btnDownloadBirth;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDownloadMedical;
        private System.Windows.Forms.Button btnViewMedical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}
