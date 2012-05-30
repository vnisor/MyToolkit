﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MyToolkit.Controls.HtmlTextBlockSource;

namespace MyToolkit.Controls
{
	public partial class HtmlTextBlock : UserControl, IHtmlSettings
	{
		public HtmlTextBlock()
		{
			FontSize = (double) Resources["PhoneFontSizeNormal"];
			InitializeComponent();

			SizeChanged += OnSizeChanged;
			SizeChangedControls = new List<ISizeChangedControl>();
		}

		public List<ISizeChangedControl> SizeChangedControls { get; private set; } 

		private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
		{
			foreach (var ctrl in SizeChangedControls)
				ctrl.Update(ActualWidth);
		}

		public static readonly DependencyProperty HtmlProperty =
			DependencyProperty.Register("Html", typeof(String), typeof(HtmlTextBlock), new PropertyMetadata(default(String), OnChanged));

		public String Html
		{
			get { return (String) GetValue(HtmlProperty); }
			set { SetValue(HtmlProperty, value); }
		}

		public event EventHandler<RoutedEventArgs> HtmlLoaded;

		public static readonly DependencyProperty ParagraphMarginProperty =
			DependencyProperty.Register("ParagraphMargin", typeof (int), typeof (HtmlTextBlock), new PropertyMetadata(12));

		public int ParagraphMargin
		{
			get { return (int) GetValue(ParagraphMarginProperty); }
			set { SetValue(ParagraphMarginProperty, value); }
		}

		public static readonly DependencyProperty BaseUriProperty =
			DependencyProperty.Register("BaseUri", typeof (Uri), typeof (HtmlTextBlock), new PropertyMetadata(default(Uri)));

		public Uri BaseUri
		{
			get { return (Uri) GetValue(BaseUriProperty); }
			set { SetValue(BaseUriProperty, value); }
		}

		private readonly IDictionary<string, IControlGenerator> generators = HtmlParser.GetDefaultGenerators();
		public IDictionary<string, IControlGenerator> Generators
		{
			get { return generators; }
		}

		private static void OnChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			var box = (HtmlTextBlock)obj;
			var html = box.Html;
			box.Generate(html);
		}

		private void Generate(string html)
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				var parser = new HtmlParser();
				var node = parser.Parse(html);

				Dispatcher.BeginInvoke(() =>
				{
					if (html == Html) // prevent from setting wrong control if html changed fast
					{
						Content = node.GetControl(this) as UIElement;
						Dispatcher.BeginInvoke(() =>
						{
							var copy = HtmlLoaded;
							if (copy != null)
								copy(this, new RoutedEventArgs());
						});
					}
				});
			});
		}
	}
}
