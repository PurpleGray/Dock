﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using Dock.Model.Controls;
using Dock.Model.Controls.Editor;
using ReactiveUI.Legacy;

namespace Dock.Model
{
    /// <summary>
    /// Dock factory.
    /// </summary>
    public abstract class DockFactory : DockFactoryBase
    {
        /// <inheritdoc/>
        public override IList<T> CreateList<T>(params T[] items)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var type = typeof(ReactiveList<>).MakeGenericType(typeof(T));
#pragma warning restore CS0618 // Type or member is obsolete
            return (IList<T>)Activator.CreateInstance(type, items);
        }

        /// <inheritdoc/>
        public override IRootDock CreateRootDock() => new RootDock();

        /// <inheritdoc/>
        public override IPinDock CreatePinDock() => new PinDock();

        /// <inheritdoc/>
        public override ILayoutDock CreateLayoutDock() => new LayoutDock();

        /// <inheritdoc/>
        public override ISplitterDock CreateSplitterDock() => new SplitterDock();

        /// <inheritdoc/>
        public override IToolDock CreateToolDock() => new ToolDock();

        /// <inheritdoc/>
        public override IDocumentDock CreateDocumentDock() => new DocumentDock();

        /// <inheritdoc/>
        public override IDockWindow CreateDockWindow() => new DockWindow();

        /// <inheritdoc/>
        public override IToolTab CreateToolTab() => new ToolTab();

        /// <inheritdoc/>
        public override IDocumentTab CreateDocumentTab() => new DocumentTab();

        /// <inheritdoc/>
        public override IView CreateView() => new ViewStub();

        /// <inheritdoc/>
        public override IDock CreateDock() => new DockStub();
    }
}
