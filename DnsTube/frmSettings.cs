﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DnsTube
{
	public partial class frmSettings : Form
	{
		Settings settings;

		public frmSettings(Settings settings)
		{
			this.settings = settings;
			InitializeComponent();
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		void btnSave_Click(object sender, EventArgs e)
		{
			settings.EmailAddress = txtEmail.Text;
			settings.IsUsingToken = rbUseApiToken.Checked;
			settings.ApiKey = txtApiKey.Text;
			settings.ApiToken = txtApiToken.Text;
			settings.UpdateIntervalMinutes = int.Parse(txtUpdateInterval.Text);
			settings.StartMinimized = chkStartMinimized.Checked;
			settings.SkipCheckForNewReleases = !chkNotifyOfUpdates.Checked;
			settings.ProtocolSupport = GetProtocol();
			settings.ZoneIDs = txtZoneIDs.Text;
			settings.Save();
			Close();
		}

		private IpSupport GetProtocol()
		{
			if (rbProtocolIPv4.Checked)
				return IpSupport.IPv4;
			if (rbProtocolIPv6.Checked)
				return IpSupport.IPv6;
			return IpSupport.IPv4AndIPv6;
		}

		void frmSettings_Load(object sender, EventArgs e)
		{
			txtEmail.Text = settings.EmailAddress;
			rbUseApiToken.Checked = settings.IsUsingToken;
			rbUseApiKey.Checked = !settings.IsUsingToken;
			txtApiKey.Text = settings.ApiKey;
			txtApiToken.Text = settings.ApiToken;
			txtUpdateInterval.Text = settings.UpdateIntervalMinutes.ToString();
			chkStartMinimized.Checked = settings.StartMinimized;
			chkNotifyOfUpdates.Checked = !settings.SkipCheckForNewReleases;
			rbProtocolIPv4.Checked = settings.ProtocolSupport == IpSupport.IPv4;
			rbProtocolIPv6.Checked = settings.ProtocolSupport == IpSupport.IPv6;
			rbProtocolIPv4AndIPv6.Checked = settings.ProtocolSupport == IpSupport.IPv4AndIPv6;
			txtZoneIDs.Text = settings.ZoneIDs;

			HandleAuthDisplay();
		}

		void txtUpdateInterval_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void rbUseApiKeyOrToken_CheckedChanged(object sender, EventArgs e)
		{
			settings.IsUsingToken = rbUseApiToken.Checked;
			HandleAuthDisplay();
		}

		private void HandleAuthDisplay()
		{
			if (rbUseApiKey.Checked)
			{
				txtApiToken.Hide();
				lblApiToken.Hide();
				txtApiKey.Show();
				lblApiKey.Show();

			}
			if (rbUseApiToken.Checked)
			{
				txtApiToken.Show();
				lblApiToken.Show();
				txtApiKey.Hide();
				lblApiKey.Hide();
			}
		}

		private void chkStartMinimized_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://dash.cloudflare.com/profile/api-tokens");
		}
	}
}
