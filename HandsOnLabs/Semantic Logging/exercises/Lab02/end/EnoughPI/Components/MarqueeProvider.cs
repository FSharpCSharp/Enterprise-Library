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
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EnoughPI.Components
{
	/// <summary>
	/// Summary description for MarqueeProvider.
	/// </summary>
	[ProvideProperty("IsMarquee", typeof(ProgressBar))]
	[ProvideProperty("AnimationWait", typeof(ProgressBar))]
	public class MarqueeProvider : 
		System.ComponentModel.Component, 
		IExtenderProvider, ISupportInitialize
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MarqueeProvider(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public MarqueeProvider()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region IExtenderProvider Members

		public bool CanExtend(object extendee)
		{
			return extendee is ProgressBar;
		}

		#endregion

		private class ExtendedProperties
		{
			private bool m_IsMarquee = false;

			public bool IsMarquee
			{
				get { return this.m_IsMarquee; }
				set { this.m_IsMarquee = value; }
			}

			private int m_AnimationWait = 50;

			public int AnimationWait
			{
				get { return this.m_AnimationWait; }
				set { this.m_AnimationWait = value; }
			}
		}

		private Hashtable m_ExtendedProperties = new Hashtable();

		private ExtendedProperties GetExtendedProperties(ProgressBar extendee)
		{	
			ExtendedProperties properties = null;

			if (this.m_ExtendedProperties.Contains(extendee))
			{
				properties = (ExtendedProperties)this.m_ExtendedProperties[extendee];
			}
			else
			{
				properties = new ExtendedProperties();
			}

			return properties;
		}

		private void SetExtendedProperties(ProgressBar extendee, ExtendedProperties properties)
		{
			this.m_ExtendedProperties[extendee] = properties;
		}

		public bool GetIsMarquee(ProgressBar extendee)
		{
			ExtendedProperties properties = this.GetExtendedProperties(extendee);
			bool isMarquee = properties.IsMarquee;
			return isMarquee;
		}

		public void SetIsMarquee(ProgressBar extendee, bool isMarquee)
		{
			ExtendedProperties properties = this.GetExtendedProperties(extendee);
			properties.IsMarquee = isMarquee;
			this.SetExtendedProperties(extendee, properties);
		}

		public int GetAnimationWait(ProgressBar extendee)
		{
			ExtendedProperties properties = this.GetExtendedProperties(extendee);
			int animationWait = properties.AnimationWait;
			return animationWait;
		}

		public void SetAnimationWait(ProgressBar extendee, int animationWait)
		{
			ExtendedProperties properties = this.GetExtendedProperties(extendee);
			properties.AnimationWait = animationWait;
			this.SetExtendedProperties(extendee, properties);
		}

		#region ISupportInitialize Members

		public void BeginInit()
		{
			// TODO:  Add MarqueeProvider.BeginInit implementation
		}

		public void EndInit()
		{
			foreach (DictionaryEntry entry in this.m_ExtendedProperties)
			{
				ExtendedProperties properties = (ExtendedProperties)entry.Value;

				if (properties.IsMarquee)
				{
					ProgressBar progressBar = (ProgressBar)entry.Key;
					progressBar.HandleCreated += new EventHandler(progressBar_HandleCreated);
				}
			}
		}

		#endregion

		private const int WM_USER = 1024;
		private const int PBM_SETMARQUEE = (WM_USER + 10);
		private const int GWL_STYLE = -16;
		private const int PBS_MARQUEE = 8;

		[DllImport("user32.dll")]
		private static extern int GetWindowLong (IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		private static extern int SetWindowLong (IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private void SetMarquee(ProgressBar progressBar, int animationWait)
		{
			int style = MarqueeProvider.GetWindowLong(
				progressBar.Handle,
				GWL_STYLE
				);
			MarqueeProvider.SetWindowLong(
				progressBar.Handle,
				GWL_STYLE,
				style | PBS_MARQUEE
				);
			MarqueeProvider.SendMessage(
				progressBar.Handle,
				PBM_SETMARQUEE,
				1,
				animationWait
				);
		}

		private void progressBar_HandleCreated(object sender, EventArgs e)
		{
			ProgressBar extendee = (ProgressBar)sender;
			ExtendedProperties properties = this.GetExtendedProperties(extendee);
			this.SetMarquee(extendee, properties.AnimationWait);
		}
	}
}
