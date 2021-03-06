﻿//-----------------------------------------------------------------------
// <copyright file="EmptyActivity.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace MyToolkit.WorkflowEngine.Activities
{
    /// <summary>An activity which does nothing.</summary>
    [XmlType("Empty")]
    public class EmptyActivity : WorkflowActivityBase
    {
    }
}
