﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Dock.Model
{
    /// <summary>
    /// View contract.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Gets or sets view id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets view title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets view context.
        /// </summary>
        object Context { get; set; }

        /// <summary>
        /// Gets or sets view parent.
        /// </summary>
        /// <remarks>If parrent is null than view is root.</remarks>
        IView Parent { get; set; }

        /// <summary>
        /// Called when the view is closed.
        /// </summary>
        /// <returns>true to accept the close, and false to cancel the close.</returns>
        bool OnClose();

        /// <summary>
        /// Called when the view becomes the selected view.
        /// </summary>
        void OnSelected();
    }
}
