//-----------------------------------------------------------------------
// <copyright file="MtListView.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace MyToolkit.Controls
{
    /// <summary>A <see cref="ListView"/> with additional features. </summary>
    public class MtListView : ListView
    {
        /// <summary>Initializes a new instance of the <see cref="MtListView"/> class. </summary>
        public MtListView()
        {
            ItemContainerStyle = (Style)XamlReader.Load(
                @"<Style TargetType=""ListViewItem"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
					<Setter Property=""HorizontalContentAlignment"" Value=""Stretch""/>
				</Style>");
        }
    }

    /// <summary>A <see cref="ListView"/> with additional features. </summary>
    [Obsolete("Use MtListView instead. 8/31/2014")]
    public class ExtendedListView : MtListView
    {
    }
}