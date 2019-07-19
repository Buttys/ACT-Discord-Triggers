using System;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Xml;
using System.Speech.Synthesis;
using System.Reflection;
using DiscordAPI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ACT_DiscordTriggers
{
	public class DiscordPlugin : UserControl, IActPluginV1 {
		#region Designer Created Code (Avoid editing)
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkPartyJoin = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkfilterdmg = new System.Windows.Forms.CheckBox();
            this.chkParseFilter = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFFLogsToken = new System.Windows.Forms.TextBox();
            this.txtParseChannel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFFXIVName = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblTTS = new System.Windows.Forms.Label();
            this.cmbTTS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTTSVol = new System.Windows.Forms.Label();
            this.sliderEffectVol = new System.Windows.Forms.TrackBar();
            this.sliderTTSVol = new System.Windows.Forms.TrackBar();
            this.lblTTSSpeed = new System.Windows.Forms.Label();
            this.sliderTTSSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDiscordCommands = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.chkShowtext = new System.Windows.Forms.CheckBox();
            this.lblBotTok = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnDiscordConnect = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblChan = new System.Windows.Forms.Label();
            this.cmbChan = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAltarTrigger = new System.Windows.Forms.TextBox();
            this.lstAltarTriggers = new System.Windows.Forms.ListBox();
            this.TestMapBtn = new System.Windows.Forms.Button();
            this.btnAddTriggers = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFriend = new System.Windows.Forms.TextBox();
            this.lstFriends = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDirThree = new System.Windows.Forms.TextBox();
            this.lstThreeDirections = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDirTwo = new System.Windows.Forms.TextBox();
            this.lstTwoDirections = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTrigger = new System.Windows.Forms.TextBox();
            this.lstMapTriggers = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderEffectVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTTSVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTTSSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 502);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Discord Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkPartyJoin);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.chkfilterdmg);
            this.groupBox9.Controls.Add(this.chkParseFilter);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.txtFFLogsToken);
            this.groupBox9.Controls.Add(this.txtParseChannel);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.txtFFXIVName);
            this.groupBox9.Location = new System.Drawing.Point(6, 238);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(486, 146);
            this.groupBox9.TabIndex = 56;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "FFlogs Settings";
            // 
            // chkPartyJoin
            // 
            this.chkPartyJoin.AutoSize = true;
            this.chkPartyJoin.Location = new System.Drawing.Point(216, 91);
            this.chkPartyJoin.Name = "chkPartyJoin";
            this.chkPartyJoin.Size = new System.Drawing.Size(98, 17);
            this.chkPartyJoin.TabIndex = 49;
            this.chkPartyJoin.Text = "Party Join Logs";
            this.chkPartyJoin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Your FFXIV Name";
            // 
            // chkfilterdmg
            // 
            this.chkfilterdmg.AutoSize = true;
            this.chkfilterdmg.Checked = true;
            this.chkfilterdmg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkfilterdmg.Location = new System.Drawing.Point(305, 68);
            this.chkfilterdmg.Name = "chkfilterdmg";
            this.chkfilterdmg.Size = new System.Drawing.Size(125, 17);
            this.chkfilterdmg.TabIndex = 48;
            this.chkfilterdmg.Text = "Filter Infinite Damage";
            this.chkfilterdmg.UseVisualStyleBackColor = true;
            // 
            // chkParseFilter
            // 
            this.chkParseFilter.AutoSize = true;
            this.chkParseFilter.Checked = true;
            this.chkParseFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParseFilter.Location = new System.Drawing.Point(216, 68);
            this.chkParseFilter.Name = "chkParseFilter";
            this.chkParseFilter.Size = new System.Drawing.Size(83, 17);
            this.chkParseFilter.TabIndex = 46;
            this.chkParseFilter.Text = "Filter Parses";
            this.chkParseFilter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "FFLogs Token";
            // 
            // txtFFLogsToken
            // 
            this.txtFFLogsToken.Location = new System.Drawing.Point(9, 86);
            this.txtFFLogsToken.Name = "txtFFLogsToken";
            this.txtFFLogsToken.Size = new System.Drawing.Size(193, 20);
            this.txtFFLogsToken.TabIndex = 39;
            this.txtFFLogsToken.UseSystemPasswordChar = true;
            // 
            // txtParseChannel
            // 
            this.txtParseChannel.Location = new System.Drawing.Point(216, 41);
            this.txtParseChannel.Name = "txtParseChannel";
            this.txtParseChannel.Size = new System.Drawing.Size(193, 20);
            this.txtParseChannel.TabIndex = 42;
            this.txtParseChannel.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Parse Chat ID";
            // 
            // txtFFXIVName
            // 
            this.txtFFXIVName.Location = new System.Drawing.Point(9, 44);
            this.txtFFXIVName.Name = "txtFFXIVName";
            this.txtFFXIVName.Size = new System.Drawing.Size(193, 20);
            this.txtFFXIVName.TabIndex = 44;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblTTS);
            this.groupBox8.Controls.Add(this.cmbTTS);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.lblTTSVol);
            this.groupBox8.Controls.Add(this.sliderEffectVol);
            this.groupBox8.Controls.Add(this.sliderTTSVol);
            this.groupBox8.Controls.Add(this.lblTTSSpeed);
            this.groupBox8.Controls.Add(this.sliderTTSSpeed);
            this.groupBox8.Location = new System.Drawing.Point(498, 9);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(211, 267);
            this.groupBox8.TabIndex = 55;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Sound Options";
            // 
            // lblTTS
            // 
            this.lblTTS.AutoSize = true;
            this.lblTTS.Location = new System.Drawing.Point(6, 16);
            this.lblTTS.Name = "lblTTS";
            this.lblTTS.Size = new System.Drawing.Size(58, 13);
            this.lblTTS.TabIndex = 28;
            this.lblTTS.Text = "TTS Voice";
            // 
            // cmbTTS
            // 
            this.cmbTTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTTS.FormattingEnabled = true;
            this.cmbTTS.Location = new System.Drawing.Point(9, 38);
            this.cmbTTS.Name = "cmbTTS";
            this.cmbTTS.Size = new System.Drawing.Size(193, 21);
            this.cmbTTS.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Effect Volume";
            // 
            // lblTTSVol
            // 
            this.lblTTSVol.AutoSize = true;
            this.lblTTSVol.Location = new System.Drawing.Point(6, 64);
            this.lblTTSVol.Name = "lblTTSVol";
            this.lblTTSVol.Size = new System.Drawing.Size(66, 13);
            this.lblTTSVol.TabIndex = 34;
            this.lblTTSVol.Text = "TTS Volume";
            // 
            // sliderEffectVol
            // 
            this.sliderEffectVol.Location = new System.Drawing.Point(9, 208);
            this.sliderEffectVol.Maximum = 100;
            this.sliderEffectVol.Name = "sliderEffectVol";
            this.sliderEffectVol.Size = new System.Drawing.Size(193, 45);
            this.sliderEffectVol.TabIndex = 52;
            this.sliderEffectVol.Value = 20;
            // 
            // sliderTTSVol
            // 
            this.sliderTTSVol.Location = new System.Drawing.Point(9, 80);
            this.sliderTTSVol.Maximum = 20;
            this.sliderTTSVol.Name = "sliderTTSVol";
            this.sliderTTSVol.Size = new System.Drawing.Size(193, 45);
            this.sliderTTSVol.TabIndex = 35;
            this.sliderTTSVol.Value = 10;
            // 
            // lblTTSSpeed
            // 
            this.lblTTSSpeed.AutoSize = true;
            this.lblTTSSpeed.Location = new System.Drawing.Point(10, 128);
            this.lblTTSSpeed.Name = "lblTTSSpeed";
            this.lblTTSSpeed.Size = new System.Drawing.Size(62, 13);
            this.lblTTSSpeed.TabIndex = 36;
            this.lblTTSSpeed.Text = "TTS Speed";
            // 
            // sliderTTSSpeed
            // 
            this.sliderTTSSpeed.Location = new System.Drawing.Point(9, 144);
            this.sliderTTSSpeed.Maximum = 20;
            this.sliderTTSSpeed.Name = "sliderTTSSpeed";
            this.sliderTTSSpeed.Size = new System.Drawing.Size(193, 45);
            this.sliderTTSSpeed.TabIndex = 37;
            this.sliderTTSSpeed.Value = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkDiscordCommands);
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Controls.Add(this.chkAutoConnect);
            this.groupBox2.Controls.Add(this.chkShowtext);
            this.groupBox2.Controls.Add(this.lblBotTok);
            this.groupBox2.Controls.Add(this.txtToken);
            this.groupBox2.Controls.Add(this.btnSetStatus);
            this.groupBox2.Controls.Add(this.cmbServer);
            this.groupBox2.Controls.Add(this.btnJoin);
            this.groupBox2.Controls.Add(this.btnDiscordConnect);
            this.groupBox2.Controls.Add(this.btnLeave);
            this.groupBox2.Controls.Add(this.lblServer);
            this.groupBox2.Controls.Add(this.lblChan);
            this.groupBox2.Controls.Add(this.cmbChan);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 224);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discord Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Bot Status";
            // 
            // chkDiscordCommands
            // 
            this.chkDiscordCommands.AutoSize = true;
            this.chkDiscordCommands.Checked = true;
            this.chkDiscordCommands.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiscordCommands.Location = new System.Drawing.Point(9, 178);
            this.chkDiscordCommands.Name = "chkDiscordCommands";
            this.chkDiscordCommands.Size = new System.Drawing.Size(153, 17);
            this.chkDiscordCommands.TabIndex = 47;
            this.chkDiscordCommands.Text = "Enable Discord Commands";
            this.chkDiscordCommands.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.txtStatus, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lstStatus, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(213, 33);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(267, 151);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtStatus.Location = new System.Drawing.Point(3, 131);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(261, 20);
            this.txtStatus.TabIndex = 0;
            // 
            // lstStatus
            // 
            this.lstStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.Location = new System.Drawing.Point(3, 3);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(261, 122);
            this.lstStatus.TabIndex = 1;
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.Location = new System.Drawing.Point(107, 201);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(91, 17);
            this.chkAutoConnect.TabIndex = 41;
            this.chkAutoConnect.Text = "Auto Connect";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            // 
            // chkShowtext
            // 
            this.chkShowtext.AutoSize = true;
            this.chkShowtext.Location = new System.Drawing.Point(9, 201);
            this.chkShowtext.Name = "chkShowtext";
            this.chkShowtext.Size = new System.Drawing.Size(92, 17);
            this.chkShowtext.TabIndex = 51;
            this.chkShowtext.Text = "Show Tokens";
            this.chkShowtext.UseVisualStyleBackColor = true;
            // 
            // lblBotTok
            // 
            this.lblBotTok.AutoSize = true;
            this.lblBotTok.Location = new System.Drawing.Point(6, 131);
            this.lblBotTok.Name = "lblBotTok";
            this.lblBotTok.Size = new System.Drawing.Size(96, 13);
            this.lblBotTok.TabIndex = 22;
            this.lblBotTok.Text = "Discord Bot Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(9, 151);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(193, 20);
            this.txtToken.TabIndex = 23;
            this.txtToken.UseSystemPasswordChar = true;
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Enabled = false;
            this.btnSetStatus.Location = new System.Drawing.Point(287, 195);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(94, 23);
            this.btnSetStatus.TabIndex = 50;
            this.btnSetStatus.Text = "Update";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.BtnSetStatus_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(9, 33);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(193, 21);
            this.cmbServer.TabIndex = 31;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // btnJoin
            // 
            this.btnJoin.Enabled = false;
            this.btnJoin.Location = new System.Drawing.Point(9, 105);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(93, 23);
            this.btnJoin.TabIndex = 26;
            this.btnJoin.Text = "Join Channel";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.BtnJoin_Click);
            // 
            // btnDiscordConnect
            // 
            this.btnDiscordConnect.Location = new System.Drawing.Point(387, 195);
            this.btnDiscordConnect.Name = "btnDiscordConnect";
            this.btnDiscordConnect.Size = new System.Drawing.Size(93, 23);
            this.btnDiscordConnect.TabIndex = 40;
            this.btnDiscordConnect.Text = "Connect";
            this.btnDiscordConnect.UseVisualStyleBackColor = true;
            this.btnDiscordConnect.Click += new System.EventHandler(this.DiscordConnectbtn_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Enabled = false;
            this.btnLeave.Location = new System.Drawing.Point(108, 106);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(94, 23);
            this.btnLeave.TabIndex = 27;
            this.btnLeave.Text = "Leave Channel";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.BtnLeave_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(6, 19);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 30;
            this.lblServer.Text = "Server";
            // 
            // lblChan
            // 
            this.lblChan.AutoSize = true;
            this.lblChan.Location = new System.Drawing.Point(6, 61);
            this.lblChan.Name = "lblChan";
            this.lblChan.Size = new System.Drawing.Size(46, 13);
            this.lblChan.TabIndex = 32;
            this.lblChan.Text = "Channel";
            // 
            // cmbChan
            // 
            this.cmbChan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChan.FormattingEnabled = true;
            this.cmbChan.Location = new System.Drawing.Point(9, 79);
            this.cmbChan.Name = "cmbChan";
            this.cmbChan.Size = new System.Drawing.Size(193, 21);
            this.cmbChan.TabIndex = 33;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.TestMapBtn);
            this.tabPage2.Controls.Add(this.btnAddTriggers);
            this.tabPage2.Controls.Add(this.btnSaveSettings);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 476);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map Triggers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Location = new System.Drawing.Point(747, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 397);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shifting Altar Triggers";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtAltarTrigger, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lstAltarTriggers, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(171, 378);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // txtAltarTrigger
            // 
            this.txtAltarTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAltarTrigger.Location = new System.Drawing.Point(3, 356);
            this.txtAltarTrigger.Name = "txtAltarTrigger";
            this.txtAltarTrigger.Size = new System.Drawing.Size(165, 20);
            this.txtAltarTrigger.TabIndex = 0;
            // 
            // lstAltarTriggers
            // 
            this.lstAltarTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAltarTriggers.FormattingEnabled = true;
            this.lstAltarTriggers.Location = new System.Drawing.Point(3, 3);
            this.lstAltarTriggers.Name = "lstAltarTriggers";
            this.lstAltarTriggers.Size = new System.Drawing.Size(165, 347);
            this.lstAltarTriggers.TabIndex = 1;
            // 
            // TestMapBtn
            // 
            this.TestMapBtn.Location = new System.Drawing.Point(630, 406);
            this.TestMapBtn.Name = "TestMapBtn";
            this.TestMapBtn.Size = new System.Drawing.Size(127, 23);
            this.TestMapBtn.TabIndex = 5;
            this.TestMapBtn.Text = "Test";
            this.TestMapBtn.UseVisualStyleBackColor = true;
            this.TestMapBtn.Click += new System.EventHandler(this.TestMapBtn_Click);
            // 
            // btnAddTriggers
            // 
            this.btnAddTriggers.Location = new System.Drawing.Point(763, 407);
            this.btnAddTriggers.Name = "btnAddTriggers";
            this.btnAddTriggers.Size = new System.Drawing.Size(155, 23);
            this.btnAddTriggers.TabIndex = 4;
            this.btnAddTriggers.Text = "Add Required Triggers";
            this.btnAddTriggers.UseVisualStyleBackColor = true;
            this.btnAddTriggers.Click += new System.EventHandler(this.BtnAddTriggers_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(763, 436);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(155, 23);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel4);
            this.groupBox6.Location = new System.Drawing.Point(6, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 397);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Friend List {1}";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.txtFriend, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lstFriends, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(161, 378);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // txtFriend
            // 
            this.txtFriend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFriend.Location = new System.Drawing.Point(3, 356);
            this.txtFriend.Name = "txtFriend";
            this.txtFriend.Size = new System.Drawing.Size(155, 20);
            this.txtFriend.TabIndex = 0;
            // 
            // lstFriends
            // 
            this.lstFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFriends.FormattingEnabled = true;
            this.lstFriends.Location = new System.Drawing.Point(3, 3);
            this.lstFriends.Name = "lstFriends";
            this.lstFriends.Size = new System.Drawing.Size(155, 347);
            this.lstFriends.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel2);
            this.groupBox5.Location = new System.Drawing.Point(586, 209);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 196);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Directions (Three Doors) {0}";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtDirThree, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lstThreeDirections, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(152, 177);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtDirThree
            // 
            this.txtDirThree.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDirThree.Location = new System.Drawing.Point(3, 155);
            this.txtDirThree.Name = "txtDirThree";
            this.txtDirThree.Size = new System.Drawing.Size(146, 20);
            this.txtDirThree.TabIndex = 0;
            // 
            // lstThreeDirections
            // 
            this.lstThreeDirections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstThreeDirections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstThreeDirections.FormattingEnabled = true;
            this.lstThreeDirections.Items.AddRange(new object[] {
            "to the Left",
            "in the Middle",
            "to the Right"});
            this.lstThreeDirections.Location = new System.Drawing.Point(3, 3);
            this.lstThreeDirections.Name = "lstThreeDirections";
            this.lstThreeDirections.Size = new System.Drawing.Size(146, 146);
            this.lstThreeDirections.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Location = new System.Drawing.Point(583, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 196);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Directions (Two Doors) {0}";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtDirTwo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstTwoDirections, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 177);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDirTwo
            // 
            this.txtDirTwo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDirTwo.Location = new System.Drawing.Point(3, 157);
            this.txtDirTwo.Name = "txtDirTwo";
            this.txtDirTwo.Size = new System.Drawing.Size(149, 20);
            this.txtDirTwo.TabIndex = 0;
            // 
            // lstTwoDirections
            // 
            this.lstTwoDirections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTwoDirections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTwoDirections.FormattingEnabled = true;
            this.lstTwoDirections.Items.AddRange(new object[] {
            "to the Left",
            "to the Right"});
            this.lstTwoDirections.Location = new System.Drawing.Point(3, 3);
            this.lstTwoDirections.Name = "lstTwoDirections";
            this.lstTwoDirections.Size = new System.Drawing.Size(149, 148);
            this.lstTwoDirections.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(179, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 397);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Door Triggers";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtTrigger, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lstMapTriggers, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(395, 378);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtTrigger
            // 
            this.txtTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrigger.Location = new System.Drawing.Point(3, 356);
            this.txtTrigger.Name = "txtTrigger";
            this.txtTrigger.Size = new System.Drawing.Size(389, 20);
            this.txtTrigger.TabIndex = 0;
            // 
            // lstMapTriggers
            // 
            this.lstMapTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMapTriggers.FormattingEnabled = true;
            this.lstMapTriggers.Location = new System.Drawing.Point(3, 3);
            this.lstMapTriggers.Name = "lstMapTriggers";
            this.lstMapTriggers.Size = new System.Drawing.Size(389, 347);
            this.lstMapTriggers.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(937, 476);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.Control;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(3, 3);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(931, 470);
            this.logBox.TabIndex = 25;
            // 
            // DiscordPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DiscordPlugin";
            this.Size = new System.Drawing.Size(945, 502);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderEffectVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTTSVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTTSSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		#endregion
		public DiscordPlugin() {
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			InitializeComponent();
			var tts = new SpeechSynthesizer();
			foreach (InstalledVoice v in tts.GetInstalledVoices())
				cmbTTS.Items.Add(v.VoiceInfo.Name);
			cmbTTS.SelectedIndex = 0;
            
		}

		Label lblStatus;
		string settingsFile;
		SettingsSerializer xmlSettings;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TrackBar sliderTTSSpeed;
        private Label lblTTSSpeed;
        private TrackBar sliderTTSVol;
        private Label lblTTSVol;
        private ComboBox cmbChan;
        private Label lblChan;
        private ComboBox cmbServer;
        private Label lblServer;
        private ComboBox cmbTTS;
        private Label lblTTS;
        private Button btnLeave;
        private Button btnJoin;
        private TextBox txtToken;
        private Label lblBotTok;
        private TabPage tabPage2;
        public TextBox txtFFLogsToken;
        private Label label1;
       
        private Button btnDiscordConnect;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtDirThree;
        private ListBox lstThreeDirections;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtDirTwo;
        private ListBox lstTwoDirections;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txtTrigger;
        private ListBox lstMapTriggers;
        private GroupBox groupBox6;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox txtFriend;
        private ListBox lstFriends;
        private CheckBox chkAutoConnect;
        private Label label2;
        private TextBox txtParseChannel;
        private Label label3;
        private TextBox txtFFXIVName;
        private Button btnAddTriggers;
        private Button btnSaveSettings;
        private CheckBox chkParseFilter;
        private CheckBox chkDiscordCommands;
        private CheckBox chkfilterdmg;
        private Button TestMapBtn;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox txtAltarTrigger;
        private ListBox lstAltarTriggers;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox txtStatus;
        private ListBox lstStatus;
        private Button btnSetStatus;
        private CheckBox chkShowtext;
        private Random ran = new Random();

        private FormActMain.PlayTtsDelegate originalTTSDelegate;
        private Label label4;
        private TrackBar sliderEffectVol;
        private TabPage tabPage3;
        private TextBox logBox;
        private GroupBox groupBox9;
        private GroupBox groupBox8;
        private Label label5;
        private CheckBox chkPartyJoin;
        private FormActMain.PlaySoundDelegate originalSoundDelegate;

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText) {
            //ACT Stuff
            originalTTSDelegate = (FormActMain.PlayTtsDelegate)ActGlobals.oFormActMain.PlayTtsMethod.Clone();
            originalSoundDelegate = (FormActMain.PlaySoundDelegate)ActGlobals.oFormActMain.PlaySoundMethod.Clone();
            ActGlobals.oFormActMain.PlayTtsMethod = new FormActMain.PlayTtsDelegate(ParseTrigger);
            ActGlobals.oFormActMain.PlaySoundMethod = new FormActMain.PlaySoundDelegate(SpeakFile);
            lblStatus = pluginStatusText;
			settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_DiscordTriggers.config.xml");
			pluginScreenSpace.Controls.Add(this);
			pluginScreenSpace.Text = "Discord Triggers";
			Dock = DockStyle.Fill;
			xmlSettings = new SettingsSerializer(this);
			LoadSettings();
            txtDirTwo.KeyUp += AddNewListItem;
            txtDirThree.KeyUp += AddNewListItem;
            txtTrigger.KeyUp += AddNewListItem;
            txtFriend.KeyUp += AddNewListItem;
            txtAltarTrigger.KeyUp += AddNewListItem;
            txtStatus.KeyUp += AddNewListItem;

            txtFFLogsToken.TextChanged += UpdateToken;

            lstTwoDirections.KeyUp += RemoveListItem;
            lstThreeDirections.KeyUp += RemoveListItem;
            lstMapTriggers.KeyUp += RemoveListItem;
            lstFriends.KeyUp += RemoveListItem;
            lstAltarTriggers.KeyUp += RemoveListItem;
            lstStatus.KeyUp += RemoveListItem;

            chkDiscordCommands.CheckedChanged += ChkDiscordCommands_CheckedChanged;
            chkShowtext.CheckedChanged += ChkShowtext_CheckedChanged;

            //Discord Bot Stuff
            DiscordClient.BotReady += BotReady;
            DiscordClient.LoginFail += LoginFail;
            DiscordClient.Log += Log;
            DiscordClient.EnableCommands(chkDiscordCommands.Checked);

            if (chkAutoConnect.Checked)
                DiscordConnectbtn_Click(null, EventArgs.Empty);

            lblStatus.Text = "Drellis Started";
		}

        private void ChkDiscordCommands_CheckedChanged(object sender, EventArgs e)
        {
            DiscordClient.EnableCommands(chkDiscordCommands.Checked);
        }

        private void ChkShowtext_CheckedChanged(object sender, EventArgs e)
        {
            txtParseChannel.UseSystemPasswordChar = !chkShowtext.Checked;
            txtFFLogsToken.UseSystemPasswordChar = !chkShowtext.Checked;
            txtToken.UseSystemPasswordChar = !chkShowtext.Checked;
        }

        public async void DeInitPlugin() {
			ActGlobals.oFormActMain.PlayTtsMethod = originalTTSDelegate;
			ActGlobals.oFormActMain.PlaySoundMethod = originalSoundDelegate;
			SaveSettings();
			try {
                await DiscordClient.DeInIt();
			} catch (Exception ex) {
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Error with DeInit of Discord Plugin.");
			}
			lblStatus.Text = "Plugin Exited";
		}

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			try {
				var asm = new AssemblyName(args.Name);
				var plugin = ActGlobals.oFormActMain.PluginGetSelfData(this);
				string file;
				if (plugin != null) {
					file = plugin.pluginFile.DirectoryName;
					file = Path.Combine(file, asm.Name + ".dll");
					if (File.Exists(file)) {
						return Assembly.LoadFile(file);
					}
				}
				file = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Plugins\\Discord");
				file = Path.Combine(file, asm.Name + ".dll");
				if (File.Exists(file)) {
					return Assembly.LoadFrom(file);
				}
			} catch (Exception ex) {
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Error with loading an assembly for Discord Plugin.");
			}
			return null;
		}
        #endregion

        private readonly object speaklock = new object();

		#region Discord Methods
		private void Speak(string text) {
            if (DiscordClient.IsConnectedToChannel())
                    DiscordClient.Speak(text, cmbTTS.SelectedItem.ToString(), sliderTTSVol.Value, sliderTTSSpeed.Value);
            else
                originalTTSDelegate(text);
        }

		private void SpeakFile(string path, int volume) {
            if (DiscordClient.IsConnectedToChannel())
                DiscordClient.SpeakFile(path, sliderEffectVol.Value);
            else
                originalSoundDelegate(path, volume);
		}
        private void BotReady()
        {
            ActGlobals.oFormActMain.OnCombatEnd += OFormActMain_OnCombatEnd;
            Log("Connected to Discord.");
            btnJoin.Enabled = true;
            btnSetStatus.Enabled = true;
            PopulateServers();
            SetGameAsync(GetRandomStatus());
        }

        private void LoginFail()
        {
            Log("Error connecting to Discord. Discord may be down or key is incorrect.");
            btnDiscordConnect.Enabled = true;
        }


        private void PopulateServers()
        {
            try
            {
                string[] servers = DiscordClient.GetServers();

                cmbServer.Items.Clear();
                cmbChan.Items.Clear();

                foreach (string server in servers)
                    cmbServer.Items.Add(server);
                
                if (cmbServer.Items.Count > 0)
                    cmbServer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log("Error populating servers.");
                Log(ex.Message);
            }
        }

        private void PopulateChannels(string server)
        {
            try
            {
                cmbChan.Items.Clear();
                cmbChan.Items.AddRange(DiscordClient.GetChannels(server));
                if (cmbChan.Items.Count > 0)
                    cmbChan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log("Error populating channels.");
                Log(ex.Message);
            }
        }
        #endregion

        #region UI Events
        private async void BtnJoin_Click(object sender, EventArgs e) {

            btnJoin.Enabled = false;
            if (await DiscordClient.JoinChannel(cmbServer.SelectedItem.ToString(), cmbChan.SelectedItem.ToString()))
                btnLeave.Enabled = true;
            else
            {
                Log("Unable to join channel. Does your bot have permission to join this channel?");
                btnJoin.Enabled = true;
                PopulateServers();
            }
        }

		private void BtnLeave_Click(object sender, EventArgs e) {
			btnLeave.Enabled = false;
			try {
                DiscordClient.LeaveChannel();
				btnJoin.Enabled = true;
				btnLeave.Enabled = false;
				Log("Left channel.");
				btnJoin.Enabled = true;
			} catch (Exception ex) {
				Log("Error leaving channel. Possible connection issue.");
				btnLeave.Enabled = true;
				Log(ex.Message);
			}
		}

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateChannels(cmbServer.SelectedItem.ToString());
        }
        #endregion

        #region Discord Events

        public void Log(string text)
        {
            logBox.AppendText(text + "\n");
            Console.WriteLine(text);
        }

        private string activePlayer = "You";
        private bool normalCanals = true;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Await.Warning", "CS4014:Await.Warning")]

        public void ParseTrigger(string triggerText)
        {
            try
            {
                string text = triggerText;

                if (triggerText.StartsWith("#"))
                {
                    string player = triggerText.Substring(1);
                    activePlayer = player;
                    return;
                }

                if(triggerText.StartsWith("!!"))
                {
                    if (chkPartyJoin.Checked)
                    {
                        string[] parts = SplitCamelCase(triggerText.Substring(2));
                        if (parts.Length == 2)
                            DiscordTriggers.GetFFLogs("Lich", string.Join("", new string[] { parts[0], parts[1] }), ulong.Parse(txtParseChannel.Text));
                        else
                            DiscordTriggers.GetFFLogs(parts[2], string.Join("", new string[] { parts[0], parts[1] }), ulong.Parse(txtParseChannel.Text));
                    }
                    return;
                }

                switch (text)
                {
                    case "canalkey":
                        text = CreateQoute();
                        break;
                    case "portalspawned":
                        text = string.Format("A portal to {0}'s hole has opened.", activePlayer);
                        break;
                    case "canalnormal":
                        normalCanals = true;
                        SetGameAsync(string.Format("in {0}'s hole", activePlayer));
                        return;
                    case "canalhard":
                        normalCanals = false;
                        SetGameAsync(string.Format("in {0}'s secret hole", activePlayer));
                        return;
                    case "canalspin":
                        SetGameAsync(string.Format("in {0}'s hole of surprises", activePlayer));
                        return;
                    case "wheelspin":
                        text = string.Format("Spinning... {0}", SpinToWin());
                        break;
                    case "canalend":
                        SetGameAsync(GetRandomStatus());
                        return;
                }

                Speak(text);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }

        public void SetGameAsync(string text)
        {
            DiscordClient.SetGameAsync(text);
        }

        public string CreateQoute()
        {
            try
            {
                string dir = PickDirection();
                string q = lstMapTriggers.Items[ran.Next(lstMapTriggers.Items.Count)].ToString();
                string f = lstFriends.Items[ran.Next(lstFriends.Items.Count)].ToString();
                return string.Format(q, dir, f);
            }
            catch
            {
                return "Looks like i can't find the door.";
            }
        }

        public string SpinToWin()
        {
            try
            {
                return string.Format(lstAltarTriggers.Items[ran.Next(lstAltarTriggers.Items.Count)].ToString(),activePlayer, 
                    lstFriends.Items[ran.Next(lstFriends.Items.Count)].ToString());
            }
            catch
            {
                return string.Format("{0}'s hole",activePlayer);
            }
        }

        public string GetRandomStatus()
        {
            try
            {
                return lstStatus.Items[ran.Next(lstStatus.Items.Count)].ToString();
            }
            catch
            {
                return "with ACT Triggers";
            }
        }

        private string PickDirection()
        {
            return normalCanals ? lstTwoDirections.Items[ran.Next(lstTwoDirections.Items.Count)].ToString() : lstThreeDirections.Items[ran.Next(lstThreeDirections.Items.Count)].ToString();

        }

        #endregion

        #region Parses

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            StringBuilder text = new StringBuilder();
            TimeSpan totalTime = encounterInfo.encounter.EndTime - encounterInfo.encounter.StartTime;

            //title
            text.AppendLine(encounterInfo.encounter.StartTime.ToShortDateString() + " " + encounterInfo.encounter.StartTime.ToLongTimeString());
            text.AppendLine("**[" + encounterInfo.encounter.ZoneName + "][" + encounterInfo.encounter.Title + "]<" + totalTime + ">**");



            StringBuilder parsedata = new StringBuilder();

            //parsedata.Append(CreateStringWithSpacing("Job", 6));
            parsedata.Append(CreateStringWithSpacing("Player", 10, false));
            parsedata.Append(CreateStringWithSpacing("DPS", 8));
            parsedata.Append(CreateStringWithSpacing("CRT", 6));
            parsedata.Append(CreateStringWithSpacing("DHIT", 6));
            parsedata.Append(CreateStringWithSpacing("DCRT", 6));
            parsedata.Append(CreateStringWithSpacing("Deaths", 8));
            parsedata.Append(CreateStringWithSpacing("Best Hit", 20));
            parsedata.AppendLine();

            List<CombatantData> playerData = encounterInfo.encounter.GetAllies();
            playerData.Sort((x, y) => y.DPS.CompareTo(x.DPS));

            if (playerData.Count == 0)
                return;

            string limitbreak = " Limit Break: ";
            bool usedLimitBreak = false;

            int parselogged = 0;
            for (int i = 0; i < playerData.Count; i++)
            {
                if (playerData[i].Name == "Limit Break")
                {
                    string limitbreakname = FormatMaxHit(playerData[i].GetMaxHit());
                    if (string.IsNullOrWhiteSpace(limitbreakname))
                        limitbreakname = "The Holy Grail of Tryhards Pants <7 Nubs Raised>";
                    limitbreak += limitbreakname;
                    usedLimitBreak = true;
                    continue;
                }

                string dpsString = playerData[i].DPS.ToString();

                if (chkfilterdmg.Checked && (dpsString == "NaN" || ((int)playerData[i].DPS < 0)))
                    continue;

                if (parselogged != 0)
                    parsedata.AppendLine();

                double.TryParse(playerData[i].GetColumnByName("DirectHitPct").TrimEnd(new char[] { '%' }), out double directhit);
                double.TryParse(playerData[i].GetColumnByName("CritDirectHitPct").TrimEnd(new char[] { '%' }), out double directhitcrt);


                //parsedata.Append(GetJob(playerData[i].GetColumnByName("Job")));
                parsedata.Append(CreateStringWithSpacing(SplitName(playerData[i].Name == "YOU" ? txtFFXIVName.Text : playerData[i].Name), 10, false));
                parsedata.Append(CreateStringWithSpacing(Bracket(dpsString == "NaN" || (int)playerData[i].DPS < 0 ? "∞" : ((int)playerData[i].DPS).ToString()), 8));
                parsedata.Append(CreateStringWithSpacing(Bracket(((int)playerData[i].CritDamPerc).ToString() + "%"), 6));
                parsedata.Append(CreateStringWithSpacing(Bracket(((int)directhit).ToString() + "%"), 6));
                parsedata.Append(CreateStringWithSpacing(Bracket(((int)directhitcrt).ToString() + "%"), 6));
                parsedata.Append(CreateStringWithSpacing(Bracket(playerData[i].Deaths.ToString()), 8));
                parsedata.Append(CreateStringWithSpacing(FormatMaxHit(playerData[i].GetMaxHit()), 20));

                parselogged++;
            }

            parsedata = new StringBuilder("```md\n" + parsedata + "```");
            parsedata.AppendLine("Encounter DPS: <" + (int)encounterInfo.encounter.DPS + "> " + (usedLimitBreak ? limitbreak : ""));

            text.AppendLine(parsedata.ToString());

            if (chkParseFilter.Checked)
            {
                if (totalTime < new TimeSpan(0, 3, 0) || playerData.Count < 4)
                    return;
            }

            if (DiscordClient.SendChannelMessage(text.ToString(), ulong.Parse(txtParseChannel.Text)))
                Log("Parse Posted.");
            else
                Log("Parse channel not found.");


        }

        public string CreateStringWithSpacing(string text, int size, bool centertext = true)
        {
            char spacing = ' ';
            char[] newtext = new char[size];
            if (centertext)
                return CenterString(text, size, spacing);

            for (int i = 0; i < newtext.Length; i++)
            {
                if (i < text.Length)
                    newtext[i] = text[i];
                else
                    newtext[i] = spacing;
            }
            return new string(newtext);
        }

        public string SplitName(string name)
        {
            return name.Split(' ')[0];
        }

        public string Bracket(string text)
        {
            return "<" + text + ">";
        }

        public string CenterString(string stringToCenter, int totalLength, char paddingCharacter)
        {
            return stringToCenter.PadLeft(
                ((totalLength - stringToCenter.Length) / 2) + stringToCenter.Length,
                  paddingCharacter).PadRight(totalLength, paddingCharacter);
        }

        public string FormatMaxHit(string text)
        {
            char splitter = '-';
            string[] splits = text.Split(splitter);
            if (splits.Length < 2)
                return text;
            return splits[0] + " <" + splits[1] + ">";
        }
        #endregion


        #region Settings
        public void LoadSettings() {
			xmlSettings.AddControlSetting(txtToken.Name, txtToken);
            xmlSettings.AddControlSetting(txtFFLogsToken.Name, txtFFLogsToken);
			xmlSettings.AddControlSetting(sliderTTSVol.Name, sliderTTSVol);
			xmlSettings.AddControlSetting(sliderTTSSpeed.Name, sliderTTSSpeed);
            xmlSettings.AddControlSetting(sliderEffectVol.Name, sliderEffectVol);
            xmlSettings.AddControlSetting(txtParseChannel.Name, txtParseChannel);
            xmlSettings.AddControlSetting(chkParseFilter.Name, chkParseFilter);
            xmlSettings.AddControlSetting(txtFFXIVName.Name, txtFFXIVName);
            xmlSettings.AddControlSetting(chkAutoConnect.Name, chkAutoConnect);
            xmlSettings.AddControlSetting(lstTwoDirections.Name, lstTwoDirections);
            xmlSettings.AddControlSetting(lstThreeDirections.Name, lstThreeDirections);
            xmlSettings.AddControlSetting(lstMapTriggers.Name, lstMapTriggers);
            xmlSettings.AddControlSetting(lstFriends.Name, lstFriends);
            xmlSettings.AddControlSetting(lstAltarTriggers.Name, lstAltarTriggers);
            xmlSettings.AddControlSetting(lstStatus.Name, lstStatus);
            xmlSettings.AddControlSetting(chkDiscordCommands.Name, chkDiscordCommands);
            xmlSettings.AddControlSetting(chkfilterdmg.Name, chkfilterdmg);
            xmlSettings.AddControlSetting(chkPartyJoin.Name, chkPartyJoin);

            if (File.Exists(settingsFile)) {
				FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlTextReader xReader = new XmlTextReader(fs);
				try {
					while (xReader.Read())
						if (xReader.NodeType == XmlNodeType.Element)
							if (xReader.LocalName == "SettingsSerializer")
								xmlSettings.ImportFromXml(xReader);
				} catch (Exception ex) {
					lblStatus.Text = "Error loading settings: " + ex.Message;
				}
				xReader.Close();
			}
            if (!string.IsNullOrEmpty(txtFFXIVName.Text))
                activePlayer = txtFFXIVName.Text;
		}

		public bool SaveSettings() {
            try
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 1,
                    IndentChar = '\t'
                };
                xWriter.WriteStartDocument(true);
                xWriter.WriteStartElement("Config");
                xWriter.WriteStartElement("SettingsSerializer");
                xmlSettings.ExportToXml(xWriter);
                xWriter.WriteEndElement();
                xWriter.WriteEndElement();
                xWriter.WriteEndDocument();
                xWriter.Flush();
                xWriter.Close();
            }
            catch
            {
                return false;
            }
            return true;
		}
        #endregion

        private void RemoveListItem(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back) || sender.GetType() != typeof(ListBox))
                return;

            ListBox lst = (ListBox)sender;

            if (lst.SelectedItem != null)
                lst.Items.Remove(lst.SelectedItem);

        }

        private void AddNewListItem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || sender.GetType() != typeof(TextBox))
                return;
            TextBox txt = (TextBox)sender;
            ListBox lst;

            if (string.IsNullOrWhiteSpace(txt.Text))
                return;
                

            switch(txt.Name)
            {
                case "txtDirTwo":
                    lst = lstTwoDirections;
                    break;
                case "txtDirThree":
                    lst = lstThreeDirections;
                    break;
                case "txtTrigger":
                    lst = lstMapTriggers;
                    break;
                case "txtFriend":
                    lst = lstFriends;
                    break;
                case "txtAltarTrigger":
                    lst = lstAltarTriggers;
                    break;
                case "txtStatus":
                    lst = lstStatus;
                    break;
                default:
                    return;
            }

            if(!lst.Items.Contains(txt.Text))
                lst.Items.Add(txt.Text);
            txt.Clear();
        }

        private void UpdateToken(object sender, EventArgs e)
        {
            DiscordClient.FFLogsToken = txtFFLogsToken.Text;
        }

        private void DiscordConnectbtn_Click(object sender, EventArgs e)
        {
            btnDiscordConnect.Enabled = false;
            Log("Connecting to Discord...");
            DiscordClient.InIt(txtToken.Text, txtFFLogsToken.Text);
        }

        private void BtnAddTriggers_Click(object sender, EventArgs e)
        {
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Hidden Canals of Uznair has begun.", "canalhard"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Shifting Altars of Uznair has begun.", "canalspin"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Lost Canals of Uznair has begun.", "canalnormal"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("A portal into Uznair has appeared.", "portalspawned"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Hidden Canals of Uznair has ended.", "canalend"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Lost Canals of Uznair has ended.", "canalend"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The Shifting Altars of Uznair has ended.", "canalend"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("An unknown force drives off the Atomos asipu.", "BONUS ROOM"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("You obtain a vault key.", "canalkey"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("(?<first>\\w+) (?<last>\\w+) (use|uses) Dig.", "#${first}"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("A Namazu stickywhisker appears!", "A wild Sticky Wisker has spawned!"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("Abharamu appears!", "A wild Abharamu has spawned!"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("An altar Matanga appears!", "A wild Matanga has spawned!"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("Gold whiskers appear!", "A wild Sticky Wisker has spawned!"));
            ActGlobals.oFormActMain.AddEditCustomTrigger(CreateTrigger("The circles dance!", "wheelspin"));
            SaveSettings();
            MessageBox.Show("Triggers Added.");
        }

        private CustomTrigger CreateTrigger(string trigger,string texttospeech, string category = "Map Triggers")
        {
            return new CustomTrigger(trigger, 3, texttospeech, false, string.Empty, false) { Category = category };
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
                MessageBox.Show("Saved.");
            else
                MessageBox.Show("Failed to save.");
        }

        private void TestMapBtn_Click(object sender, EventArgs e)
        {
            string q = lstMapTriggers.SelectedItem != null ? lstMapTriggers.SelectedItem.ToString() : lstMapTriggers.Items[ran.Next(lstMapTriggers.Items.Count)].ToString();
            string f = lstFriends.Items[ran.Next(lstFriends.Items.Count)].ToString();
            Speak(string.Format(q, PickDirection(), f));
        }

        private void BtnSetStatus_Click(object sender, EventArgs e)
        {
            string update = txtStatus.Text;

            if (string.IsNullOrEmpty(update))
            {
                if (lstStatus.SelectedItem != null)
                {
                    update = lstStatus.SelectedItem.ToString();
                    SetGameAsync(update);
                    lstStatus.SelectedIndex = -1;
                }
                else
                {
                    Log("Please enter text or select a status from the list.");
                    return;
                }
            }
            else
            {
                SetGameAsync(update);
                txtStatus.Text = string.Empty;
            }
            Log(string.Format("Status updated to - {0}", update));
        }
    }
}